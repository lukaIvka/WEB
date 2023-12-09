using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VebProj.Models
{
    public class Ispit
    {
        public string profesor { get; set; }
        public string predmet { get; set; }
        public string datum { get; set; }
        public string ucionica { get; set; }
        public string rok { get; set; }
        public Ispit(string profesor, string predmet, string datum,
            string ucionica, string rok)
        {
            this.profesor = profesor;
            this.predmet = predmet;
            this.datum = datum;
            this.ucionica = ucionica;
            this.rok = rok;
        }

        public Ispit()
        {
            this.profesor = null;
            this.predmet = "";
            this.datum = "";
            this.ucionica = "";
            this.rok = "";
        }

        public override string ToString()
        {
            return profesor+ "," + predmet + "," + datum + "," + ucionica + "," + rok ;
        }
    }
}