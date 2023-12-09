using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VebProj.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            
            ViewBag.ErrorMessage = "An unexpected error occurred. Please try again later.";
            return View();
        }
    }
}