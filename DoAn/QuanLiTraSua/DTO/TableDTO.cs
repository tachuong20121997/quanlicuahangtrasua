using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TableDTO
    {
        //public TableDTO(int id, string tenban, string trangthai)
        //{
        //    this.ID = id;
        //    this.Tenban = tenban;
        //    this.Trangthai = trangthai; 
        //}


        //public TableDTO(DataRow r)
        //{
        //    this.ID = (int)r["id"];
        //    this.Tenban = r["tenban"].ToString();
        //    this.Trangthai = r["trangthai"].ToString();
        //}
        private string banhoatdong;

        public string Banhoatdong
        {
            get { return banhoatdong; }
            set { banhoatdong = value; }
        }

        private string trangthai;

        public string Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }
        private string tenban;

        public string Tenban
        {
            get { return tenban; }
            set { tenban = value; }
        }
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
    }
}
