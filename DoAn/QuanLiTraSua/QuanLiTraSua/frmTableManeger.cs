using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using DAO;
using System.Globalization;

namespace QuanLiTraSua
{
    public partial class frmTableManeger : Form
    {
        private AccountDTO account;

        public AccountDTO Account
        {
            get { return account; }
            set { account = value; }
        }
        float thanhtoan = 0;
        public frmTableManeger(AccountDTO acc)
        {
            InitializeComponent();      
            this.account = acc;
            ChangeAccount(account.Type);
            LoadTable();
            LoadCatagory();
            LoadComboTable(cbswitch);
        }

        void ChangeAccount(int type)
        {
            adminToolStripMenuItem.Enabled = type==1;
            thôngTinTàiKhoảnToolStripMenuItem.Text += "(" + account.Displayname + ")";
        }

        private void LoadCatagory()
        {
            List<CatagoryDTO> lst = CatagoryDAO.LoadLoaiThucAnChoCombo();
            cbLoaiThucAn.DataSource = lst;
            cbLoaiThucAn.ValueMember = "id";
            cbLoaiThucAn.DisplayMember = "tenloaithucan";
        }
        void LoadFoodByIDCatagory(int id)
        {
            List<FoodDTO> lst = FoodDAO.LoadFoodByIDCatagory(id);
            cbThucAn.DataSource = lst;
            cbThucAn.ValueMember = "id";
            cbThucAn.DisplayMember = "tenthucan";
        }
        private void cbLoaiThucAn_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            CatagoryDTO selected = cb.SelectedItem as CatagoryDTO;

            int id = selected.Id;

            LoadFoodByIDCatagory(id);
        }
        public void LoadTable()
        {
            flptable.Controls.Clear();
            List<TableDTO> lsttb = DAO.TableDAO.LoadTable();
            string s = "còn";
            foreach(TableDTO item in lsttb)
            {
                Button btn = new Button();
                btn.Width = DAO.TableDAO.tableheight;
                btn.Height = DAO.TableDAO.tableweight;
                btn.Text = item.Tenban + "\n" + item.Trangthai;
                btn.Click += btn_Click;
                btn.Tag = item;
                if (item.Trangthai == "Trống")
                {
                    btn.BackgroundImage = Properties.Resources.icons8_table_26;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                    btn.BackColor = Color.White;
                }
                else
                {
                    btn.BackgroundImage = Properties.Resources.icons8_ok_48;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                    btn.BackColor = Color.White;
                }
                if (item.Banhoatdong.ToLower() != s)
                {
                    btn.Enabled = false;
                    btn.BackColor = Color.Red;
                    btn.Text = "Ngưng hoạt động";
                }
                   
                flptable.Controls.Add(btn);
            }
        }

        void btn_Click(object sender, EventArgs e)
        {
            int idtable = ((sender as Button).Tag as TableDTO).ID;
            lsvBill.Tag = (sender as Button).Tag;
            lblBanHienHanh.Text = ((sender as Button).Tag as TableDTO).Tenban;
            Showbill(idtable);
        }

        private void Showbill(int id)
        {
            lsvBill.Items.Clear();
            txtTongTien.Text = "";
            float tongtien = 0;
            List<MenuDTO> lst = MenuDAO.GetListMenuByBillInfoID(id);
            //List<BillInfoDTO> lst = BillInfoDAO.GetListBillIfnfoByIDBill(BillDAO.GetUncheckedBillIDByTableID(id));
            foreach (MenuDTO item in lst)
            {
                ListViewItem lsvitem = new ListViewItem(item.Foodname.ToString());
                lsvitem.SubItems.Add(item.Count.ToString());
                lsvitem.SubItems.Add(item.Dongia.ToString());
                lsvitem.SubItems.Add(item.Thanhtien.ToString());
                tongtien += item.Thanhtien;
                CultureInfo culture = new CultureInfo("vi-VN");
                thanhtoan = tongtien;
                txtTongTien.Text = tongtien.ToString("c", culture);
                lsvBill.Items.Add(lsvitem);
              
            }
        }

