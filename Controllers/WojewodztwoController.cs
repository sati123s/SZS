﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SZS;

namespace SZS.Views
{
    [Authorize(Roles = "Kierownik")]
    public class WojewodztwoController : Controller
    {
        private SZSModel db = new SZSModel();

        // GET: Wojewodztwo
        public ActionResult Index()
        {
            return View(db.Wojewodztwo.ToList());
        }

        // GET: Wojewodztwo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wojewodztwo wojewodztwo = db.Wojewodztwo.Find(id);
            if (wojewodztwo == null)
            {
                return HttpNotFound();
            }
            return View(wojewodztwo);
        }

        // GET: Wojewodztwo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Wojewodztwo/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nazwa")] Wojewodztwo wojewodztwo)
        {
            if (ModelState.IsValid)
            {
                db.Wojewodztwo.Add(wojewodztwo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wojewodztwo);
        }

        // GET: Wojewodztwo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wojewodztwo wojewodztwo = db.Wojewodztwo.Find(id);
            if (wojewodztwo == null)
            {
                return HttpNotFound();
            }
            return View(wojewodztwo);
        }

        // POST: Wojewodztwo/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nazwa")] Wojewodztwo wojewodztwo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wojewodztwo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wojewodztwo);
        }

        // GET: Wojewodztwo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wojewodztwo wojewodztwo = db.Wojewodztwo.Find(id);
            if (wojewodztwo == null)
            {
                return HttpNotFound();
            }
            return View(wojewodztwo);
        }

        // POST: Wojewodztwo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wojewodztwo wojewodztwo = db.Wojewodztwo.Find(id);
            db.Wojewodztwo.Remove(wojewodztwo);
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
