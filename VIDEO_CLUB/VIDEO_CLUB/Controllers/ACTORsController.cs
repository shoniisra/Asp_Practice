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
    public class ACTORsController : Controller
    {
        private VIDEOEntities1 db = new VIDEOEntities1();

        // GET: ACTORs
        public ActionResult Index()
        {
            var aCTOR = db.ACTOR.Include(a => a.SEXO);
            return View(aCTOR.ToList());
        }

        // GET: ACTORs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACTOR aCTOR = db.ACTOR.Find(id);
            if (aCTOR == null)
            {
                return HttpNotFound();
            }
            return View(aCTOR);
        }

        // GET: ACTORs/Create
        public ActionResult Create()
        {
            ViewBag.SEX_ID = new SelectList(db.SEXO, "SEX_ID", "SEX_NOMBRE");
            return View();
        }

        // POST: ACTORs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ACT_ID,SEX_ID,ACT_NOMBRE")] ACTOR aCTOR)
        {
            if (ModelState.IsValid)
            {
                db.ACTOR.Add(aCTOR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SEX_ID = new SelectList(db.SEXO, "SEX_ID", "SEX_NOMBRE", aCTOR.SEX_ID);
            return View(aCTOR);
        }

        // GET: ACTORs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACTOR aCTOR = db.ACTOR.Find(id);
            if (aCTOR == null)
            {
                return HttpNotFound();
            }
            ViewBag.SEX_ID = new SelectList(db.SEXO, "SEX_ID", "SEX_NOMBRE", aCTOR.SEX_ID);
            return View(aCTOR);
        }

        // POST: ACTORs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ACT_ID,SEX_ID,ACT_NOMBRE")] ACTOR aCTOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aCTOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SEX_ID = new SelectList(db.SEXO, "SEX_ID", "SEX_NOMBRE", aCTOR.SEX_ID);
            return View(aCTOR);
        }

        // GET: ACTORs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACTOR aCTOR = db.ACTOR.Find(id);
            if (aCTOR == null)
            {
                return HttpNotFound();
            }
            return View(aCTOR);
        }

        // POST: ACTORs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ACTOR aCTOR = db.ACTOR.Find(id);
            db.ACTOR.Remove(aCTOR);
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
