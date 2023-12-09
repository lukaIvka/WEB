using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VebProj.Models;

namespace VebProj.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            string kIme = (string)HttpContext.Application["korIme"];
            string lozinka = (string)HttpContext.Application["sifra"];
            List<Admin> admini = (List<Admin>)HttpContext.Application["listaAdmina"];
            foreach (Admin a in admini)
            {
                if ((kIme.Equals(a.userName)) && (lozinka.Equals(a.password)))
                {
                    HttpContext.Application["admin"] = a;
                    break;
                }
            }
            ViewBag.Admin = (Admin)HttpContext.Application["admin"];
            return View();
        }

        public ActionResult Kreiraj()
        {
            List<Student> studenti = (List<Student>)HttpContext.Application["listaStudenata"];
            List<Admin> admini = (List<Admin>)HttpContext.Application["listaAdmina"];
            List<Profesor> profesori = (List<Profesor>)HttpContext.Application["listaProfesori"];
            
            var korIme = Request["KorisnickoIme"];
            var brIndex = Request["BrIndex"];
            var sifra = Request["Sifra"];
            var ime = Request["Ime"];
            var prezime = Request["Prezime"];
            var datRodj = Request["DatumRodjenja"];
            var email = Request["Email"];

            foreach (Student s in studenti)
            {
                if (s.userName.Equals(korIme))
                {   ////NAMJESTI GRESKUUUUUUUU
                    ViewBag.Greska = "Greska, korisnik vec postoji!";
                    return RedirectToAction("Index", "Admin");
                }
            }
            foreach (Profesor p in profesori)
            {
                if (p.userName.Equals(korIme))
                {   
                    ViewBag.Greska = "Greska, korisnik vec postoji!";
                    return RedirectToAction("Index", "Adimin");
                }

            }
            foreach (Admin a in admini)
            {
                if (a.userName.Equals(korIme))
                {
                    ViewBag.Greska = "Greska, korisnik vec postoji!";
                    return RedirectToAction("Index", "Adimin");
                }
            }
            if (korIme == "" || sifra == "" || brIndex == "" || ime == "" || prezime == "" || datRodj == null || email =="")
            {
                ViewBag.Greska1 = "Greska, korisnik ne postoji!";
                return RedirectToAction("Index", "Adimin");
            }

            Student student = new Student(korIme, brIndex, sifra, ime, prezime, datRodj, email);
            studenti.Add(student);
            ManipulateData.ModifikacijeZaAdmina(studenti);
            return RedirectToAction("ListajStudente", "Admin");

        }

        public ActionResult Azuriraj()
        {
            List<Student> studenti = (List<Student>)HttpContext.Application["listaStudenata"];
            List<Admin> admini = (List<Admin>)HttpContext.Application["ListaAdmina"];
            List<Profesor> profesori = (List<Profesor>)HttpContext.Application["listaProfesori"];

            var korIme = Request["KorisnickoIme"];
            var sifra = Request["Sifra"];

            foreach (Profesor p in profesori)
            {
                if (p.userName.Equals(korIme))
                {   
                    ViewBag.Upozorenje = "Upozorenje, korisnik nije student!";
                    return RedirectToAction("Index", "Adimin");
                }

            }
            foreach (Admin a in admini)
            {
                if (a.userName.Equals(korIme))
                {
                    ViewBag.Upozorenje = "Upozorenje, korisnik nije student!";   
                    return RedirectToAction("Index", "Adimin");
                }
            }

            if (korIme == "" || sifra == "")
            {
                ViewBag.Greska1 = "Greska, korisnik ne postoji!";
                return RedirectToAction("Index", "Adimin");
            }

            foreach (Student s in studenti)
            {
                if (s.userName.Equals(korIme) && s.password.Equals(sifra))
                {
                    return View();
                }
            }
            ViewBag.Greska1 = "Greska, korisnik ne postoji!";

            return RedirectToAction("Index", "Admin");
        }

        public ActionResult Obrisi()
        {
            List<Student> studenti = (List<Student>)HttpContext.Application["listaStudenata"];
            List<Admin> admini = (List<Admin>)HttpContext.Application["listaAdmina"];
            List<Profesor> profesori = (List<Profesor>)HttpContext.Application["listaProfesori"];

            var korIme = Request["KorisnickoIme"];
            var brIndex = Request["brIndeksa"];

            foreach (Profesor p in profesori)
            {
                if (p.userName.Equals(korIme))
                {
                    ViewBag.Upozorenje = "Upozorenje, korisnik nije student!";
                    return RedirectToAction("Index", "Adimin");
                }
            }
            foreach (Admin a in admini)
            {
                if (a.userName.Equals(korIme))
                {
                    ViewBag.Upozorenje = "Upozorenje, korisnik nije student!";
                    return RedirectToAction("Index", "Adimin");
                }
            }
            
            if (korIme == "" || brIndex == "")
            {
                ViewBag.Greska1 = "Greska, korisnik ne postoji!";
                return RedirectToAction("Index", "Adimin");
            }

            foreach (Student s in studenti)
            {
                if (s.userName.Equals(korIme))
                {
                    studenti.Remove(s);
                    HttpContext.Application["listaStudenata"] = studenti;
                    ManipulateData.ModifikacijeZaAdmina(studenti);
                    return RedirectToAction("ListajStudente", "Admin");
                }
            }

            return View();
        }

        public ActionResult ListajStudente()
        {
            ViewBag.studenti = (List<Student>)HttpContext.Application["listaStudenata"];
            ViewBag.rezultati = (List<Rezultati>)HttpContext.Application["rezultatiIspita"];
            return View();
        }

        public ActionResult Azuriranje()
        {
            List<Student> studenti = (List<Student>)HttpContext.Application["listaStudenata"];
            List<Admin> admini = (List<Admin>)HttpContext.Application["ListaAdmina"];
            List<Profesor> profesori = (List<Profesor>)HttpContext.Application["listaProfesori"];

            var korIme = Request["KorisnickoIme"];
            var brIndex = Request["BrIndex"];
            var sifra = Request["Sifra"];
            var ime = Request["Ime"];
            var prezime = Request["Prezime"];
            var datRodj = Request["DatumRodjenja"];
            var email = Request["Email"];
            foreach (Profesor p in profesori)
            {
                if (p.userName.Equals(korIme))
                {
                    ViewBag.Upozorenje = "Upozorenje, korisnik nije student!";
                    return RedirectToAction("Index", "Adimin");
                }
            }
            foreach (Admin a in admini)
            {
                if (a.userName.Equals(korIme))
                {
                    ViewBag.Upozorenje = "Upozorenje, korisnik nije student!";
                    return RedirectToAction("Index", "Adimin");
                }
            }

            if(korIme == "" || sifra == "" || brIndex == "" || ime == "" || prezime == "" || datRodj == null || email == "")
            {
                ViewBag.Greska1 = "Greska, korisnik ne postoji!";
                return RedirectToAction("Index", "Adimin");
            }

            foreach (Student s in studenti)
            {
                if (s.userName.Equals(korIme))
                {
                    s.indexNum = brIndex;
                    s.password = sifra;
                    s.ime = ime;
                    s.prezime = prezime;
                    s.datumRodjenja = datRodj;
                    s.email = email;
                    ManipulateData.ModifikacijeZaAdmina(studenti);
                    return RedirectToAction("ListajStudente", "Admin");
                }
            }
            ViewBag.Upozorenje1 = "Korisnik nije azuriran!";
            return RedirectToAction("Index", "Admin");
        
        }
    }
}