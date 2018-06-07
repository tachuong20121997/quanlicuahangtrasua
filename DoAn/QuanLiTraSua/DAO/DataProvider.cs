using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class DataProvider
    {

        private static string ketnoi = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=QuanLiTraSua;Integrated Security=True";
  
        public static DataTable ExecuteQuery(string truyvan, object[] parameter = null)
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(ketnoi);

                conn.Open();
                SqlCommand cm = new SqlCommand(truyvan, conn);
                if (parameter != null)
                {
                    string[] listpara = truyvan.Split(' ');
                    int i = 0;
                    foreach (string item in listpara)
                    {
                        if (item.Contains('@'))
                        {
                            cm.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter da = new SqlDataAdapter(cm);
                da.Fill(dt);
                conn.Close();
                return dt;
        }

        public static object ExecuteNonQuery(string truyvan, object[] parameter = null)
        {
                object data = 0;
                SqlConnection conn = new SqlConnection(ketnoi);
                conn.Open();
                SqlCommand cm = new SqlCommand(truyvan, conn);
                if (parameter != null)
                {
                    string[] listpara = truyvan.Split(' ');
                    int i = 0;
                    foreach (string item in listpara)
                    {
                        if (item.Contains('@'))
                        {
                            cm.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = cm.ExecuteNonQuery();
                conn.Close();
                return data; 
        }

        public static object ExecuteScalar(string truyvan, object[] parameter = null)
        {
            object data = 0;
           SqlConnection conn = new SqlConnection(ketnoi);

                conn.Open();
                SqlCommand cm = new SqlCommand(truyvan, conn);
                if (parameter != null)
                {
                    string[] listpara = truyvan.Split(' ');
                    int i = 0;
                    foreach (string item in listpara)
                    {
                        if (item.Contains('@'))
                        {
                            cm.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = cm.ExecuteScalar();
                conn.Close();
                return data;
         
        }

    }
}
