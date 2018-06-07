using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BillInfoDTO
    {
        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        private int idfood;

        public int Idfood
        {
            get { return idfood; }
            set { idfood = value; }
        }
        private int idbill;

        public int Idbill
        {
            get { return idbill; }
            set { idbill = value; }
        }
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
