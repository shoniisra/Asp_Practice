using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ecuaciones.Models;

namespace Ecuaciones.Controllers
{
    public class ecuacionsController : Controller
    {
        private ecuacionesEntities db = new ecuacionesEntities();

        // GET: ecuacions
        public ActionResult Index()
        {
            return View(db.ecuacion.ToList());
        }

        // GET: ecuacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ecuacion ecuacion = db.ecuacion.Find(id);
            if (ecuacion == null)
            {
                return HttpNotFound();
            }
            return View(ecuacion);
        }

        // GET: ecuacions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ecuacions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idecuacion,a,b,c")] ecuacion ecuacion)
        {
            if (ModelState.IsValid)
            {
                db.ecuacion.Add(ecuacion);
                db.SaveChanges();
                return RedirectToAction("Create","evaluacions",ecuacion);
            }

            return View(ecuacion);
        }

        // GET: ecuacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ecuacion ecuacion = db.ecuacion.Find(id);
            if (ecuacion == null)
            {
                return HttpNotFound();
            }
            return View(ecuacion);
        }

        // POST: ecuacions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idecuacion,a,b,c")] ecuacion ecuacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ecuacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ecuacion);
        }

        // GET: ecuacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ecuacion ecuacion = db.ecuacion.Find(id);
            if (ecuacion == null)
            {
                return HttpNotFound();
            }
            return View(ecuacion);
        }

        // POST: ecuacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ecuacion ecuacion = db.ecuacion.Find(id);
            db.ecuacion.Remove(ecuacion);
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
