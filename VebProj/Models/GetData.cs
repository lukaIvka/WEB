using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace VebProj.Models
{
    public class GetData
    {
        public static List<Student> GetStudents(string path)
        {
            List<Student> students = new List<Student>();
            string[] niz = File.ReadAllLines(path);
            foreach (string linija in niz)
            {
                Student s = new Student();
                string[] dijelovi = linija.Split(',');
                s.userName = dijelovi[0];
                s.indexNum = dijelovi[1];
                s.password = dijelovi[2];
                s.ime = dijelovi[3];
                s.prezime = dijelovi[4];
                s.datumRodjenja = dijelovi[5];
                s.email = dijelovi[6];
                students.Add(s);
            }
            
            return students;
        }

        public static List<Profesor> GetProfesors(string path)
        {
            List<Profesor> profesori = new List<Profesor>();
            string[] niz = File.ReadAllLines(path);
            foreach (string linija in niz)
            {
                Profesor p = new Profesor();
                string[] dijelovi = linija.Split(',');
                p.userName = dijelovi[0];
                p.password = dijelovi[1];
                p.ime = dijelovi[2];
                p.prezime = dijelovi[3];
                p.datumRodjenja = dijelovi[4];
                p.email = dijelovi[5];
                string []predmeti = dijelovi[6].Split(' ');
                foreach (string s in predmeti)
                {
                    p.predmeti.Add(s);
                }
                profesori.Add(p);
            }

            return profesori;
        }

        public static List<Ispit> GetExams(string path)
        {
            List<Ispit> ispiti = new List<Ispit>();
            string[] niz = File.ReadAllLines(path);
            foreach (string linija in niz)
            {
                Ispit i = new Ispit();
                string[] dijelovi = linija.Split(',');
                i.profesor = dijelovi[0];
                i.predmet = dijelovi[1];
                i.datum = dijelovi[2];
                i.ucionica = dijelovi[3];
                i.rok = dijelovi[4];
                ispiti.Add(i);
                
            }

            return ispiti;
        }

        public static List<Admin> GetAdmins(string path)
        {
            List<Admin> admini = new List<Admin>();
            string[] niz = File.ReadAllLines(path);
            foreach (string linija in niz)
            {
                Admin a = new Admin();
                string[] dijelovi = linija.Split(',');
                a.userName = dijelovi[0];
                a.password = dijelovi[1];
                a.ime = dijelovi[2];
                a.prezime = dijelovi[3];
                a.datumRodjenja = dijelovi[4];
                admini.Add(a);
            }

            return admini;
        }
        public static List<Rezultati> GetResults(List<Ispit> i,List<Student>s, string path)
        {
            List<Rezultati> rezultati = new List<Rezultati>();
            //lista ispita povuci iz global, zatim namjestiti na odgovarajuci ispit
            //lista studentat iz globala i naci odgovarajuceg i kreirati rezultat
            string[] niz = File.ReadAllLines(path);
            string prof;
            string predmet;
            string rok;
            string indeks;
            int ocjena;
            Student student = new Student();
            Ispit ispit = new Ispit();
            foreach (string linija in niz)
            {
            Rezultati r = new Rezultati();
                string[] dijelovi = linija.Split(',');
                prof = dijelovi[0];
                predmet = dijelovi[1];
                rok = dijelovi[2];
                indeks = dijelovi[3];
                ocjena = Convert.ToInt32(dijelovi[4]);
                foreach(Ispit isp in i)
                {
                    if(isp.profesor.Equals(prof) && isp.predmet.Equals(predmet) && isp.rok.Equals(rok))
                    {
                        ispit = isp;
                    }
                }

                foreach (Student st in s)
                {
                    if (st.indexNum.Equals(indeks))
                    {
                        student = st;
                    }
                }                
                r.ispit = ispit;
                r.student = student;
                r.ocjena = ocjena;
                rezultati.Add(r);                                  
            }

            return rezultati;
        }
    }
}