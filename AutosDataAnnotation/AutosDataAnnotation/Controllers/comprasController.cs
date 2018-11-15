using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutosDataAnnotation;

namespace AutosDataAnnotation.Controllers
{
    public class comprasController : Controller
    {
        private autosdbEntities1 db = new autosdbEntities1();

        // GET: compras
        public ActionResult Index()
        {
            var compra = db.compra.Include(c => c.auto).Include(c => c.cliente);
            return View(compra.ToList());
        }

        // GET: compras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            compra compra = db.compra.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // GET: compras/Create
        public ActionResult Create()
        {
            ViewBag.auto_auto_id = new SelectList(db.auto, "auto_id", "auto_placa");
            ViewBag.cliente_cli_id = new SelectList(db.cliente, "cli_id", "cli_nombre");
            return View();
        }

        // POST: compras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "com_id,com_fecha,con_subtotal,con_iva,con_total,auto_auto_id,cliente_cli_id")] compra compra)
        {
            if (ModelState.IsValid)
            {
                db.compra.Add(compra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.auto_auto_id = new SelectList(db.auto, "auto_id", "auto_placa", compra.auto_auto_id);
            ViewBag.cliente_cli_id = new SelectList(db.cliente, "cli_id", "cli_nombre", compra.cliente_cli_id);
            return View(compra);
        }

        // GET: compras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            compra compra = db.compra.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            ViewBag.auto_auto_id = new SelectList(db.auto, "auto_id", "auto_placa", compra.auto_auto_id);
            ViewBag.cliente_cli_id = new SelectList(db.cliente, "cli_id", "cli_nombre", compra.cliente_cli_id);
            return View(compra);
        }

        // POST: compras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "com_id,com_fecha,con_subtotal,con_iva,con_total,auto_auto_id,cliente_cli_id")] compra compra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.auto_auto_id = new SelectList(db.auto, "auto_id", "auto_placa", compra.auto_auto_id);
            ViewBag.cliente_cli_id = new SelectList(db.cliente, "cli_id", "cli_nombre", compra.cliente_cli_id);
            return View(compra);
        }

        // GET: compras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            compra compra = db.compra.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // POST: compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            compra compra = db.compra.Find(id);
            db.compra.Remove(compra);
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
