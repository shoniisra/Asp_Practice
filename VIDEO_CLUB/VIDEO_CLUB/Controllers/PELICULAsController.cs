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
    public class PELICULAsController : Controller
    {
        private VIDEOEntities1 db = new VIDEOEntities1();

        // GET: PELICULAs
        public ActionResult Index()
        {
            var pELICULA = db.PELICULA.Include(p => p.DIRECTOR).Include(p => p.FORMATO).Include(p => p.GENERO);
            return View(pELICULA.ToList());
        }

        // GET: PELICULAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PELICULA pELICULA = db.PELICULA.Find(id);
            if (pELICULA == null)
            {
                return HttpNotFound();
            }
            return View(pELICULA);
        }

        // GET: PELICULAs/Create
        public ActionResult Create()
        {
            ViewBag.DIR_ID = new SelectList(db.DIRECTOR, "DIR_ID", "DIR_NOMBRE");
            ViewBag.FOR_ID = new SelectList(db.FORMATO, "FOR_ID", "FOR_NOMBRE");
            ViewBag.GEN_ID = new SelectList(db.GENERO, "GEN_ID", "GEN_NOMBRE");
            return View();
        }

        // POST: PELICULAs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PEL_ID,GEN_ID,DIR_ID,FOR_ID,PEL_NOMBRE,PEL_COSTO,PEL_FECHA_ESTRENO")] PELICULA pELICULA)
        {
            if (ModelState.IsValid)
            {
                db.PELICULA.Add(pELICULA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DIR_ID = new SelectList(db.DIRECTOR, "DIR_ID", "DIR_NOMBRE", pELICULA.DIR_ID);
            ViewBag.FOR_ID = new SelectList(db.FORMATO, "FOR_ID", "FOR_NOMBRE", pELICULA.FOR_ID);
            ViewBag.GEN_ID = new SelectList(db.GENERO, "GEN_ID", "GEN_NOMBRE", pELICULA.GEN_ID);
            return View(pELICULA);
        }

        // GET: PELICULAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PELICULA pELICULA = db.PELICULA.Find(id);
            if (pELICULA == null)
            {
                return HttpNotFound();
            }
            ViewBag.DIR_ID = new SelectList(db.DIRECTOR, "DIR_ID", "DIR_NOMBRE", pELICULA.DIR_ID);
            ViewBag.FOR_ID = new SelectList(db.FORMATO, "FOR_ID", "FOR_NOMBRE", pELICULA.FOR_ID);
            ViewBag.GEN_ID = new SelectList(db.GENERO, "GEN_ID", "GEN_NOMBRE", pELICULA.GEN_ID);
            return View(pELICULA);
        }

        // POST: PELICULAs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PEL_ID,GEN_ID,DIR_ID,FOR_ID,PEL_NOMBRE,PEL_COSTO,PEL_FECHA_ESTRENO")] PELICULA pELICULA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pELICULA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DIR_ID = new SelectList(db.DIRECTOR, "DIR_ID", "DIR_NOMBRE", pELICULA.DIR_ID);
            ViewBag.FOR_ID = new SelectList(db.FORMATO, "FOR_ID", "FOR_NOMBRE", pELICULA.FOR_ID);
            ViewBag.GEN_ID = new SelectList(db.GENERO, "GEN_ID", "GEN_NOMBRE", pELICULA.GEN_ID);
            return View(pELICULA);
        }

        // GET: PELICULAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PELICULA pELICULA = db.PELICULA.Find(id);
            if (pELICULA == null)
            {
                return HttpNotFound();
            }
            return View(pELICULA);
        }

        // POST: PELICULAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PELICULA pELICULA = db.PELICULA.Find(id);
            db.PELICULA.Remove(pELICULA);
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
