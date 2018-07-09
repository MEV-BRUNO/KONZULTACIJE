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
    public class KolegijController : Controller
    {
        private BazaDbContext db = new BazaDbContext();

        // GET: Kolegij
        public ActionResult Index()
        {
            return View();
        }

        //moji kontroleri za ispis kolegija
        public ActionResult Popis()
        {
            return View(db.Kolegij.ToList().Where(x => x.Odabran == false).ToList());
            //return View(db.Kolegij.ToList());
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Popis(List<Kolegij> lista)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        db.Entry(lista).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("PopisOdabranih", "Kolegij");
        //    }
        //    return View(db.Kolegij.ToList().Where(x => x.Odabran == false).ToList());

        //}


        public ActionResult PopisOdabranih()
        {          
            
            return View(db.Kolegij.ToList().Where(x => x.Odabran == true).ToList());
        }

        // GET: Kolegij/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kolegij kolegij = db.Kolegij.Find(id);
            if (kolegij == null)
            {
                return HttpNotFound();
            }
            return View(kolegij);
        }

        // GET: Kolegij/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kolegij/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KolegijID,Naziv,Odabran")] Kolegij kolegij)
        {
            if (ModelState.IsValid)
            {
                db.Kolegij.Add(kolegij);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(kolegij);
        }

        // GET: Kolegij/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kolegij kolegij = db.Kolegij.Find(id);
            if (kolegij == null)
            {
                return HttpNotFound();
            }
            return View(kolegij);
        }

        // POST: Kolegij/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KolegijID,Naziv,Odabran")] Kolegij kolegij)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kolegij).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            return View(kolegij);
        }

        // GET: Kolegij/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kolegij kolegij = db.Kolegij.Find(id);
            if (kolegij == null)
            {
                return HttpNotFound();
            }
            return View(kolegij);
        }

        // POST: Kolegij/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kolegij kolegij = db.Kolegij.Find(id);
            db.Kolegij.Remove(kolegij);
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