        private void btnaddfood_Click(object sender, EventArgs e)
        {
            if (lsvBill.Tag == null)
            {
                MessageBox.Show("Hãy chọn bàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lsvBill.Items.Clear();
            TableDTO table = lsvBill.Tag as TableDTO;//mục đích: lấy id của bàn đang được chọn để thêm

            int idbill = BillDAO.GetUncheckedBillIDByTableID(table.ID);//từ id bàn => lấy được id của hóa đơn
            int idfood = (cbThucAn.SelectedItem as FoodDTO).Id;
            int count = (int)nmfoodcount.Value;

            if (idbill == -1)//case: chưa có hóa đơn, bàn còn trống
            {
                BillDAO.InsertBill(table.ID);
                //tham số idhoadon: hoa don them sau cung => co id la lon nhat
                //tham số id thức ăn: lấy từ combobox
                //tham số số lượng thức ăn lấy từ nmfoodcount
                BillInfoDAO.InsertBillInfo(BillDAO.GetMaxIdBill(), idfood, count);
            }
            else//case: hóa đơn đã tồn tại => sẽ thêm món mới hoặc cập nhật thêm số lượng món
                //kiểm tra món đã tồn tại hay chưa ta xử lí bên dưới server
            {
                BillInfoDAO.InsertBillInfo(idbill, idfood, count);
            }

            nmfoodcount.Value = 1;
            Showbill(table.ID);
            LoadTable();
        }
        void LoadComboTable(ComboBox cb)
        {
            cb.DataSource = TableDAO.LoadTableCombo();
            cb.DisplayMember = "tenban";
            cb.ValueMember = "id";

        }

        private void btncheckout_Click(object sender, EventArgs e)
        {
            if (lsvBill.Tag == null)
            {
                MessageBox.Show("Hãy chọn bàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TableDTO table = lsvBill.Tag as TableDTO;
            int idtable = table.ID;
            int idbill = BillDAO.GetUncheckedBillIDByTableID(idtable);
            int giamgia = (int)nmGiamGia.Value;
            //double TongTien = Convert.ToDouble(txtTongTien.Text.Split(',')[0]);
            //double TongTienGiamGia = TongTien - (TongTien/100)*giamgia;
            float TongTienGiamGia = thanhtoan - (thanhtoan / 100) * giamgia;
            if (idbill != -1)
            {
                if (MessageBox.Show(string.Format("Bạn có chắc thanh toán hóa đơn với số tiền là {0}-({1}/100)*{2} = {3}", thanhtoan, thanhtoan, giamgia, TongTienGiamGia), "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    BillDAO.CheckOut(idbill, giamgia, TongTienGiamGia);
                    Showbill(idtable);
                    LoadTable();
                }
            }
            nmGiamGia.Value = 0;
        }

        private void btnswitchtable_Click(object sender, EventArgs e)
        {
            if ((lsvBill.Tag as TableDTO) == null || (cbswitch.SelectedItem as TableDTO) == null)
            {
                MessageBox.Show("Hãy chọn bàn để chuyển bạn nhé", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idtable1 = (lsvBill.Tag as TableDTO).ID;
            int idtable2 = (cbswitch.SelectedItem as TableDTO).ID;

            
            if (MessageBox.Show(string.Format("Bạn chắc chuyển từ {0} sang {1}", (lsvBill.Tag as TableDTO).Tenban, (cbswitch.SelectedItem as TableDTO).Tenban),"Thông báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
                TableDAO.ChuyenBan(idtable1, idtable2);
            LoadTable();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAcountProfile f = new frmAcountProfile(account);
            f.ShowDialog();

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    
        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdmin f = new frmAdmin();
            //thức ăn
            f.Deletefood += f_Deletefood;
            f.Inssertfood += f_Inssertfood;
            f.Updatefood += f_Updatefood;
            //catagory
            f.Insertcatagory += f_Insertcatagory;
            f.Updatecatagory += f_Updatecatagory;
            f.Deletecatagory += f_Deletecatagory;
            //bàn ăn
            f.AddTable +=f_AddTable;
            f.UpdateTable += f_UpdateTable;
            f.DeleteTable += f_DeleteTable;
            f.loginaccount = account;
            f.ShowDialog();
        }

        void f_Deletecatagory(object sender, EventArgs e)
        {
            LoadCatagory();
        }


        void f_Updatecatagory(object sender, EventArgs e)
        {
            LoadCatagory();
        }

        void f_Insertcatagory(object sender, EventArgs e)
        {
            LoadCatagory();
        }

        void f_DeleteTable(object sender, EventArgs e)
        {
            LoadTable();
            LoadComboTable(cbswitch);
        }

        void f_UpdateTable(object sender, EventArgs e)
        {
            LoadTable();
            LoadComboTable(cbswitch);
        }

        void f_AddTable(object sender, EventArgs e)
        {
            LoadTable();
            LoadComboTable(cbswitch);
        }

        void f_Deletefood(object sender, EventArgs e)
        {
            LoadFoodByIDCatagory((cbLoaiThucAn.SelectedItem as CatagoryDTO).Id);
            if (lsvBill.Tag != null)
                Showbill((lsvBill.Tag as TableDTO).ID);
            LoadTable();
        }

        void f_Updatefood(object sender, EventArgs e)
        {
            LoadFoodByIDCatagory((cbLoaiThucAn.SelectedItem as CatagoryDTO).Id);
            if (lsvBill.Tag != null)
                Showbill((lsvBill.Tag as TableDTO).ID);
        }

        void f_Inssertfood(object sender, EventArgs e)
        {
            LoadFoodByIDCatagory((cbLoaiThucAn.SelectedItem as CatagoryDTO).Id);
            if (lsvBill.Tag != null)
                Showbill((lsvBill.Tag as TableDTO).ID);
        }

        private void thêmMónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnaddfood_Click(this, new EventArgs());
        }

        private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btncheckout_Click(this, new EventArgs());
        }

        private void chuyểnBànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnswitchtable_Click(this, new EventArgs());
        }

        private void giúpĐỡToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, System.IO.Path.Combine(Application.StartupPath, "FileHelp.chm"));
        }

        private void saoLưuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.Description = "Chọn thư mục bạn cần lưu";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                string path = fd.SelectedPath;
                try
                {
                    DAO.CSDLDAO.SaoLuuDuLieu(path);
                    MessageBox.Show("Sao lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch{
                      MessageBox.Show("Sao lưu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }     
            }   
        }

        private void phụcHồiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "*.bak|*.bak";
            op.Title = "Bạn hãy chọn file cần phục hồi";
            if (op.ShowDialog() == DialogResult.OK && op.CheckFileExists == true)
            {
                string path = op.FileName;
                try
                {
                    DAO.CSDLDAO.PhucHoiDuLieu(path);
                    MessageBox.Show("Phục hồi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTable();
                }
                catch
                {
                    MessageBox.Show("Phục hồi thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }    
                
            }
        }

    }
}
