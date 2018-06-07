using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class CSDLDAO
    {
        public static void SaoLuuDuLieu(string path)
        {
            string ten = "\\QuanLiTraSua(" + DateTime.Now.Day.ToString() + "_"
                                        + DateTime.Now.Month.ToString() + "_"
                                        + DateTime.Now.Year.ToString() + "_"
                                        + DateTime.Now.Hour.ToString() + "_"
                                        + DateTime.Now.Minute.ToString() + ").bak";

            string sql = "backup database QuanLiTraSua to disk = N'" + path + ten + "'";

          DataProvider.ExecuteNonQuery(sql);

        }

        public static void PhucHoiDuLieu(string path)
        {
            string sql = "use master alter database [QuanLiTraSua] set Single_User with Rollback Immediate Restore database [QuanLiTraSua] from disk = N'" + path + "' with replace alter database [QuanLiTraSua] set Multi_User";
            DataProvider.ExecuteNonQuery(sql);
        }
    }
}
