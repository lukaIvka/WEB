using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using VebProj.Models;

namespace VebProj
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            string korIme = "";
            string sifra = "";
            HttpContext.Current.Application["korIme"] = korIme;
            HttpContext.Current.Application["sifra"] = sifra;

            List<Ispit> ispiti = Models.GetData.GetExams("C:/Users/User/Desktop/Veb - Veb programiranje u infrastrukturnim sistemima/projekat/VebProj/VebProj/App_Data/Ispiti.csv");
            List<Admin> admini = Models.GetData.GetAdmins("C:/Users/User/Desktop/Veb - Veb programiranje u infrastrukturnim sistemima/projekat/VebProj/VebProj/App_Data/Admin.csv");
            List<Profesor> profesori = Models.GetData.GetProfesors("C:/Users/User/Desktop/Veb - Veb programiranje u infrastrukturnim sistemima/projekat/VebProj/VebProj/App_Data/Profesor.csv");
            List<Student> studenti = Models.GetData.GetStudents("C:/Users/User/Desktop/Veb - Veb programiranje u infrastrukturnim sistemima/projekat/VebProj/VebProj/App_Data/Student.csv");
            List<Rezultati> rezulteti = Models.GetData.GetResults(ispiti, studenti,"C:/Users/User/Desktop/Veb - Veb programiranje u infrastrukturnim sistemima/projekat/VebProj/VebProj/App_Data/Rezultati.csv");
            foreach (Profesor p in profesori)
            {
                foreach (Ispit i in ispiti)
                {
                    if (i.profesor.Equals(p.ime))
                    {
                            p.ispiti.Add(i);
                        
                    }
                }
            }
            
            foreach(Student s in studenti) {
                foreach (Rezultati r in rezulteti)
                {
                      if (r.student.indexNum.Equals(s.indexNum))
                      {
                          if (r.ocjena > 5)
                          {
                              if (!s.polozeni.Contains(r.ispit))
                              {
                                  s.polozeni.Add(r.ispit);
                              }
                          }
                          else
                          {
                              if (!s.nepolozeni.Contains(r.ispit))
                              {
                                  s.nepolozeni.Add(r.ispit);
                              }
                          }
                      }
                }
            }
            HttpContext.Current.Application["listaIspita"] = ispiti;
            HttpContext.Current.Application["listaStudenata"] = studenti;
            HttpContext.Current.Application["listaAdmina"] = admini;
            HttpContext.Current.Application["listaProfesori"] = profesori;
            HttpContext.Current.Application["rezultatiIspita"] = rezulteti;


            HttpContext.Current.Application["admin"] = admini[0];
            HttpContext.Current.Application["profesor"] = profesori[0];
            HttpContext.Current.Application["student"] = studenti[0];
        }
        protected void Application_Error(object sender, EventArgs e)
        {            
            Exception ex = Server.GetLastError();
            Server.ClearError();
            Response.Redirect("~/Error/Index");
        }
    }
}
