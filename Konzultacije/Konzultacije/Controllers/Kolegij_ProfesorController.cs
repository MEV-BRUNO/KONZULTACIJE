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
    public class Kolegij_ProfesorController : Controller
    {
        private BazaDbContext db = new BazaDbContext();
        private List<Kolegij> kollist = new List<Kolegij>();
        private Kolegij kolegij = new Kolegij();

        // GET: Kolegij_Profesor
        //public ActionResult Index()
        //{
        //    var kolegij_Profesor = db.Kolegij_Profesor.Include(k => k.Kolegij).Include(k => k.Profesor);
        //    return View(kolegij_Profesor.ToList());
        //}
        public ActionResult Index(string ime)
        {
            //Kolegij kol = db.Kolegij.Find();
            if(ime == null)
            {
                var kolegij_Profesor = db.Kolegij_Profesor.Include(k => k.Kolegij).Include(k => k.Profesor);
                return View(kolegij_Profesor.ToList());
            }
            var kolegijprof = db.Kolegij_Profesor.Include(k => k.Kolegij).Include(k => k.Profesor).Where(k => k.Profesor.Ime_I_Prezime == ime);

            return View(kolegijprof.ToList());
        }

        // GET: Kolegij_Profesor/Details/5
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

        // GET: Kolegij_Profesor/Create
        public ActionResult Create()
        {
            int a = (int)Session["Profesor"];
            Profesor prof = db.Profesor.Find(a);
            ViewBag.Profesor = prof.Ime_I_Prezime;

            

            var listaKolegija = db.Kolegij.ToList().Where(x => x.Odabran == false);        
            ViewBag.MojaLista = listaKolegija;
            ViewBag.KolegijID = new SelectList(db.Kolegij, "KolegijID", "Naziv");
            ViewBag.ProfesorID = new SelectList(db.Profesor, "ProfesorID", "Ime_I_Prezime");
            return View();
        }

        // POST: Kolegij_Profesor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Kolegij_ProfesorID,KolegijID")] Kolegij_Profesor kolegij_Profesor)
        {

            int a = (int)Session["Profesor"];
            Profesor prof = db.Profesor.Find(a);
            ViewBag.Profesor = prof.Ime_I_Prezime;

            if (ModelState.IsValid)
            {
                kolegij = db.Kolegij.Find(kolegij_Profesor.KolegijID);
                kolegij.Odabran = true;
                kolegij_Profesor.ProfesorID = prof.ProfesorID;
                db.Kolegij_Profesor.Add(kolegij_Profesor);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            
            ViewBag.KolegijID = new SelectList(db.Kolegij, "KolegijID", "Naziv", kolegij_Profesor.KolegijID);
            ViewBag.ProfesorID = new SelectList(db.Profesor, "ProfesorID", "Ime_I_Prezime", kolegij_Profesor.ProfesorID);
            return View(kolegij_Profesor);
        }

        // GET: Kolegij_Profesor/Edit/5
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

        // POST: Kolegij_Profesor/Edit/5
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
                return RedirectToAction("Index", "Home");
            }
            ViewBag.KolegijID = new SelectList(db.Kolegij, "KolegijID", "Naziv", kolegij_Profesor.KolegijID);
            ViewBag.ProfesorID = new SelectList(db.Profesor, "ProfesorID", "Ime_I_Prezime", kolegij_Profesor.ProfesorID);
            return View(kolegij_Profesor);
        }

        // GET: Kolegij_Profesor/Delete/5
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

        // POST: Kolegij_Profesor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kolegij_Profesor kolegij_Profesor = db.Kolegij_Profesor.Find(id);
            kolegij_Profesor.Kolegij.Odabran = false;

            //brisanje upita za taj termin
            var upiti = db.Upit.ToList();
           

            //brisanje termina
            var termini = db.Termini.ToList();
            int x=0;
            foreach(Termini t in termini)
            {
                if(t.KolegijID == kolegij_Profesor.KolegijID)
                {
                    x = t.TerminiID;
                }
                foreach (Upit u in upiti)
                {
                    if (u.TerminID == x)
                    {
                        db.Upit.Remove(u);
                    }
            }
            }
            Termini termin = db.Termini.Find(x);
            
            db.Kolegij_Profesor.Remove(kolegij_Profesor);
            db.Termini.Remove(termin);
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
