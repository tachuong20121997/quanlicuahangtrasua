using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAO
{
    public class CatagoryDAO
    {
        public static List<CatagoryDTO> LoadLoaiThucAn()
        {
            List<CatagoryDTO> lst = new List<CatagoryDTO>();
            DataTable dt = DataProvider.ExecuteQuery("SELECT * FROM dbo.LoaiThucAn WHERE trangthai = N'Còn'");

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    lst.Add(new CatagoryDTO
                    {
                        Id = (int)r["id"],
                        Tenloaithucan = r["tenloaithucan"].ToString(),
                        Trangthai = r["trangthai"].ToString()
                    });
                }
            }
            return lst;
        }

        public static List<CatagoryDTO> LoadLoaiThucAnChoCombo()
        {
            List<CatagoryDTO> lst = new List<CatagoryDTO>();
            DataTable dt = DataProvider.ExecuteQuery("SELECT * FROM dbo.LoaiThucAn where trangthai = N'Còn'");

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    lst.Add(new CatagoryDTO
                    {
                        Id = (int)r["id"],
                        Tenloaithucan = r["tenloaithucan"].ToString(),
                        Trangthai = r["trangthai"].ToString()
                    });
                }
            }
            return lst;
        }


        public static CatagoryDTO GetCatagoryById(int idcatagory)
        {
           DataTable dt = DataProvider.ExecuteQuery("EXEC dbo.GetCatagoryById @idcatagory", new object[] { idcatagory });
           if (dt.Rows.Count > 0)
           {
               CatagoryDTO cata = new CatagoryDTO();
               foreach (DataRow r in dt.Rows)
               {
                   cata.Id = (int)r["id"];
                   cata.Tenloaithucan = r["Tenloaithucan"].ToString();
                   cata.Trangthai = r["trangthai"].ToString();
                   return cata;
               }
           }
           return null;
        }

        public static bool AddCatagory(string namecatagory, string trangthai)
        {
            string truyvan = String.Format("INSERT dbo.LoaiThucAn( tenloaithucan, trangthai ) VALUES ( N'{0}',N'{1}')", namecatagory, trangthai);
            int kq = (int)DataProvider.ExecuteNonQuery(truyvan);
            return kq > 0;
        }

        public static bool EditCatagory(string namecatagory, string trangthai, int id)
        {
            string truyvan = String.Format("UPDATE dbo.LoaiThucAn SET tenloaithucan = N'{0}', trangthai = N'{1}' WHERE id = {2}", namecatagory,trangthai,id);
            int kq = (int)DataProvider.ExecuteNonQuery(truyvan);
            return kq > 0;
        }

        public static bool DeleteCatagory(int id)
        {
           // DAO.FoodDAO.DeleteFoodByIdCatagory(id);
            string truyvan = String.Format("UPDATE dbo.LoaiThucAn SET trangthai = N'hết' WHERE id = {0}", id);
            int kq = (int)DataProvider.ExecuteNonQuery(truyvan);
            return kq > 0;
        }
    }
}
