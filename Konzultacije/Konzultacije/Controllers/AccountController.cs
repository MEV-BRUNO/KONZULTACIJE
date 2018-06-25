using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Konzultacije.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin;



namespace Konzultacije.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        
        private BazaDbContext baza = new BazaDbContext();





        // GET: Account/Login
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            //if (Session["Student"] != null)
            //{
            //    return View("~/Views/Student/Index.cshtml", new { s = Session["Profesor"].ToString() });
            //} else if (Session["Profesor"]!=null)
            //{
            //    return View("~/Views/Profesor/Index.cshtml", new { s = Session["Profesor"].ToString() });
            //}
            //else 
            //{
                return View();
            //}
        }

        // POST: Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            List<Student> students = baza.Student.ToList();
            List<Profesor> profesors = baza.Profesor.ToList();
            if(ModelState.IsValid)
            {
                foreach(Student s in students)
                {
                    if (model.Email == s.Email && model.Lozinka == s.Lozinka)
                    {
                        Session["Student"] = s.StudentID;
                        return View("~/Views/Student/Index.cshtml", s);
                    }
                        //RedirectToAction("Index", "Student", "Account"); 
                    
                }
                foreach(Profesor p in profesors)
                {
                    if (model.Email == p.Email && model.Lozinka == p.Lozinka)
                    {
                        Session["Profesor"] = p.ProfesorID;
                        return View("~/Views/Profesor/Index.cshtml", p);
                    }
                        //RedirectToAction("Index", "Profesor", "Account");
                }
                
            }
            //AddErrors();
            ViewBag.Message ="Ovog korisnika nema u bazi. ";
            return View();
        }


        // GET: Account/Login
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            
            return View();
        }

        
        

        // GET: Account/Login
        [HttpGet]
        [AllowAnonymous]
        public ActionResult ForgottenPassword()
        {
            
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ForgottenPassword(ForgottenPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }
            return View();
        }


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }


    }
}