using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Security.Cryptography;

namespace DAO
{
    public class AccountDAO
    {

        public static bool Login(string username, string password)
        {

            string truyvan = "EXEC USP_Accuont @username , @password";
            DataTable kq = DataProvider.ExecuteQuery(truyvan, new object[] { username, password });
            return kq.Rows.Count > 0;
        }

        public static bool UpDateAccount(string username, string dislayname, string pass1, string pass2)
        {
            int kq = (int)DataProvider.ExecuteNonQuery("EXEC dbo.UpdateAccount @username , @displayname , @pass1 , @pass2", new object[] {username, dislayname, pass1, pass2});
            return kq > 0;
        }

        public static AccountDTO GetAccountByUserName(string username)
        {
            DataTable dt = DataProvider.ExecuteQuery("EXEC dbo.GetAccountByUsername @username", new object[] {username});
            if (dt.Rows.Count > 0)
            {
                AccountDTO account = new AccountDTO();
                foreach (DataRow r in dt.Rows)
                {
                    account.Username = r["tenhienthi"].ToString();
                    account.Displayname = r["tennguoidung"].ToString();
                    account.Password = r["matkhau"].ToString();
                    account.Type = (int)r["loaitaikhoan"];
                    return account;
                }
            }
            return null;
        }

        public static List<AccountDTO> LoadAccount()
        {
            string truyvan = "SELECT * FROM dbo.Account";
            DataTable dt = DataProvider.ExecuteQuery(truyvan);
            List<AccountDTO> lst = new List<AccountDTO>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    lst.Add(new AccountDTO{
                        Username = r["tenhienthi"].ToString(),
                        Displayname = r["tennguoidung"].ToString(),
                        Password = r["matkhau"].ToString(),
                        Type = (int)r["loaitaikhoan"]    
                    });
                }
                return lst;
            }
            return null;
        }

        public static DataTable GetListAccount()
        {
            return  DataProvider.ExecuteQuery("SELECT tenhienthi,tennguoidung,loaitaikhoan FROM dbo.Account");
        }


        public static bool AddAccount(string username, string displayname, int type)
        {
            string truyvan = string.Format("INSERT dbo.Account(tenhienthi, tennguoidung ,loaitaikhoan) VALUES ( N'{0}',N'{1}',{2})", username, displayname, type);
            int kq = (int)DataProvider.ExecuteNonQuery(truyvan);
            return kq > 0;
        }

        public static bool UpdateAccount(string username, string displayname, int type)
        {
            string truyvan = string.Format("UPDATE dbo.Account SET tennguoidung = N'{0}', loaitaikhoan = {1} WHERE tenhienthi = N'{2}'", displayname, type, username);
            int kq = (int)DataProvider.ExecuteNonQuery(truyvan);
            return kq > 0;
        }

        public static bool DeleteAccount(string username)
        {
            string truyvan = string.Format("DELETE dbo.Account WHERE tenhienthi = N'{0}'", username);
            int kq = (int)DataProvider.ExecuteNonQuery(truyvan);
            return kq > 0;
        }

        public static bool ResetPasswordAccount(string username)
        {
            string truyvan = string.Format("UPDATE dbo.Account SET matkhau = N'0' WHERE tenhienthi = N'{0}'", username);
            int kq = (int)DataProvider.ExecuteNonQuery(truyvan);
            return kq > 0;
        }
    }
}

