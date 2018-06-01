using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Konzultacije.Models;
using System.Threading.Tasks;


namespace Konzultacije.Controllers
{
    
    public class AccountController : Controller
    {

        

        // GET: Account/Login
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if(ModelState.IsValid)
            {
                return View(model);
            }
            return View(model);
        }


        // GET: Account/Login
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }
            return View(model);
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
            return View(model);
        }
    }
}