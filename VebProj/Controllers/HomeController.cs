using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VebProj.Models;

namespace VebProj.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogIn()
        {
            List<Student> studenti = (List<Student>)HttpContext.Application["listaStudenata"];
            List<Admin> admini = (List<Admin>)HttpContext.Application["listaAdmina"];
            List<Profesor> profesori = (List<Profesor>)HttpContext.Application["listaProfesori"];
            
            var korIme = Request["korIme"];
            if(korIme == null)
            {
                korIme = "";
            }
            var sifra = Request["Sifra"];
            if (sifra == null)
            {
                sifra = "";
            }

            foreach (Admin a in admini)
            {
                if (a.userName.Equals(korIme))
                {
                    if (a.password.Equals(sifra))
                    {
                        HttpContext.Application["korIme"] = korIme;
                        HttpContext.Application["sifra"] = sifra;
                        return RedirectToAction("Index", "Admin");
                    }
                }
            }

            foreach(Student s in studenti)
            {
                if((korIme.Equals(s.userName)) && (sifra.Equals(s.password)))
                {
                    HttpContext.Application["korIme"] = korIme;
                    HttpContext.Application["sifra"] = sifra;
                    return RedirectToAction("Index", "Student");
                }
            }

            foreach (Profesor p in profesori)
            {
                if ((korIme.Equals(p.userName)) && (sifra.Equals(p.password)))
                {
                    HttpContext.Application["korIme"] = korIme;
                    HttpContext.Application["sifra"] = sifra;
                    return RedirectToAction("Index", "Profesor");
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}