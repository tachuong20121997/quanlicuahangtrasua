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

namespace QuanLiTraSua
{
    public partial class frmAcountProfile : Form
    {
        private AccountDTO account;

        public AccountDTO Account
        {
            get { return account; }
            set { account = value; }
        }

        public frmAcountProfile(AccountDTO acc)
        {
            InitializeComponent();
            this.account = acc;
            ChangeLogin();
        }

        void ChangeLogin()
        {
            txtlogin.Enabled = false;
            txtlogin.Text = account.Username;
            txtdisplayname.Text = account.Displayname;
        }

        void UpDate()
        {
            string username = txtlogin.Text;
            string displayname = txtdisplayname.Text;
            string pass = txtpass.Text;
            string pass2 = txtMatKhauMoi.Text;
            string nhaplai = txtNhapLai.Text;

            if (displayname == "")
            {
                MessageBox.Show("hãy nhập đầy đủ tên hiển thị", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtdisplayname.Focus();
                return;
            }
            else if (pass == "")
            {
                MessageBox.Show("hãy nhập đầy đủ mật khẩu", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtpass.Focus();
                return;
            }
            else if (pass2 == "")
            {
                MessageBox.Show("hãy nhập đầy đủ mật khẩu", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtMatKhauMoi.Focus();
                return;
            }
            else if (nhaplai == "")
            {
                MessageBox.Show("hãy nhập đầy đủ mật khẩu", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtNhapLai.Focus();
                return;
            }

            if (!account.Password.Equals(pass))
            {
                MessageBox.Show("Mật khẩu không chính xác", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtpass.Focus();
                return;
            }

            if (!nhaplai.Equals(pass2))
            {
                MessageBox.Show("Xác nhận mật khẩu không chính xác", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtNhapLai.Focus();
                return;
            }

            if (AccountDAO.UpDateAccount(username, displayname, pass, pass2))
            {
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Xác nhận mật khẩu không chính xác", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            UpDate();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

    }
}
