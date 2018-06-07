using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;

namespace QuanLiTraSua
{
    public partial class frmAdmin : Form
    {
        public AccountDTO loginaccount;
        BindingSource bsfood = new BindingSource();
        BindingSource bsCatagory = new BindingSource();
        BindingSource bsTable = new BindingSource();
        BindingSource bsAccount = new BindingSource();

        public frmAdmin()
        {
            InitializeComponent();
            Load();
        }

        void Load()
        {
            dgvfood.DataSource = bsfood;
            dgvcategory.DataSource = bsCatagory;
            dgvtable.DataSource = bsTable;
            dgvaccount.DataSource = bsAccount;
         
            //thuc an
            LoadFood();
            BindingFood();
            //catagory
            LoadCatagory();
            BindingCatagory();
            //table
            LoadTable();
            BindingTable();
            //Account
            LoadAccount();
            BindingAccount();
            //thong ke
            LoadDateTimePicker();
            LoadListBillByDate(dtpfromdate.Value, dtptodate.Value);
            LoadDateTimePickerReport();
            ReportDTOBindingSource.DataSource = DAO.ReportDAO.GetListThongKe(dtpNgayBD.Value,dtpNgayKT.Value);
            this.rpBaoCao.RefreshReport();      
        }
        //Doanh thu
        void LoadListBillByDate(DateTime ngayvao, DateTime ngayra)
        {
            dgvbill.DataSource = BillDAO.GetListBillDate(ngayvao, ngayra);
            dgvbill.Columns["tenban"].HeaderText = "Tên bàn";
            dgvbill.Columns["TongTien"].HeaderText = "Tổng tiền";
            dgvbill.Columns["ngayvao"].HeaderText = "Ngày vào";
            dgvbill.Columns["ngayra"].HeaderText = "Ngày ra";
        }

        void LoadDateTimePicker()
        {
            DateTime today = DateTime.Now;
            dtpfromdate.Value = new DateTime(today.Year, today.Month, 1);
            dtptodate.Value = dtpfromdate.Value.AddMonths(1).AddDays(-1);
        }

