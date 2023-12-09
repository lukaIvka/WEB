using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VebProj.Models
{
    public class Admin
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string datumRodjenja { get; set; }
        public Admin(string userName, string password, string ime, string prezime, string datumRodjenja)
        {
            this.userName = userName;
            this.password = password;
            this.ime = ime;
            this.prezime = prezime;
            this.datumRodjenja = datumRodjenja;
        }

        public Admin()
        {
            this.userName = "";
            this.password = "";
            this.ime = "";
            this.prezime = "";
            this.datumRodjenja = "";
        }
    
    
    
    }
}