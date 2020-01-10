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
    public class BottipelaajatController : Controller
    {
        private BottikantaEntities db = new BottikantaEntities();

        // GET: Bottipelaajat
        public ActionResult Index()
        {
            return View(db.Bottipelaaja.ToList());
        }

        // GET: Bottipelaajat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bottipelaaja bottipelaaja = db.Bottipelaaja.Find(id);
            if (bottipelaaja == null)
            {
                return HttpNotFound();
            }
            return View(bottipelaaja);
        }

        // GET: Bottipelaajat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bottipelaajat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BottaajaID,Etunimi,Sukunimi")] Bottipelaaja bottipelaaja)
        {
            if (ModelState.IsValid)
            {
                db.Bottipelaaja.Add(bottipelaaja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bottipelaaja);
        }

        // GET: Bottipelaajat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bottipelaaja bottipelaaja = db.Bottipelaaja.Find(id);
            if (bottipelaaja == null)
            {
                return HttpNotFound();
            }
            return View(bottipelaaja);
        }

        // POST: Bottipelaajat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BottaajaID,Etunimi,Sukunimi")] Bottipelaaja bottipelaaja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bottipelaaja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bottipelaaja);
        }

        // GET: Bottipelaajat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bottipelaaja bottipelaaja = db.Bottipelaaja.Find(id);
            if (bottipelaaja == null)
            {
                return HttpNotFound();
            }
            return View(bottipelaaja);
        }

        // POST: Bottipelaajat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bottipelaaja bottipelaaja = db.Bottipelaaja.Find(id);
            db.Bottipelaaja.Remove(bottipelaaja);
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
