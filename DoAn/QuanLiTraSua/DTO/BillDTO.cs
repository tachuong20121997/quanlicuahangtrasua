using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BillDTO
    {
        private int giamgia;

        public int Giamgia
        {
            get { return giamgia; }
            set { giamgia = value; }
        }
        private int status;

        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        private int idtable;

        public int Idtable
        {
            get { return idtable; }
            set { idtable = value; }
        }
        private DateTime? datecheckout;

        public DateTime? Datecheckout
        {
            get { return datecheckout; }
            set { datecheckout = value; }
        }

        private DateTime? datecheckin;

        public DateTime? Datecheckin
        {
            get { return datecheckin; }
            set { datecheckin = value; }
        }
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

    }

}