        private void btnviewbill_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpfromdate.Value, dtptodate.Value);
        }
        //thức ăn

        private event EventHandler insertfood;
        public event EventHandler Inssertfood
        {
            add { insertfood += value; }
            remove { insertfood -= value; }
        }

        private event EventHandler updatefood;
        public event EventHandler Updatefood
        {
            add { updatefood += value; }
            remove { updatefood -= value; }
        }

        private event EventHandler deletefood;
        public event EventHandler Deletefood
        {
            add { deletefood += value; }
            remove { deletefood -= value; }
        }

        //catagory
        private event EventHandler insertcatagory;
        public event EventHandler Insertcatagory
        {
            add { insertcatagory += value; }
            remove { insertcatagory -= value; }
        }

        private event EventHandler updatecatagory;
        public event EventHandler Updatecatagory
        {
            add { updatecatagory += value; }
            remove { updatecatagory -= value; }
        }

        private event EventHandler deletecatagory;
        public event EventHandler Deletecatagory
        {
            add { deletecatagory += value; }
            remove { deletecatagory -= value; }
        }

        //bàn ăn
        private event EventHandler addtable;
        public event EventHandler AddTable
        {
            add { addtable += value; }
            remove { addtable -= value; }
        }
        private event EventHandler updatetable;
        public event EventHandler UpdateTable
        {
            add { updatetable += value; }
            remove { updatetable -= value; }
        }
        private event EventHandler deletetable;
        public event EventHandler DeleteTable
        {
            add { deletetable += value; }
            remove { deletetable -= value; }
        }
        
        private void LoadFood()
        {
            bsfood.DataSource = FoodDAO.LoadFood();
            dgvfood.Columns["tenthucan"].HeaderText = "Tên món";
            dgvfood.Columns["gia"].HeaderText = "Giá";
            dgvfood.Columns["trangthai"].HeaderText = "Tình trạng";

            dgvfood.Columns["id"].Visible = false;
            dgvfood.Columns["idloaithucan"].Visible = false;
        }

        private void BindingFood()
        {
            txtfoodid.DataBindings.Add("Text", dgvfood.DataSource, "id", true, DataSourceUpdateMode.Never);
            txtNameFood.DataBindings.Add("Text", dgvfood.DataSource, "tenthucan", true, DataSourceUpdateMode.Never);
            nmfoodprice.DataBindings.Add("Value", dgvfood.DataSource, "gia", true, DataSourceUpdateMode.Never);
            txtStatusFood.DataBindings.Add("Text", dgvfood.DataSource, "trangthai", true, DataSourceUpdateMode.Never);

            cbfoodcategory.DataSource = DAO.CatagoryDAO.LoadLoaiThucAn();
            cbfoodcategory.DisplayMember = "tenloaithucan";
            cbfoodcategory.ValueMember = "id";
        }

        private void txtfoodid_TextChanged(object sender, EventArgs e)
        {
            if (dgvfood.SelectedCells.Count > 0)
            {
                int id = (int)dgvfood.SelectedCells[0].OwningRow.Cells["idloaithucan"].Value;
                
                CatagoryDTO catagory = DAO.CatagoryDAO.GetCatagoryById(id);
                
                cbfoodcategory.SelectedItem = catagory;

                int index = -1;
                int i = 0;

                foreach (CatagoryDTO item in cbfoodcategory.Items)
                {
                    if (item.Id == catagory.Id)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
                cbfoodcategory.SelectedIndex = index;
            }  
        }

        private void btnaddfood_Click(object sender, EventArgs e)
        {
            string name = txtNameFood.Text;
            int idcatagory = (cbfoodcategory.SelectedItem as CatagoryDTO).Id;
            float price = (float)nmfoodprice.Value;
            if (FoodDAO.AddFood(name, idcatagory, price))
            {
                MessageBox.Show("Bạn đã thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadFood();
                if (insertfood != null)
                    insertfood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btneditfood_Click(object sender, EventArgs e)
        {
            string name = txtNameFood.Text;
            int idcatagory = (cbfoodcategory.SelectedItem as CatagoryDTO).Id;
            float price = (float)nmfoodprice.Value;
            int id = int.Parse(txtfoodid.Text);
            string trangthai = txtStatusFood.Text;
            if (FoodDAO.UpdateFood(name, idcatagory, price, id, trangthai))
            {
                MessageBox.Show("Bạn đã sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadFood();
                if (updatefood != null)
                    updatefood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btndeletefood_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtfoodid.Text);
            if (FoodDAO.DeleteFood(id))
            {
                MessageBox.Show("Bạn đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadFood();
                if (deletefood != null)
                    deletefood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<FoodDTO> SearchFoodByName(string name)
        {
            List<FoodDTO> lst = null;
            lst = FoodDAO.SearchFoodByName(txtfoodname.Text);
            if (lst == null)
                return null;
           return lst;
        }

        private void btnsearchfood_Click(object sender, EventArgs e)
        {
            if (SearchFoodByName(txtfoodname.Text) == null)
            {
                MessageBox.Show("Không tìm thấy món ăn này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtfoodname.Text = "";
                txtfoodname.Focus();
                return;
            }
            bsfood.DataSource = SearchFoodByName(txtfoodname.Text);
        }

        private void btnviewfood_Click(object sender, EventArgs e)
        {
            LoadFood();
        }

        //catagory
        private void LoadCatagory()
        {
            bsCatagory.DataSource = DAO.CatagoryDAO.LoadLoaiThucAn();
            dgvcategory.Columns["tenloaithucan"].HeaderText = "Tên loại món";
            dgvcategory.Columns["trangthai"].HeaderText = "Tình trạng";

            dgvcategory.Columns["id"].Visible = false;
        }

        private void btnviewcategory_Click(object sender, EventArgs e)
        {
            LoadCatagory();
        }

        private void BindingCatagory()
        {
            txtcategoryid.DataBindings.Add("Text", dgvcategory.DataSource, "id", true, DataSourceUpdateMode.Never);
            txtcategoryname.DataBindings.Add("Text", dgvcategory.DataSource, "tenloaithucan", true, DataSourceUpdateMode.Never);
            txtStatusCatagory.DataBindings.Add("Text", dgvcategory.DataSource, "trangthai", true, DataSourceUpdateMode.Never);       
        }

        private void btnaddcategory_Click(object sender, EventArgs e)
        {
            string namecata = txtcategoryname.Text;
            string trangthai = txtStatusCatagory.Text;
            if (DAO.CatagoryDAO.AddCatagory(namecata,trangthai))
            {
                MessageBox.Show("Bạn đã thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCatagory();
                if (insertcatagory != null)
                    insertcatagory(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btneditcategory_Click(object sender, EventArgs e)
        {
            string namecata = txtcategoryname.Text;
            string trangthai = txtStatusCatagory.Text;
            int idcata = int.Parse(txtcategoryid.Text);
            if (DAO.CatagoryDAO.EditCatagory(namecata,trangthai,idcata))
            {
                MessageBox.Show("Bạn đã sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCatagory();
                if (updatecatagory != null)
                    updatecatagory(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btndeletecategory_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtcategoryid.Text);
            if (DAO.CatagoryDAO.DeleteCatagory(id))
            {
                MessageBox.Show("Bạn đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCatagory();
                if (deletecatagory != null)
                    deletecatagory(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        //table
        private void LoadTable()
        {
            bsTable.DataSource = DAO.TableDAO.LoadTable();
            dgvtable.Columns["tenban"].HeaderText = "Tên bàn";
            dgvtable.Columns["banhoatdong"].HeaderText = "Tình trạng";

            dgvtable.Columns["id"].Visible = false;
        }

        private void btnviewtable_Click(object sender, EventArgs e)
        {
            bsTable.DataSource = DAO.TableDAO.LoadTable();
        }

        private void BindingTable()
        {
            txttableid.DataBindings.Add("Text", dgvtable.DataSource, "id", true, DataSourceUpdateMode.Never);
            txttablename.DataBindings.Add("Text", dgvtable.DataSource, "tenban", true, DataSourceUpdateMode.Never);
            txtbanhoatdong.DataBindings.Add("Text", dgvtable.DataSource, "banhoatdong", true, DataSourceUpdateMode.Never);


            cbstatustable.DataSource = DAO.TableDAO.LoadTable();
            cbstatustable.DisplayMember = "trangthai";
            cbstatustable.ValueMember = "id";
        }

        private void txttableid_TextChanged(object sender, EventArgs e)
        {
            if (dgvtable.SelectedCells.Count > 0)
            {
                int id = (int)dgvtable.SelectedCells[0].OwningRow.Cells["id"].Value;

                TableDTO table = DAO.TableDAO.GetTableById(id);

                cbstatustable.SelectedItem = table;

                int index = -1;
                int i = 0;

                foreach (TableDTO item in cbstatustable.Items)
                {
                    if (item.ID == table.ID)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
                cbstatustable.SelectedIndex = index;
            }  
        }

        private void btnaddtable_Click(object sender, EventArgs e)
        {
            string name = txttablename.Text;
            if (DAO.TableDAO.AddTable(name))
            {
                MessageBox.Show("Bạn đã thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTable();
                if (addtable != null)
                    addtable(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void edittable_Click(object sender, EventArgs e)
        {
            string name = txttablename.Text;
            string trangthai = (cbstatustable.SelectedItem as TableDTO).Trangthai.ToString();
            int id = int.Parse(txttableid.Text);
            string hoatdong = txtbanhoatdong.Text;
            if (DAO.TableDAO.UpdateTable(name,trangthai,hoatdong,id))
            {
                MessageBox.Show("Bạn đã sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTable();
                if (updatetable != null)
                    updatetable(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btndeletetable_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txttableid.Text);
            if (DAO.TableDAO.StopActionTable(id))
            {
                MessageBox.Show("Bạn đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTable();
                if (deletetable != null)
                    deletetable(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Account
        private void LoadAccount()
        {
            bsAccount.DataSource = DAO.AccountDAO.GetListAccount();

            dgvaccount.Columns["tenhienthi"].HeaderText = "UserName";
            dgvaccount.Columns["tennguoidung"].HeaderText = "DisplayName";
            dgvaccount.Columns["loaitaikhoan"].HeaderText = "Quyền tài khoản";
        }

        private void btnviewaccount_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }

        private void BindingAccount()
        {
            txtusername.DataBindings.Add("Text", dgvaccount.DataSource, "tenhienthi", true, DataSourceUpdateMode.Never);
            txtdisplayname.DataBindings.Add("Text", dgvaccount.DataSource, "tennguoidung", true, DataSourceUpdateMode.Never);
            nmTypeAccount.DataBindings.Add("Value", dgvaccount.DataSource, "loaitaikhoan", true, DataSourceUpdateMode.Never);
        }

        private void btnaddaccount_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text;
            string displayname = txtdisplayname.Text;
            int Type = (int)nmTypeAccount.Value;

            if (DAO.AccountDAO.AddAccount(username, displayname,Type))
            {
                MessageBox.Show("Bạn đã thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAccount();
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btneditaccount_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text;
            string displayname = txtdisplayname.Text;
            int Type = (int)nmTypeAccount.Value;
            if (DAO.AccountDAO.UpdateAccount(username, displayname, Type))
            {
                MessageBox.Show("Bạn đã cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAccount();
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btndeleteaccount_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text;
            if (loginaccount.Username.Equals(username))
            {
                MessageBox.Show("Bạn không thể xóa tài khoản hiện hành", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DAO.AccountDAO.DeleteAccount(username))
            {
                MessageBox.Show("Bạn đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAccount();              
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnresetpass_Click(object sender, EventArgs e)
        {

            string username = txtusername.Text;

            if (DAO.AccountDAO.ResetPasswordAccount(username))
            {
                MessageBox.Show("Bạn đã đặt lại mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Thống kê
        void LoadDateTimePickerReport()
        {
            DateTime today = DateTime.Now;
            dtpNgayBD.Value = new DateTime(today.Year, today.Month, 1);
            dtpNgayKT.Value = dtpfromdate.Value.AddMonths(1).AddDays(-1);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ReportDTOBindingSource.DataSource = DAO.ReportDAO.GetListThongKe(dtpNgayBD.Value, dtpNgayKT.Value);
            this.rpBaoCao.RefreshReport();      
        }
    }
}
