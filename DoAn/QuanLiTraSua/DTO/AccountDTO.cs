using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AccountDTO
    {
        //public AccountDTO(string username, string displayname, string passwword, int type)
        //{
        //    this.username = username;
        //    this.displayname = displayname;
        //    this.password = passwword;
        //    this.type = type;
        //}


        private int type;

        public int Type
        {
            get { return type; }
            set { type = value; }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private string displayname;

        public string Displayname
        {
            get { return displayname; }
            set { displayname = value; }
        }
        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
    }
}
