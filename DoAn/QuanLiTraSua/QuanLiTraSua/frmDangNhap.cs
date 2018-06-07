using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework.Forms;
using DAO;
using DTO;
using System.Windows.Forms;

namespace QuanLiTraSua
{
    public partial class frmDangNhap : MetroForm
    {

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtlogin.Text == "" || txtpass.Text == "")
            {
                MessageBox.Show("Xin điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtlogin.Focus();
            }
            else
            {
                string username = txtlogin.Text;
                string password = txtpass.Text;
                if (AccountDAO.Login(username, password))
                {
                    AccountDTO login = AccountDAO.GetAccountByUserName(username);
                    frmTableManeger f = new frmTableManeger(login);
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    txtlogin.Focus();
                }
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Bạn có muốn thoát khỏi chương trình không", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                Application.Exit();
        }

        private void mtbtnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtlogin.Text == "" || txtpass.Text == "")
            {
                MessageBox.Show("Xin điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtlogin.Focus();
            }
            else
            {
                string username = txtlogin.Text;
                string password = txtpass.Text;
                if (AccountDAO.Login(username, password))
                {
                    AccountDTO login = AccountDAO.GetAccountByUserName(username);
                    frmTableManeger f = new frmTableManeger(login);
                    this.Hide();
                    f.ShowDialog();
                    txtpass.Text = "";
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    txtlogin.Focus();
                }
            }
        }

        private void mtbtnThoat_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Bạn có muốn thoát khỏi chương trình không", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                Application.Exit();
        }
    }
}
