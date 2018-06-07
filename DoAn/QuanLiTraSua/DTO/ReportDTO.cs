using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ReportDTO
    {
        private DateTime datecheckout;

        public DateTime Datecheckout
        {
            get { return datecheckout; }
            set { datecheckout = value; }
        }
        private DateTime datecheckin;

        public DateTime Datecheckin
        {
            get { return datecheckin; }
            set { datecheckin = value; }
        }
        private float totalprice;

        public float Totalprice
        {
            get { return totalprice; }
            set { totalprice = value; }
        }

        private int discount;

        public int Discount
        {
            get { return discount; }
            set { discount = value; }
        }
       
        private string nametable;

        public string Nametable
        {
            get { return nametable; }
            set { nametable = value; }
        }

    }
}
