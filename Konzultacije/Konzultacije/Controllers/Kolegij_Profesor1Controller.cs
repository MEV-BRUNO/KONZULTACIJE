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
    public class Kolegij_Profesor1Controller : Controller
    {
        private BazaDbContext db = new BazaDbContext();

        // GET: Kolegij_Profesor1
        public ActionResult Index()
        {
            var kolegij_Profesor = db.Kolegij_Profesor.Include(k => k.Kolegij).Include(k => k.Profesor);
            return View(kolegij_Profesor.ToList());
        }

        // GET: Kolegij_Profesor1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kolegij_Profesor kolegij_Profesor = db.Kolegij_Profesor.Find(id);
            if (kolegij_Profesor == null)
            {
                return HttpNotFound();
            }
            return View(kolegij_Profesor);
        }

        // GET: Kolegij_Profesor1/Create
        public ActionResult Create()
        {
            ViewBag.KolegijID = new SelectList(db.Kolegij, "KolegijID", "Naziv");
            ViewBag.ProfesorID = new SelectList(db.Profesor, "ProfesorID", "Ime_I_Prezime");
            return View();
        }

        // POST: Kolegij_Profesor1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Kolegij_ProfesorID,ProfesorID,KolegijID")] Kolegij_Profesor kolegij_Profesor)
        {
            if (ModelState.IsValid)
            {
                db.Kolegij_Profesor.Add(kolegij_Profesor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KolegijID = new SelectList(db.Kolegij, "KolegijID", "Naziv", kolegij_Profesor.KolegijID);
            ViewBag.ProfesorID = new SelectList(db.Profesor, "ProfesorID", "Ime_I_Prezime", kolegij_Profesor.ProfesorID);
            return View(kolegij_Profesor);
        }

        // GET: Kolegij_Profesor1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kolegij_Profesor kolegij_Profesor = db.Kolegij_Profesor.Find(id);
            if (kolegij_Profesor == null)
            {
                return HttpNotFound();
            }
            ViewBag.KolegijID = new SelectList(db.Kolegij, "KolegijID", "Naziv", kolegij_Profesor.KolegijID);
            ViewBag.ProfesorID = new SelectList(db.Profesor, "ProfesorID", "Ime_I_Prezime", kolegij_Profesor.ProfesorID);
            return View(kolegij_Profesor);
        }

        // POST: Kolegij_Profesor1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Kolegij_ProfesorID,ProfesorID,KolegijID")] Kolegij_Profesor kolegij_Profesor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kolegij_Profesor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KolegijID = new SelectList(db.Kolegij, "KolegijID", "Naziv", kolegij_Profesor.KolegijID);
            ViewBag.ProfesorID = new SelectList(db.Profesor, "ProfesorID", "Ime_I_Prezime", kolegij_Profesor.ProfesorID);
            return View(kolegij_Profesor);
        }

        // GET: Kolegij_Profesor1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kolegij_Profesor kolegij_Profesor = db.Kolegij_Profesor.Find(id);
            if (kolegij_Profesor == null)
            {
                return HttpNotFound();
            }
            return View(kolegij_Profesor);
        }

        // POST: Kolegij_Profesor1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kolegij_Profesor kolegij_Profesor = db.Kolegij_Profesor.Find(id);
            db.Kolegij_Profesor.Remove(kolegij_Profesor);
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
