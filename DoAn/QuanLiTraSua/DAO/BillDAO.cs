using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAO
{

    public class BillDAO
    {
        public static int GetUncheckedBillIDByTableID(int id)//id từ bàn ăn
        {
            DataTable dt = DataProvider.ExecuteQuery("SELECT * FROM dbo.HoaDon WHERE idbanan = " + id + "AND thanhtoan = 0");
            if (dt.Rows.Count > 0)
            {
                BillDTO bill = new BillDTO();
                foreach (DataRow r in dt.Rows)
                {
                    bill.Id = (int)r["id"];
                    bill.Datecheckin = (DateTime?)r["ngayvao"];
                    var check = r["ngayra"];
                    if (check.ToString() != "")
                        bill.Datecheckout = (DateTime?)check;
                    bill.Idtable = (int)r["idbanan"];
                    bill.Status = (int)r["thanhtoan"];
                    return bill.Id;//=>lấy được id của hóa đơn mà 
                    //bàn ăn đang được chọn mà chưa thanh toán 
                }
            }
            return -1;
        }
        public static void InsertBill(int idbanan)
        {
            DataProvider.ExecuteNonQuery("EXEC InsertBill @idbanan", new object[] { idbanan });
        }

        public static int GetMaxIdBill()
        {
            try
            {
                return (int)DataProvider.ExecuteScalar("SELECT MAX(id) FROM dbo.HoaDon");
            }
            catch
            {
                return 1;
            }
        }

        public static void CheckOut(int idBill, int GiamGia,float tongtien)
        {
            string query = "UPDATE dbo.HoaDon SET ngayra = GETDATE(), thanhtoan = 1" + ", giamgia = " + GiamGia + ", tongtien = " + tongtien + " WHERE id = " + idBill;
            DataProvider.ExecuteNonQuery(query);

        }

        public static DataTable GetListBillDate(DateTime ngayvao, DateTime ngayra)
        {
            return DataProvider.ExecuteQuery("EXEC dbo.GetListBillByDate @ngayvao , @ngayra", new object[] { ngayvao, ngayra });
        }
    }
}
