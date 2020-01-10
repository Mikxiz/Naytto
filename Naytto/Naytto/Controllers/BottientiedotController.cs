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
    public class BottientiedotController : Controller
    {
        private BottikantaEntities db = new BottikantaEntities();

        // GET: Bottientiedot
        public ActionResult Index()
        {
            var botintiedot = db.Botintiedot.Include(b => b.Bottaajantiedot);
            return View(botintiedot.ToList());
        }

        // GET: Bottientiedot/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Botintiedot botintiedot = db.Botintiedot.Find(id);
            if (botintiedot == null)
            {
                return HttpNotFound();
            }
            return View(botintiedot);
        }

        // GET: Bottientiedot/Create
        public ActionResult Create()
        {
            ViewBag.KayttajaID = new SelectList(db.Bottaajantiedot, "KayttajaID", "Kayttajatunnus");
            return View();
        }

        // POST: Bottientiedot/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BottiID,KayttajaID,BottiAika,BottiHalkoja,BottiKokemuspisteita,BottiRahaaTunnissa,BottiTaitotasoNousu")] Botintiedot botintiedot)
        {
            if (ModelState.IsValid)
            {
                db.Botintiedot.Add(botintiedot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KayttajaID = new SelectList(db.Bottaajantiedot, "KayttajaID", "Kayttajatunnus", botintiedot.KayttajaID);
            return View(botintiedot);
        }

        // GET: Bottientiedot/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Botintiedot botintiedot = db.Botintiedot.Find(id);
            if (botintiedot == null)
            {
                return HttpNotFound();
            }
            ViewBag.KayttajaID = new SelectList(db.Bottaajantiedot, "KayttajaID", "Kayttajatunnus", botintiedot.KayttajaID);
            return View(botintiedot);
        }

        // POST: Bottientiedot/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BottiID,KayttajaID,BottiAika,BottiHalkoja,BottiKokemuspisteita,BottiRahaaTunnissa,BottiTaitotasoNousu")] Botintiedot botintiedot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(botintiedot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KayttajaID = new SelectList(db.Bottaajantiedot, "KayttajaID", "Kayttajatunnus", botintiedot.KayttajaID);
            return View(botintiedot);
        }

        // GET: Bottientiedot/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Botintiedot botintiedot = db.Botintiedot.Find(id);
            if (botintiedot == null)
            {
                return HttpNotFound();
            }
            return View(botintiedot);
        }

        // POST: Bottientiedot/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Botintiedot botintiedot = db.Botintiedot.Find(id);
            db.Botintiedot.Remove(botintiedot);
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
