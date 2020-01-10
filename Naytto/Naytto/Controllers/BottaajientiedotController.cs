using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Naytto.Models;

namespace Naytto.Controllers
{
    public class BottaajientiedotController : Controller
    {
        private BottikantaEntities db = new BottikantaEntities();

        // GET: Bottaajientiedot
        public ActionResult Index()
        {
            var bottaajantiedot = db.Bottaajantiedot.Include(b => b.Bottipelaaja);
            return View(bottaajantiedot.ToList());
        }

        // GET: Bottaajientiedot/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bottaajantiedot bottaajantiedot = db.Bottaajantiedot.Find(id);
            if (bottaajantiedot == null)
            {
                return HttpNotFound();
            }
            return View(bottaajantiedot);
        }

        // GET: Bottaajientiedot/Create
        public ActionResult Create()
        {
            ViewBag.BottaajaID = new SelectList(db.Bottipelaaja, "BottaajaID", "Etunimi");
            return View();
        }

        // POST: Bottaajientiedot/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KayttajaID,BottaajaID,Kayttajatunnus,Pinkoodi")] Bottaajantiedot bottaajantiedot)
        {
            if (ModelState.IsValid)
            {
                db.Bottaajantiedot.Add(bottaajantiedot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BottaajaID = new SelectList(db.Bottipelaaja, "BottaajaID", "Etunimi", bottaajantiedot.BottaajaID);
            return View(bottaajantiedot);
        }

        // GET: Bottaajientiedot/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bottaajantiedot bottaajantiedot = db.Bottaajantiedot.Find(id);
            if (bottaajantiedot == null)
            {
                return HttpNotFound();
            }
            ViewBag.BottaajaID = new SelectList(db.Bottipelaaja, "BottaajaID", "Etunimi", bottaajantiedot.BottaajaID);
            return View(bottaajantiedot);
        }

        // POST: Bottaajientiedot/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KayttajaID,BottaajaID,Kayttajatunnus,Pinkoodi")] Bottaajantiedot bottaajantiedot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bottaajantiedot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BottaajaID = new SelectList(db.Bottipelaaja, "BottaajaID", "Etunimi", bottaajantiedot.BottaajaID);
            return View(bottaajantiedot);
        }

        // GET: Bottaajientiedot/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bottaajantiedot bottaajantiedot = db.Bottaajantiedot.Find(id);
            if (bottaajantiedot == null)
            {
                return HttpNotFound();
            }
            return View(bottaajantiedot);
        }

        // POST: Bottaajientiedot/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bottaajantiedot bottaajantiedot = db.Bottaajantiedot.Find(id);
            db.Bottaajantiedot.Remove(bottaajantiedot);
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
