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
    public class parroquiasController : Controller
    {
        private mydbEntities db = new mydbEntities();

        // GET: parroquias
        public ActionResult Index()
        {
            var parroquia = db.parroquia.Include(p => p.ciudad);
            return View(parroquia.ToList());
        }

        // GET: parroquias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            parroquia parroquia = db.parroquia.Find(id);
            if (parroquia == null)
            {
                return HttpNotFound();
            }
            return View(parroquia);
        }

        // GET: parroquias/Create
        public ActionResult Create()
        {
            ViewBag.ciudad_idciudad = new SelectList(db.ciudad, "idciudad", "ciu_nombre");
            return View();
        }

        // POST: parroquias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idparroquia,par_nombre,ciudad_idciudad")] parroquia parroquia)
        {
            if (ModelState.IsValid)
            {
                db.parroquia.Add(parroquia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ciudad_idciudad = new SelectList(db.ciudad, "idciudad", "ciu_nombre", parroquia.ciudad_idciudad);
            return View(parroquia);
        }

        // GET: parroquias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            parroquia parroquia = db.parroquia.Find(id);
            if (parroquia == null)
            {
                return HttpNotFound();
            }
            ViewBag.ciudad_idciudad = new SelectList(db.ciudad, "idciudad", "ciu_nombre", parroquia.ciudad_idciudad);
            return View(parroquia);
        }

        // POST: parroquias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idparroquia,par_nombre,ciudad_idciudad")] parroquia parroquia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parroquia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ciudad_idciudad = new SelectList(db.ciudad, "idciudad", "ciu_nombre", parroquia.ciudad_idciudad);
            return View(parroquia);
        }

        // GET: parroquias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            parroquia parroquia = db.parroquia.Find(id);
            if (parroquia == null)
            {
                return HttpNotFound();
            }
            return View(parroquia);
        }

        // POST: parroquias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            parroquia parroquia = db.parroquia.Find(id);
            db.parroquia.Remove(parroquia);
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
