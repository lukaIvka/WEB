using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VebProj.Models
{
    public class Rezultati
    {
        public Ispit ispit { get; set; }
        public Student student { get; set; }
        public int ocjena { get; set; }
        public Rezultati(Ispit ispit, Student student, int ocjena)
        {
            this.ispit = ispit;
            this.student = student;
            this.ocjena = ocjena;
        }

        public Rezultati()
        {
            ispit = null;
            student = null;
            ocjena = 5;
        }

        public override string ToString()
        {
            return ispit.profesor+","+ispit.predmet+"," +ispit.rok+","+student.indexNum+","+ocjena.ToString();
        }
    }
}