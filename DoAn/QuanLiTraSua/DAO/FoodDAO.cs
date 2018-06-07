
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAO
{
    public class FoodDAO
    {
        public static List<FoodDTO> LoadFoodByIDCatagory(int id)
        {
            List<FoodDTO> lst = new List<FoodDTO>();

            DataTable dt = DataProvider.ExecuteQuery("SELECT * FROM dbo.ThucAn WHERE trangthai = N'Còn' AND idloaithucan = " 
                + id +"ORDER BY tenthucan");

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    lst.Add(new FoodDTO { 
                        Id = (int)r["id"],
                        Tenthucan = r["tenthucan"].ToString(),
                        Idloaithucan = (int)r["idloaithucan"],
                        Gia = (float)Double.Parse(r["gia"].ToString()),
                        Trangthai = r["trangthai"].ToString()
                    });
                }
            }
            return lst;
        }

        public static List<FoodDTO> LoadFood()
        {
            List<FoodDTO> lst = new List<FoodDTO>();

            DataTable dt = DataProvider.ExecuteQuery("SELECT * FROM dbo.ThucAn");

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    lst.Add(new FoodDTO
                    {
                        Id = (int)r["id"],
                        Tenthucan = r["tenthucan"].ToString(),
                        Idloaithucan = (int)r["idloaithucan"],
                        Gia = (float)Double.Parse(r["gia"].ToString()),
                        Trangthai = r["trangthai"].ToString()
                    });
                }
            }
            return lst;
        }

        public static bool AddFood(string name, int idcatagory, float price)
        {
            string truyvan = string.Format("INSERT dbo.ThucAn( tenthucan, idloaithucan, gia ) VALUES (N'{0}', {1}, {2})", name, idcatagory, price);
            int kq = (int)DataProvider.ExecuteNonQuery(truyvan);
            return kq > 0;
        }

        public static bool UpdateFood(string name, int idcatagory, float price, int id, string trangthai)
        {
            string truyvan = string.Format("UPDATE dbo.ThucAn SET tenthucan = N'{0}', idloaithucan = {1}, gia = {2}, trangthai =  N'{3}' WHERE id = {4} ", name, idcatagory, price, trangthai, id);
            int kq = (int)DataProvider.ExecuteNonQuery(truyvan);
            return kq > 0;
        }

        public static bool DeleteFoodByIdFood(int idfood)
        {
            DAO.BillInfoDAO.DeleteBillInfoByIdFood(idfood);
            string truyvan = string.Format("UPDATE dbo.ThucAn SET trangthai = N'Hết' WHERE id = {0}", idfood);
            int kq = (int)DataProvider.ExecuteNonQuery(truyvan);
            return kq > 0;
        }

        public static List<FoodDTO> SearchFoodByName(string name)
        {
            List<FoodDTO> lst = new List<FoodDTO>();
            string truyvan = string.Format("SELECT * FROM dbo.ThucAn WHERE dbo.fuConvertToUnsign1(tenthucan) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", name);
            DataTable dt = DataProvider.ExecuteQuery(truyvan);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    lst.Add(new FoodDTO
                    {
                        Id = (int)r["id"],
                        Tenthucan = r["tenthucan"].ToString(),
                        Idloaithucan = (int)r["idloaithucan"],
                        Gia = (float)Double.Parse(r["gia"].ToString()),
                        Trangthai = r["trangthai"].ToString()
                    });               
                }
                return lst;
            }
            return null;
        }


        public static bool DeleteFood(int id)
        {
            string truyvan = string.Format("UPDATE	dbo.ThucAn SET trangthai = N'hết' WHERE id = {0}", id);
            int kq = (int)DataProvider.ExecuteNonQuery(truyvan);
            return kq > 0;
        }
    }


}
