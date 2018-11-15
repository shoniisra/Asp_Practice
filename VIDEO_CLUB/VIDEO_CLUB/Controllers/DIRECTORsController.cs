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
    public class DIRECTORsController : Controller
    {
        private VIDEOEntities1 db = new VIDEOEntities1();

        // GET: DIRECTORs
        public ActionResult Index()
        {
            return View(db.DIRECTOR.ToList());
        }

        // GET: DIRECTORs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIRECTOR dIRECTOR = db.DIRECTOR.Find(id);
            if (dIRECTOR == null)
            {
                return HttpNotFound();
            }
            return View(dIRECTOR);
        }

        // GET: DIRECTORs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DIRECTORs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DIR_ID,DIR_NOMBRE")] DIRECTOR dIRECTOR)
        {
            if (ModelState.IsValid)
            {
                db.DIRECTOR.Add(dIRECTOR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dIRECTOR);
        }

        // GET: DIRECTORs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIRECTOR dIRECTOR = db.DIRECTOR.Find(id);
            if (dIRECTOR == null)
            {
                return HttpNotFound();
            }
            return View(dIRECTOR);
        }

        // POST: DIRECTORs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DIR_ID,DIR_NOMBRE")] DIRECTOR dIRECTOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dIRECTOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dIRECTOR);
        }

        // GET: DIRECTORs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIRECTOR dIRECTOR = db.DIRECTOR.Find(id);
            if (dIRECTOR == null)
            {
                return HttpNotFound();
            }
            return View(dIRECTOR);
        }

        // POST: DIRECTORs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DIRECTOR dIRECTOR = db.DIRECTOR.Find(id);
            db.DIRECTOR.Remove(dIRECTOR);
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
