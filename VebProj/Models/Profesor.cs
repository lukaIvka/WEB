using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VebProj.Models
{
    public class Profesor
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string datumRodjenja { get; set; }
        public string email { get; set; }
        public List<string> predmeti = new List<string>();
        public List<Ispit> ispiti = new List<Ispit>();

        public Profesor(string userName, string password, string ime, string prezime,
            string datumRodjenja, string email)
        {
            this.userName = userName;
            this.password = password;
            this.ime = ime;
            this.prezime = prezime;
            this.datumRodjenja = datumRodjenja;
            this.email = email;
           
        }

        public Profesor()
        {
            this.userName = "";
            this.password = "";
            this.ime = "";
            this.prezime = "";
            this.datumRodjenja = "";
            this.email = "";
        }
    }
}