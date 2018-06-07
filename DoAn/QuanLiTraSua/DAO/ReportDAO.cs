using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ReportDAO
    {
        public static List<ReportDTO> GetListThongKe(DateTime ngayvao, DateTime ngayra)
        {
            List<ReportDTO> lst = new List<ReportDTO>();
            string truyvan = "EXEC dbo.GetListBillByDateReport @ngayvao , @ngayra ";
            DataTable dt = DataProvider.ExecuteQuery(truyvan, new object[] { ngayvao, ngayra });
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    lst.Add(new ReportDTO
                    {
                        Nametable = r["tenban"].ToString(),                     
                        Discount = int.Parse(r["giamgia"].ToString()),
                        Totalprice = float.Parse(r["tongtien"].ToString()),
                        Datecheckin = DateTime.Parse(r["ngayvao"].ToString()),
                        Datecheckout = DateTime.Parse(r["ngayra"].ToString())
                    });
                }
            }
            return lst;
        }
    }
}
