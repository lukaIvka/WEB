using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VebProj.Models;

namespace VebProj.Controllers
{
    public class StudentController : Controller
    {
        // GET: Korisnik
        public ActionResult Index()
        {
            string kIme = (string)HttpContext.Application["korIme"];
            string lozinka = (string)HttpContext.Application["sifra"];
            List<Student> studenti = (List<Student>)HttpContext.Application["listaStudenata"];
            foreach (Student student in studenti)
            {
                if ((kIme.Equals(student.userName)) && (lozinka.Equals(student.password)))
                {
                    HttpContext.Application["student"] = student;
                    break;
                }
            }
            
            ViewBag.Student = (Student)HttpContext.Application["student"];
            ViewBag.profesori = (List<Profesor>)HttpContext.Application["listaProfesori"];
            return View();
        }

        public ActionResult Prijava(bool prijava)
        {
            Student s = (Student)HttpContext.Application["student"];
            
            var ispit = Request["ispit"];
            string[] dijelovi = ispit.Split(',');
            string prof = dijelovi[0];
            string pred = dijelovi[1];
            string dat = dijelovi[2];
            string ucio = dijelovi[3];
            string rok = dijelovi[4];
            if (prof == null || pred == null || dat == null || ucio == null || rok == null)
            {
                // greska unesite tacnicu za ispit
                return RedirectToAction("Index", "Student");
            }
            if (!prijava)
            {
                // greska unesite tacnicu za ispit
                return RedirectToAction("Index", "Student");
            }
            Ispit i1 = new Ispit(prof, pred, dat, ucio, rok);            
            foreach (Ispit i in s.prijavljeni) {
                if (i.predmet.Equals(i1.predmet) && i.profesor.Equals(i1.profesor) && i.datum.Equals(i1.datum) && i.rok.Equals(i1.rok)) {
                    //greska
                    return RedirectToAction("Index", "Student");
                }
            }
            s.prijavljeni.Add(i1);

            return RedirectToAction("PregledIspita", "Student");
        }

        
        public ActionResult PregledIspita()
        {
            ViewBag.rezultati = (List<Rezultati>)HttpContext.Application["rezultatiIspita"];
            List<Rezultati> rezultati = (List<Rezultati>)HttpContext.Application["rezultatiIspita"];
            List<Student> studenti = (List<Student>)HttpContext.Application["listaStudenata"];
            ViewBag.student = (Student)HttpContext.Application["student"];

            foreach (Rezultati r in rezultati)
            {
                foreach (Student s in studenti)
                {
                    foreach (Ispit i in s.prijavljeni)
                    {
                        if (r.ocjena > 5 && r.student.Equals(s) && r.ispit.Equals(i))
                        {
                            if (!s.polozeni.Contains(r.ispit))
                            {
                                s.polozeni.Add(i);
                            }
                        }
                        else if (r.ocjena == 5 && r.student.Equals(s) && r.ispit.Equals(i))
                        {
                            if (!s.nepolozeni.Contains(r.ispit))
                            {
                                s.nepolozeni.Add(i);
                            }
                        }
                    }
                }
            }

            return View();
        }
    }
}