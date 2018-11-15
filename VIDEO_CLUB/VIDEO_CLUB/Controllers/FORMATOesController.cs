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
    public class FORMATOesController : Controller
    {
        private VIDEOEntities1 db = new VIDEOEntities1();

        // GET: FORMATOes
        public ActionResult Index()
        {
            return View(db.FORMATO.ToList());
        }

        // GET: FORMATOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FORMATO fORMATO = db.FORMATO.Find(id);
            if (fORMATO == null)
            {
                return HttpNotFound();
            }
            return View(fORMATO);
        }

        // GET: FORMATOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FORMATOes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FOR_ID,FOR_NOMBRE")] FORMATO fORMATO)
        {
            if (ModelState.IsValid)
            {
                db.FORMATO.Add(fORMATO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fORMATO);
        }

        // GET: FORMATOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FORMATO fORMATO = db.FORMATO.Find(id);
            if (fORMATO == null)
            {
                return HttpNotFound();
            }
            return View(fORMATO);
        }

        // POST: FORMATOes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FOR_ID,FOR_NOMBRE")] FORMATO fORMATO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fORMATO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fORMATO);
        }

        // GET: FORMATOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FORMATO fORMATO = db.FORMATO.Find(id);
            if (fORMATO == null)
            {
                return HttpNotFound();
            }
            return View(fORMATO);
        }

        // POST: FORMATOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FORMATO fORMATO = db.FORMATO.Find(id);
            db.FORMATO.Remove(fORMATO);
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
