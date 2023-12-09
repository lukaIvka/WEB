using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VebProj.Models;

namespace VebProj.Controllers
{
    public class ProfesorController : Controller
    {
        // GET: Profesor
        public ActionResult Index()
        {
            string kIme = (string)HttpContext.Application["korIme"];
            string lozinka = (string)HttpContext.Application["sifra"];
            List<Profesor> profesori = (List<Profesor>)HttpContext.Application["listaProfesori"];
            
            foreach (Profesor profa in profesori)
            {
                if ((kIme.Equals(profa.userName)) && (lozinka.Equals(profa.password)))
                {
                    HttpContext.Application["profesor"] = profa;
                    break;
                }
            }
            ViewBag.profesori = (List<Profesor>)HttpContext.Application["listaProfesori"];
            ViewBag.ispiti = (List<Ispit>)HttpContext.Application["listaIspita"];
            ViewBag.profesor = (Profesor)HttpContext.Application["profesor"];
            ViewBag.studenti = (List<Student>)HttpContext.Application["listaStudenata"];

            return View();
        }

        public ActionResult Kreiraj()
        {
            Profesor p = (Profesor)HttpContext.Application["profesor"];            
            var predmet = Request["predmet"];
            var datumOdrzavanja = Request["datum"];
            if (!p.predmeti.Contains(predmet))
            {
                //poruka za los unos
                return RedirectToAction("Index", "Profesor");
            }
            DateTime Datum = DateTime.Parse(datumOdrzavanja);
            if (Datum < DateTime.Now)
            {
                //poruka za gresku
                return RedirectToAction("Index", "Profesor");
            }
            var ucionica = Request["ucionica"];
            var rok = Request["rokovi"];
            if (predmet == "" || datumOdrzavanja == "" || ucionica == "" || rok == "")
            {
                //greska
                return RedirectToAction("Index", "Profesor");
            }
            
            if (!p.predmeti.Contains(predmet))
            {
                // greska
                return RedirectToAction("Index", "Profesor");
            }


            Ispit i = new Ispit();
            if (Datum.Month == 1 && rok == "JANUAR")
            {
                i = new Ispit(p.ime, predmet, Datum.ToString(), ucionica, rok);
            }
            else if (Datum.Month == 2 && rok == "FEBRUAR")
            {
                i = new Ispit(p.ime, predmet, Datum.ToString(), ucionica, rok);
            }
            else if (Datum.Month == 4 && rok == "APRIL")
            {
                i = new Ispit(p.ime, predmet, Datum.ToString(), ucionica, rok);
            }
            else if (Datum.Month == 6 && rok == "JUN")
            {
                i = new Ispit(p.ime, predmet, Datum.ToString(), ucionica, rok);
            }
            else if (Datum.Month == 7 && rok == "JUL")
            {
                i = new Ispit(p.ime, predmet, Datum.ToString(), ucionica, rok);
            }
            else if (Datum.Month == 8 && rok == "AVGUST")
            {
                i = new Ispit(p.ime, predmet, Datum.ToString(), ucionica, rok);
            }
            else if (Datum.Month == 9 && rok == "SEPTEMBAR")
            {
                i = new Ispit(p.ime, predmet, Datum.ToString(), ucionica, rok);
            }
            else if (Datum.Month == 10 && rok == "OKTOBAR")
            {
                i = new Ispit(p.ime, predmet, Datum.ToString(), ucionica, rok);
            }
            else
            {
                // nepoklapanje datuma
                return RedirectToAction("Index", "Profesor");
            }
            foreach (Ispit ispit in p.ispiti) {
                if (ispit.predmet.Equals(i.predmet) && ispit.datum.Equals(i.datum) && ispit.rok.Equals(i.rok))
                {
                    //greska
                    return RedirectToAction("Index", "Profesor");
                } 
            }

            p.ispiti.Add(i);
            ManipulateData.IspitiZaProfu(i);            

            return RedirectToAction("PregledIspita", "Profesor");
        }
        public ActionResult Ocijeni()
        {
            Profesor p = (Profesor)HttpContext.Application["profesor"];
            List<Student> studenti= (List<Student>)HttpContext.Application["listaStudenata"];
            List<Rezultati> rezultati = (List<Rezultati>)HttpContext.Application["rezultatiIspita"];

            var ispit = Request["ispit"];
            var student = Request["student"];
            var ocijena = Request["Ocijena"];
            Ispit isp = new Ispit();
            int counter = 0;
            if (!p.predmeti.Contains(ispit))
            {
                //greska
                return RedirectToAction("Index", "Profesor");
            }
            if(ispit == "" || student == "" || ocijena == "")
            {
                return RedirectToAction("Index", "Profesor");
            }
            foreach (Student s in studenti)
            {
                foreach (Ispit i in s.prijavljeni)
                {
                    if (s.ime.Equals(student) && i.predmet.Equals(ispit) && i.profesor.Equals(p.ime))
                    {
                        isp = i;
                        Rezultati ri = new Rezultati(i, s, int.Parse(ocijena));
                        foreach(Rezultati r in rezultati)
                        {
                            if (r.ispit.predmet.Equals(ri.ispit.predmet) && r.ispit.rok.Equals(ri.ispit.rok) && r.student.ime.Equals(ri.student.ime))
                            {
                                return RedirectToAction("Index", "Profesor");
                            }
                        }
                        rezultati.Add(ri);
                        if (ri.ocjena > 5)
                        {
                            if (!s.polozeni.Contains(ri.ispit))
                            {
                                s.polozeni.Add(ri.ispit);
                            }
                        }
                        else
                        {
                            if (!s.nepolozeni.Contains(ri.ispit))
                            {
                                s.nepolozeni.Add(ri.ispit);
                            }
                        }
                        counter++;
                        s.prijavljeni.Remove(isp);
                        ManipulateData.ModifikacijeRezultata(rezultati);
                    }
                    if (counter > 0)
                    {
                        break;
                    }
                }
            }
            
            return RedirectToAction("PregledIspita", "Profesor");
        }
        public ActionResult PregledIspita()
        {
            ViewBag.profesor = (Profesor)HttpContext.Application["profesor"];
            ViewBag.rezultati = (List<Rezultati>)HttpContext.Application["rezultatiIspita"];
            
            return View();
        }
        public ActionResult Prikazi()
        {
            return RedirectToAction("PregledIspita", "Profesor");
        }
    }
}