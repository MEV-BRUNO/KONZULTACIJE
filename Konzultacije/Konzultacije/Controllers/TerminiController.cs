using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Konzultacije.Models;

namespace Konzultacije.Controllers
{
    public class TerminiController : Controller
    {
        private BazaDbContext db = new BazaDbContext();

        // GET: Termini
        public ActionResult Index()
        {
            var termini = db.Termini.Include(t => t.Kolegij).Include(t => t.Profesor);
            return View(termini.ToList());
        }

        // GET: Termini/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Termini termini = db.Termini.Find(id);
            if (termini == null)
            {
                return HttpNotFound();
            }
            return View(termini);
        }

        // GET: Termini/Create
        public ActionResult Create()
        {
            if(Session["Student"] == null && Session["Profesor"] == null)
            {
                return RedirectToAction("Index", "Home");
                //return View("~/Views/Home/Index.cshtml");
            }
            ViewBag.KolegijID = new SelectList(db.Kolegij, "KolegijID", "Naziv");
            ViewBag.ProfesorID = new SelectList(db.Profesor, "ProfesorID", "Ime_I_Prezime");
            return View();
        }

        // POST: Termini/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TerminiID,ProfesorID,KolegijID,Dan_Tjedan,Vrijeme_Od,Vrijeme_Do")] Termini termini)
        {
            if (ModelState.IsValid)
            {
                db.Termini.Add(termini);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KolegijID = new SelectList(db.Kolegij, "KolegijID", "Naziv", termini.KolegijID);
            ViewBag.ProfesorID = new SelectList(db.Profesor, "ProfesorID", "Ime_I_Prezime", termini.ProfesorID);
            return View(termini);
        }

        // GET: Termini/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Termini termini = db.Termini.Find(id);
            if (termini == null)
            {
                return HttpNotFound();
            }
            ViewBag.KolegijID = new SelectList(db.Kolegij, "KolegijID", "Naziv", termini.KolegijID);
            ViewBag.ProfesorID = new SelectList(db.Profesor, "ProfesorID", "Ime_I_Prezime", termini.ProfesorID);
            return View(termini);
        }

        // POST: Termini/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TerminiID,ProfesorID,KolegijID,Dan_Tjedan,Vrijeme_Od,Vrijeme_Do")] Termini termini)
        {
            if (ModelState.IsValid)
            {
                db.Entry(termini).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KolegijID = new SelectList(db.Kolegij, "KolegijID", "Naziv", termini.KolegijID);
            ViewBag.ProfesorID = new SelectList(db.Profesor, "ProfesorID", "Ime_I_Prezime", termini.ProfesorID);
            return View(termini);
        }

        // GET: Termini/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Termini termini = db.Termini.Find(id);
            if (termini == null)
            {
                return HttpNotFound();
            }
            return View(termini);
        }

        // POST: Termini/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Termini termini = db.Termini.Find(id);
            db.Termini.Remove(termini);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
