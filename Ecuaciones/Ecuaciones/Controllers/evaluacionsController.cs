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
    public class evaluacionsController : Controller
    {
        private ecuacionesEntities db = new ecuacionesEntities();

        // GET: evaluacions
        public ActionResult Index()
        {
            var evaluacion = db.evaluacion.Include(e => e.ecuacion);
            return View(evaluacion.ToList());
        }
       

        // GET: evaluacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            evaluacion evaluacion = db.evaluacion.Find(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            return View(evaluacion);
        }

        // GET: evaluacions/Create
        public ActionResult Create([Bind(Include = "idecuacion,a,b,c")] ecuacion ecuacion)
        {
            //ViewBag.ecuacion_idecuacion = new SelectList(db.ecuacion, "idecuacion", "idecuacion");
            //return View();

            List<evaluacion> lista = new List<evaluacion>();
            evaluacion nueva = new evaluacion();
            nueva.idevaluacion = ecuacion.idecuacion + 1;
            nueva.valor = ecuacion.a + 1;
            nueva.ecuacion_idecuacion = ecuacion.idecuacion;
            for(int i = 0; i < 5; i++)
            {
                int valor = (ecuacion.a * (i ^ 2)) + (ecuacion.b * (i)) + (ecuacion.c);
                lista.Add(new evaluacion {idevaluacion,});
            }

            lista.Add(nueva);
            return View("Index", lista);


//db.evaluacion.Add(nueva);
//            db.SaveChanges();
        }

        // POST: evaluacions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "idevaluacion,valor,ecuacion_idecuacion")] evaluacion evaluacion)
        {
            if (ModelState.IsValid)
            {
                db.evaluacion.Add(evaluacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ecuacion_idecuacion = new SelectList(db.ecuacion, "idecuacion", "idecuacion", evaluacion.ecuacion_idecuacion);
            return View(evaluacion);

            
        }

        // GET: evaluacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            evaluacion evaluacion = db.evaluacion.Find(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.ecuacion_idecuacion = new SelectList(db.ecuacion, "idecuacion", "idecuacion", evaluacion.ecuacion_idecuacion);
            return View(evaluacion);
        }

        // POST: evaluacions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idevaluacion,valor,ecuacion_idecuacion")] evaluacion evaluacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evaluacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ecuacion_idecuacion = new SelectList(db.ecuacion, "idecuacion", "idecuacion", evaluacion.ecuacion_idecuacion);
            return View(evaluacion);
        }

        // GET: evaluacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            evaluacion evaluacion = db.evaluacion.Find(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            return View(evaluacion);
        }

        // POST: evaluacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            evaluacion evaluacion = db.evaluacion.Find(id);
            db.evaluacion.Remove(evaluacion);
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
