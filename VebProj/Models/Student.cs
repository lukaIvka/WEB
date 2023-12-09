using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VebProj.Models
{
    public class Student
    {
        public string userName { get; set; }       
        public string indexNum { get; set; }
        public string password { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string datumRodjenja { get; set; }
        public string email { get; set; }
        public List<Ispit> prijavljeni = new List<Ispit>();
        public List<Ispit> polozeni = new List<Ispit>();
        public List<Ispit> nepolozeni = new List<Ispit>();

        public Student(string userName, string indexNum, string password, string ime, string prezime, string datumRodjenja, string email)
        {
            this.userName = userName;
            this.indexNum = indexNum;
            this.password = password;
            this.ime = ime;
            this.prezime = prezime;
            this.datumRodjenja = datumRodjenja;
            this.email = email;
            
        }
        
        public Student()
        {
            this.userName = "";
            this.indexNum = "";
            this.password = "";
            this.ime = "";
            this.prezime = "";
            this.datumRodjenja = "";
            this.email = "";
            
        }

        public override string ToString()
        {
            return userName +"," +indexNum+"," +password+"," +ime+"," +prezime+"," +datumRodjenja+"," +email;
        }
    }
}