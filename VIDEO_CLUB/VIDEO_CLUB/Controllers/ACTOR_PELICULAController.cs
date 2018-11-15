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
    public class ACTOR_PELICULAController : Controller
    {
        private VIDEOEntities1 db = new VIDEOEntities1();

        // GET: ACTOR_PELICULA
        public ActionResult Index()
        {
            var aCTOR_PELICULA = db.ACTOR_PELICULA.Include(a => a.ACTOR).Include(a => a.PELICULA);
            return View(aCTOR_PELICULA.ToList());
        }

        // GET: ACTOR_PELICULA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACTOR_PELICULA aCTOR_PELICULA = db.ACTOR_PELICULA.Find(id);
            if (aCTOR_PELICULA == null)
            {
                return HttpNotFound();
            }
            return View(aCTOR_PELICULA);
        }

        // GET: ACTOR_PELICULA/Create
        public ActionResult Create()
        {
            ViewBag.ACT_ID = new SelectList(db.ACTOR, "ACT_ID", "ACT_NOMBRE");
            ViewBag.PEL_ID = new SelectList(db.PELICULA, "PEL_ID", "PEL_NOMBRE");
            return View();
        }

        // POST: ACTOR_PELICULA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "APL_ID,ACT_ID,PEL_ID,APL_PAPEL")] ACTOR_PELICULA aCTOR_PELICULA)
        {
            if (ModelState.IsValid)
            {
                db.ACTOR_PELICULA.Add(aCTOR_PELICULA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ACT_ID = new SelectList(db.ACTOR, "ACT_ID", "ACT_NOMBRE", aCTOR_PELICULA.ACT_ID);
            ViewBag.PEL_ID = new SelectList(db.PELICULA, "PEL_ID", "PEL_NOMBRE", aCTOR_PELICULA.PEL_ID);
            return View(aCTOR_PELICULA);
        }

        // GET: ACTOR_PELICULA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACTOR_PELICULA aCTOR_PELICULA = db.ACTOR_PELICULA.Find(id);
            if (aCTOR_PELICULA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ACT_ID = new SelectList(db.ACTOR, "ACT_ID", "ACT_NOMBRE", aCTOR_PELICULA.ACT_ID);
            ViewBag.PEL_ID = new SelectList(db.PELICULA, "PEL_ID", "PEL_NOMBRE", aCTOR_PELICULA.PEL_ID);
            return View(aCTOR_PELICULA);
        }

        // POST: ACTOR_PELICULA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "APL_ID,ACT_ID,PEL_ID,APL_PAPEL")] ACTOR_PELICULA aCTOR_PELICULA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aCTOR_PELICULA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ACT_ID = new SelectList(db.ACTOR, "ACT_ID", "ACT_NOMBRE", aCTOR_PELICULA.ACT_ID);
            ViewBag.PEL_ID = new SelectList(db.PELICULA, "PEL_ID", "PEL_NOMBRE", aCTOR_PELICULA.PEL_ID);
            return View(aCTOR_PELICULA);
        }

        // GET: ACTOR_PELICULA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACTOR_PELICULA aCTOR_PELICULA = db.ACTOR_PELICULA.Find(id);
            if (aCTOR_PELICULA == null)
            {
                return HttpNotFound();
            }
            return View(aCTOR_PELICULA);
        }

        // POST: ACTOR_PELICULA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ACTOR_PELICULA aCTOR_PELICULA = db.ACTOR_PELICULA.Find(id);
            db.ACTOR_PELICULA.Remove(aCTOR_PELICULA);
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
