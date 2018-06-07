using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;


namespace DAO
{
    public class TableDAO
    {
        public static int tableweight = 100;
        public static int tableheight = 100;
        public static List<TableDTO> LoadTable()
        {
            List<TableDTO> lsttb = new List<TableDTO>();
            //lấy datatable
            DataTable dt = DataProvider.ExecuteQuery("EXEC USP_Table");
            //chuyển dt-> list tabledto
            foreach(DataRow r in dt.Rows)
            {
                lsttb.Add(new TableDTO
                {
                    ID = int.Parse(r["id"].ToString()),
                    Tenban = r["tenban"].ToString(),
                    Trangthai = r["trangthai"].ToString(),
                    Banhoatdong = r["banhoatdong"].ToString()
                });
            }
            return lsttb;
        }

        public static List<TableDTO> LoadTableCombo()
        {
            List<TableDTO> lsttb = new List<TableDTO>();
            string truyvan = "SELECT * FROM dbo.BanAn WHERE banhoatdong = N'Còn'";
            //lấy datatable
            DataTable dt = DataProvider.ExecuteQuery(truyvan);
            //chuyển dt-> list tabledto
            foreach (DataRow r in dt.Rows)
            {
                lsttb.Add(new TableDTO
                {
                    ID = int.Parse(r["id"].ToString()),
                    Tenban = r["tenban"].ToString(),
                    Trangthai = r["trangthai"].ToString(),
                    Banhoatdong = r["banhoatdong"].ToString()
                });
            }
            return lsttb;
        }



        public static void ChuyenBan(int idtable1, int idtable2)
        {
            DataProvider.ExecuteQuery("EXEC ChuyenBan @idtable1 , @idtable2", new object[] { idtable1, idtable2});
        }


        public static TableDTO GetTableById(int id)
        {
            string truyvan = string.Format("SELECT * FROM dbo.BanAn WHERE id = {0}", id);
            DataTable dt = DataProvider.ExecuteQuery(truyvan);
            if (dt.Rows.Count > 0)
            {
                TableDTO table = new TableDTO();
                foreach (DataRow r in dt.Rows)
                {
                    table.ID = (int)r["id"];
                    table.Tenban = r["tenban"].ToString();
                    table.Trangthai = r["trangthai"].ToString();
                    table.Banhoatdong = r["banhoatdong"].ToString();
                    return table;
                }
            }
            return null;
        }
        public static bool AddTable(string nametable)
        {
            string truyvan = String.Format("INSERT dbo.BanAn (tenban) VALUES (N'{0}')", nametable);
            int kq = (int)DataProvider.ExecuteNonQuery(truyvan);
            return kq > 0;
        }

         public static bool UpdateTable(string nametable, string trangthai,string hoatdong, int id)
        {
            string truyvan = String.Format("UPDATE dbo.BanAn SET tenban = N'{0}', trangthai = N'{1}', banhoatdong = N'{2}' WHERE id = {3}", nametable, trangthai, hoatdong, id);
            int kq = (int)DataProvider.ExecuteNonQuery(truyvan);
            return kq > 0;
        }

         public static bool StopActionTable(int id)
         {
             string truyvan = String.Format("UPDATE dbo.BanAn SET banhoatdong = N'Ngừng' WHERE id = {0}", id);
             int kq = (int)DataProvider.ExecuteNonQuery(truyvan);
             return kq > 0;
         }
    }
}
