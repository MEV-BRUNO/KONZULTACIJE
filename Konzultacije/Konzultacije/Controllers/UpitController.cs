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
    public class UpitController : Controller
    {
        private BazaDbContext db = new BazaDbContext();

        // GET: Upit
        public ActionResult Index(int? id)
        {
            var upit = db.Upit.Include(u => u.Profesor).Include(u => u.Student);
            if (Session["Profesor"]!=null)
            { 
            Profesor trenutanprof = db.Profesor.Find(id);
            return View(upit.ToList().Where(x => x.ProfesorID == trenutanprof.ProfesorID).ToList());
            }

            if (Session["Student"] != null)
            {
                Student trenutanstu = db.Student.Find(id);
                return View(upit.ToList().Where(x => x.ProfesorID == trenutanstu.StudentID).ToList());
            }
            return View(upit.ToList());
        }

        // GET: Upit/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Upit upit = db.Upit.Find(id);
            if (upit == null)
            {
                return HttpNotFound();
            }
            return View(upit);
        }

        // GET: Upit/Create
        public ActionResult Create()
        {
            ViewBag.ProfesorID = new SelectList(db.Profesor, "ProfesorID", "Ime_I_Prezime");
            ViewBag.StudentID = new SelectList(db.Student, "StudentID", "Ime_I_Prezime");
            return View();
        }

        // POST: Upit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UpitID,StudentID,ProfesorID,Datum,Naslov,Opis,Odgovoren")] Upit upit)
        {
            if (ModelState.IsValid)
            {
                db.Upit.Add(upit);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ProfesorID = new SelectList(db.Profesor, "ProfesorID", "Ime_I_Prezime", upit.ProfesorID);
            ViewBag.StudentID = new SelectList(db.Student, "StudentID", "Ime_I_Prezime", upit.StudentID);
            return View(upit);
        }

        // GET: Upit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Upit upit = db.Upit.Find(id);
            if (upit == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProfesorID = new SelectList(db.Profesor, "ProfesorID", "Ime_I_Prezime", upit.ProfesorID);
            ViewBag.StudentID = new SelectList(db.Student, "StudentID", "Ime_I_Prezime", upit.StudentID);
            return View(upit);
        }

        // POST: Upit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UpitID,StudentID,ProfesorID,Datum,Naslov,Opis,Odgovoren")] Upit upit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(upit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ProfesorID = new SelectList(db.Profesor, "ProfesorID", "Ime_I_Prezime", upit.ProfesorID);
            ViewBag.StudentID = new SelectList(db.Student, "StudentID", "Ime_I_Prezime", upit.StudentID);
            return View(upit);
        }

        // GET: Upit/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Upit upit = db.Upit.Find(id);
            if (upit == null)
            {
                return HttpNotFound();
            }
            return View(upit);
        }

        // POST: Upit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Upit upit = db.Upit.Find(id);
            db.Upit.Remove(upit);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
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
