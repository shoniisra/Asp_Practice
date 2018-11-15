using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VIDEO_CLUB;

namespace VIDEO_CLUB.Controllers
{
    public class SOCIOsController : Controller
    {
        private VIDEOEntities1 db = new VIDEOEntities1();

        // GET: SOCIOs
        public ActionResult Index()
        {
            return View(db.SOCIO.ToList());
        }

        // GET: SOCIOs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOCIO sOCIO = db.SOCIO.Find(id);
            if (sOCIO == null)
            {
                return HttpNotFound();
            }
            return View(sOCIO);
        }

        // GET: SOCIOs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SOCIOs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SOC_ID,SOC_CEDULA,SOC_NOMBRE,SOC_DIRECCION,SOC_TELEFONO,SOC_CORREO")] SOCIO sOCIO)
        {
            if (ModelState.IsValid)
            {
                db.SOCIO.Add(sOCIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sOCIO);
        }

        // GET: SOCIOs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOCIO sOCIO = db.SOCIO.Find(id);
            if (sOCIO == null)
            {
                return HttpNotFound();
            }
            return View(sOCIO);
        }

        // POST: SOCIOs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SOC_ID,SOC_CEDULA,SOC_NOMBRE,SOC_DIRECCION,SOC_TELEFONO,SOC_CORREO")] SOCIO sOCIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sOCIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sOCIO);
        }

        // GET: SOCIOs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOCIO sOCIO = db.SOCIO.Find(id);
            if (sOCIO == null)
            {
                return HttpNotFound();
            }
            return View(sOCIO);
        }

        // POST: SOCIOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SOCIO sOCIO = db.SOCIO.Find(id);
            db.SOCIO.Remove(sOCIO);
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
