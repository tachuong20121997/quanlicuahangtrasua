using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CatagoryDTO
    {
        private string trangthai;

        public string Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }
        string tenloaithucan;

        public string Tenloaithucan
        {
            get { return tenloaithucan; }
            set { tenloaithucan = value; }
        }
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
