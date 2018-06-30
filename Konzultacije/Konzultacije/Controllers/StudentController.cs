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
    public class StudentController : Controller
    {
        private BazaDbContext db = new BazaDbContext();


        // GET: Student
        public ActionResult Popis()
        {
            var student = db.Student.Include(s => s.Studij);
            return View(student.ToList());
        }

        //ovo sam ja pisal
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Index(Student s)
        {

            return View(s);  
        }

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);

            int kolslova = student.Lozinka.Count();
            var pass = "";
            for (int i = 0; i < kolslova; i++)
            {
                pass = pass + "•";
            }
            ViewBag.Pass = pass;
            if (id == (int)Session["Student"])
            {
                return View(student);
            }
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }


        // GET: Student/Create
        public ActionResult Create()
        {
            ViewBag.StudijID = new SelectList(db.Studij, "StudijID", "Naziv");
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,Ime_I_Prezime,StudijID,Email,Lozinka,Aktivacijski_link,Aktivan")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Student.Add(student);
                db.SaveChanges();
                Session["Student"] = student.StudentID;
                return RedirectToAction("Index", "Home");
            }

            ViewBag.StudijID = new SelectList(db.Studij, "StudijID", "Naziv", student.StudijID);
            return View(student);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudijID = new SelectList(db.Studij, "StudijID", "Naziv", student.StudijID);
            return View(student);
        }

        //moji kontroler
        //public ActionResult Edit(Student s)
        //{
        //    if (s == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Student student = db.Student.Find(s.StudentID);
        //    if (student == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.StudijID = new SelectList(db.Studij, "StudijID", "Naziv", student.StudijID);
        //    return View(student);
        //}

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,Ime_I_Prezime,StudijID,Email,Lozinka,Aktivacijski_link,Aktivan")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.StudijID = new SelectList(db.Studij, "StudijID", "Naziv", student.StudijID);
            return View(student);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Student.Find(id);
            db.Student.Remove(student);
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
