using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Konzultacije.Models;

namespace Konzultacije.Controllers
{
    public class HomeController : Controller
    {
        private BazaDbContext baza = new BazaDbContext();

        public ActionResult Index()
        {
            
            Student s = baza.Student.Find(Session["Student"]);
            Profesor p = baza.Profesor.Find(Session["Profesor"]);
            if (Session["Student"] == null && Session["Profesor"] == null)
            {
                return View();
            }
            else if (Session["Student"] != null)
            {
                
                return View("~/Views/Student/Index.cshtml", s );
            }
            else if (Session["Profesor"] != null)
            {
                return View("~/Views/Profesor/Index.cshtml", p);
                //return RedirectToAction("Index", "ProfesorController", p);
            }
            else
            {
                return View();
            }
            

        }

        public ActionResult About()
        {
            

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}