using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAO
{
    public class MenuDAO
    {
        public static List<MenuDTO> GetListMenuByBillInfoID(int id)
        {
            List<MenuDTO> lst = new List<MenuDTO>();
            string query = @"SELECT tenthucan,soluong,gia, soluong*gia AS 'thanhtien' FROM dbo.ThucAn, dbo.HoaDon, dbo.ChiTietHoaDon 
WHERE dbo.ThucAn.id = dbo.ChiTietHoaDon.idthucan 
AND dbo.HoaDon.id = dbo.ChiTietHoaDon.idhoadon AND thanhtoan = 0 AND dbo.HoaDon.idbanan =" + id;
            DataTable dt = DataProvider.ExecuteQuery(query);
             if (dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    lst.Add(new MenuDTO{
                        Foodname = r["tenthucan"].ToString(),
                        Count = (int)r["soluong"],
                        Dongia = (float)Double.Parse(r["gia"].ToString()),
                        Thanhtien = (float)Double.Parse(r["thanhtien"].ToString())
                    });   
                }
            }
             return lst;
        }
    }
}
