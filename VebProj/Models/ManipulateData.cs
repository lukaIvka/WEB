using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace VebProj.Models
{
    public class ManipulateData
    {
        public static void IspitiZaProfu(Ispit i) {
            string pathIspiti = "C:/Users/User/Desktop/Veb - Veb programiranje u infrastrukturnim sistemima/projekat/VebProj/VebProj/App_Data/Ispiti.csv";
            List<Ispit> ispiti = (List<Ispit>)HttpContext.Current.Application["listaIspita"];
            string rez = "";            
            using (StreamWriter sw = new StreamWriter(pathIspiti))
            {
                ispiti.Add(i);
                for (int b = 0; b <= ispiti.Count(); b++)
                {
                    if ((b+1) == ispiti.Count())
                    {
                        rez += ispiti[b].ToString();
                        break;
                    }
                    rez += ispiti[b].ToString() +"\n";
                }
                sw.Write(rez);
            }            
        }

        public static void ModifikacijeZaAdmina(List<Student>s)
        {
            string pathStudenti = "C:/Users/User/Desktop/Veb - Veb programiranje u infrastrukturnim sistemima/projekat/VebProj/VebProj/App_Data/Student.csv";
            string rez = "";
            using (StreamWriter sw = new StreamWriter(pathStudenti))
            {
                for (int b = 0; b <= s.Count(); b++)
                {
                    if ((b + 1) == s.Count())
                    {
                        rez += s[b].ToString();
                        break;
                    }
                    rez += s[b].ToString() + "\n";
                }
                sw.Write(rez);
            }
        }

        public static void ModifikacijeRezultata(List<Rezultati> rezultati)
        {
            string pathRezultati = "C:/Users/User/Desktop/Veb - Veb programiranje u infrastrukturnim sistemima/projekat/VebProj/VebProj/App_Data/Rezultati.csv";
            string rez = "";
            int b = 0;
            using (StreamWriter sw = new StreamWriter(pathRezultati))
            {
                foreach (Rezultati r in rezultati)
                {
                    if ((b + 1) == rezultati.Count())
                    {
                        rez += r.ToString();
                        break;
                    }
                    rez += r.ToString() + "\n";
                    b++;
                }
                sw.Write(rez);
            }
        }
    }
}