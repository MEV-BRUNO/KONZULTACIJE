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
        private List<Kolegij> kolegijs = new List<Kolegij>();

        // GET: Upit
        public ActionResult Index(int? id)
        {
            var upit = db.Upit.Include(u => u.Profesor).Include(u => u.Student).Include(u => u.Termini);

            

            if (Session["Profesor"]!=null)
            { 
            Profesor trenutanprof = db.Profesor.Find(id);
            
            return View(upit.ToList().Where(x => x.ProfesorID == trenutanprof.ProfesorID).ToList());
            }

            if (Session["Student"] != null)
            {
                Student trenutanstu = db.Student.Find(id);
                return View(upit.ToList().Where(x => x.StudentID == trenutanstu.StudentID).ToList());
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
            int a = (int)Session["Student"];
            Student stu = db.Student.Find(a);
            ViewBag.Student = stu.Ime_I_Prezime;

            
            ViewBag.ProfesorID = new SelectList(db.Profesor, "ProfesorID", "Ime_I_Prezime");
            ViewBag.StudentID = new SelectList(db.Student, "StudentID", "Ime_I_Prezime");
            ViewBag.TerminID = new SelectList(db.Termini, "TerminiID", "KolegijID");
            var listatermina = db.Termini.Include(k => k.Kolegij).Include(k => k.Profesor).ToList();
            foreach(Termini t in listatermina)
            {
                var trenutni = db.Kolegij.Find(t.KolegijID);
                kolegijs.Add(trenutni);
            }
            ViewBag.MojaLista = kolegijs;
            return View();
        }

        // POST: Upit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UpitID,ProfesorID,TerminID,Naslov,Opis,Odgovor,Odgovoren")] Upit upit)
        {
            int a = (int)Session["Student"];
            Student stu = db.Student.Find(a);
            ViewBag.Student = stu.Ime_I_Prezime;
            
            if (ModelState.IsValid)
            {
                var listatermina = db.Termini.Include(k => k.Kolegij).Include(k => k.Profesor).ToList();
                var kolegij = db.Kolegij.Find(upit.TerminID);
                foreach (Termini t in listatermina)
                {
                    if (t.KolegijID == kolegij.KolegijID)
                    {
                        upit.TerminID = t.TerminiID;
                    }
                   
                }

                upit.StudentID = stu.StudentID;
                db.Upit.Add(upit);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            

            
            ViewBag.ProfesorID = new SelectList(db.Profesor, "ProfesorID", "Ime_I_Prezime", upit.ProfesorID);
            ViewBag.StudentID = new SelectList(db.Student, "StudentID", "Ime_I_Prezime", upit.StudentID);
            ViewBag.TerminID = new SelectList(db.Termini, "TerminiID",  "KolegijID", upit.TerminID);
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
            ViewBag.TerminID = new SelectList(db.Termini, "TerminiID", "TerminiID", upit.TerminID);
            return View(upit);
        }

        // POST: Upit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UpitID,StudentID,ProfesorID,TerminID,Naslov,Opis,Odgovor,Odgovoren")] Upit upit)
        {

            
            if (ModelState.IsValid)
            {
                upit.Odgovoren = true;
                db.Entry(upit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            
            ViewBag.ProfesorID = new SelectList(db.Profesor, "ProfesorID", "Ime_I_Prezime", upit.ProfesorID);
            ViewBag.StudentID = new SelectList(db.Student, "StudentID", "Ime_I_Prezime", upit.StudentID);
            ViewBag.TerminID = new SelectList(db.Termini, "TerminiID", "TerminiID", upit.TerminID);
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
