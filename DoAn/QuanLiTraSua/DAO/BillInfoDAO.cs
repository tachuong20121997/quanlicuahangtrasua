using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAO
{
    public class BillInfoDAO
    {
        public static List<BillInfoDTO> GetListBillIfnfoByIDBill(int id)//id của hóa đơn
        {
            List<BillInfoDTO> lst = new List<BillInfoDTO>();

            DataTable dt = DataProvider.ExecuteQuery("SELECT * FROM ChiTietHoaDon WHERE idhoadon = " + id);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    lst.Add(new BillInfoDTO
                    {
                        Id = (int)r["id"],
                        Idbill = (int)r["idhoadon"],
                        Idfood = (int)r["idthucan"],
                        Count = (int)r["soluong"]
                    }
                    );
                }
            }
            return lst;
        }

        public static void InsertBillInfo(int idhoadon, int idthucan, int soluong)
        {
            DataProvider.ExecuteNonQuery("EXEC InsertBillInfo @idhoadon , @idthucan , @soluong", new object[] {idhoadon, idthucan,soluong });
        }

        public static void DeleteBillInfoByIdFood(int idfood)
        {
            string truyvan = string.Format("DELETE dbo.ChiTietHoaDon WHERE idthucan = {0}", idfood);
            DataProvider.ExecuteNonQuery(truyvan);
        }
    


    }


}
