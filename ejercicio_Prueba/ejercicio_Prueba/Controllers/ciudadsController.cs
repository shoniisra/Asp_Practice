using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ejercicio_Prueba.Models;

namespace ejercicio_Prueba.Controllers
{
    public class ciudadsController : Controller
    {
        private mydbEntities db = new mydbEntities();

        // GET: ciudads
        public ActionResult Index()
        {
            var ciudad = db.ciudad.Include(c => c.provincia);
            return View(ciudad.ToList());
        }

        // GET: ciudads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ciudad ciudad = db.ciudad.Find(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            return View(ciudad);
        }

        // GET: ciudads/Create
        public ActionResult Create()
        {
            ViewBag.provincia_idprovincia = new SelectList(db.provincia, "idprovincia", "prov_nombre");
            return View();
        }

        // POST: ciudads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idciudad,ciu_nombre,provincia_idprovincia")] ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                db.ciudad.Add(ciudad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.provincia_idprovincia = new SelectList(db.provincia, "idprovincia", "prov_nombre", ciudad.provincia_idprovincia);
            return View(ciudad);
        }

        // GET: ciudads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ciudad ciudad = db.ciudad.Find(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            ViewBag.provincia_idprovincia = new SelectList(db.provincia, "idprovincia", "prov_nombre", ciudad.provincia_idprovincia);
            return View(ciudad);
        }

        // POST: ciudads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idciudad,ciu_nombre,provincia_idprovincia")] ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ciudad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.provincia_idprovincia = new SelectList(db.provincia, "idprovincia", "prov_nombre", ciudad.provincia_idprovincia);
            return View(ciudad);
        }

        // GET: ciudads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ciudad ciudad = db.ciudad.Find(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            return View(ciudad);
        }

        // POST: ciudads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ciudad ciudad = db.ciudad.Find(id);
            db.ciudad.Remove(ciudad);
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
