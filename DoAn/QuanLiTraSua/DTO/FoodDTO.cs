using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class FoodDTO
    {
        private string trangthai;

        public string Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }
        private float gia;

        public float Gia
        {
            get { return gia; }
            set { gia = value; }
        }
        private int idloaithucan;

        public int Idloaithucan
        {
            get { return idloaithucan; }
            set { idloaithucan = value; }
        }
        private string tenthucan;

        public string Tenthucan
        {
            get { return tenthucan; }
            set { tenthucan = value; }
        }
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
