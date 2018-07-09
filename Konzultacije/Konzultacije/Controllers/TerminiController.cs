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
        private Kolegij kol = new Kolegij();
        private List<Kolegij> kollist = new List<Kolegij>();
        

        // GET: Termini
        public ActionResult Index(string ime_i_prezime, string naziv)
        {
            var termini = db.Termini.Include(t => t.Kolegij).Include(t => t.Profesor);
            var popis = from t in termini.ToList() select t;

            if (!String.IsNullOrEmpty(ime_i_prezime))
            {
                popis = popis.Where(t => t.Profesor.Ime_I_Prezime.ToUpper().Contains(ime_i_prezime.ToUpper()));
                return View(popis);
            }
                
            if (!String.IsNullOrEmpty(naziv))
            {
                popis = popis.Where(t => t.Kolegij.Naziv.ToUpper().Contains(naziv.ToUpper()));
                return View(popis);
            }
                

            if (Session["Profesor"] != null)
            {
                int ajdi = (int)Session["Profesor"];
                Profesor profesor = db.Profesor.Find(ajdi);
                ViewBag.Profesor = profesor.Ime_I_Prezime;
                termini = termini.Where(t => t.Profesor.Ime_I_Prezime == profesor.Ime_I_Prezime);
                return View(termini);
            }
            return View(termini);
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

            int a = (int)Session["Profesor"];
            Profesor prof = db.Profesor.Find(a);
            ViewBag.Profesor = prof.Ime_I_Prezime;
            var nesto = db.Kolegij_Profesor.Include(k => k.Kolegij).Include(k => k.Profesor).Where(x => x.ProfesorID == prof.ProfesorID).ToList();
            var nesto1 = db.Kolegij.ToList();
            foreach (Kolegij k in nesto1)
            {
                foreach(Kolegij_Profesor kolprof in nesto)
                {
                    if(k.Naziv == kolprof.Kolegij.Naziv)
                    {
                        kollist.Add(k);
                    }
                }
                              
            }
            ViewBag.MojaLista = kollist;
            ViewBag.KolegijID = new SelectList(db.Kolegij, "KolegijID", "Naziv");
            ViewBag.ProfesorID = new SelectList(db.Profesor, "ProfesorID", "Ime_I_Prezime");
            return View();
        }

        // POST: Termini/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TerminiID,KolegijID,Dan_Tjedan,Vrijeme_Od,Vrijeme_Do")] Termini termini)
        {
            int a = (int)Session["Profesor"];
            Profesor prof = db.Profesor.Find(a);

            if (ModelState.IsValid)
            {
                //var listatermina = db.Termini.ToList();
                //foreach(Termini t in listatermina)
                //{
                //    if (t.Kolegij.Naziv == termini.Kolegij.Naziv)
                //    {

                //    }
                //}
                
                termini.ProfesorID = prof.ProfesorID;
                db.Termini.Add(termini);
                db.SaveChanges();
                return RedirectToAction("Index", "Termini");
            }

            
            ViewBag.Profesor = prof.Ime_I_Prezime;
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

            int a = (int)Session["Profesor"];
            Profesor prof = db.Profesor.Find(a);
            ViewBag.Profesor = prof.Ime_I_Prezime;

            Kolegij kol = db.Kolegij.Find(termini.KolegijID);
            ViewBag.Kolegij = kol.Naziv;

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
            int a = (int)Session["Profesor"];
            Profesor prof = db.Profesor.Find(a);
            if (ModelState.IsValid)
            {
                termini.ProfesorID = prof.ProfesorID;
                db.Entry(termini).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Termini");
            }

            Kolegij kol = db.Kolegij.Find(termini.KolegijID);
            ViewBag.Kolegij = kol.Naziv;


            ViewBag.Profesor = prof.Ime_I_Prezime;
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
            var upiti = db.Upit.ToList();
            foreach (Upit u in upiti)
            {
                if (u.TerminID == id)
                {
                    db.Upit.Remove(u);
                }
            }
                db.Termini.Remove(termini);
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
