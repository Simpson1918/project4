using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project4.Models;

namespace Project4.Controllers 
{
    public class AnXasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AnXas  
        public ActionResult Index()
        {
            return View(db.AnXa.ToList());
        }

        // GET: AnXas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnXa anXa = db.AnXa.Find(id);
            if (anXa == null)
            {
                return HttpNotFound();
            }
            return View(anXa);
        }

        // GET: AnXas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnXas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PhamNhanID,MucDoAnXa,MucDoCaiTao")] AnXa anXa)
        {
            if (ModelState.IsValid)
            {
                db.AnXa.Add(anXa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(anXa);
        }

        // GET: AnXas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnXa anXa = db.AnXa.Find(id);
            if (anXa == null)
            {
                return HttpNotFound();
            }
            return View(anXa);
        }

        // POST: AnXas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PhamNhanID,MucDoAnXa,MucDoCaiTao")] AnXa anXa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anXa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(anXa);
        }

        // GET: AnXas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) 
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnXa anXa = db.AnXa.Find(id);
            if (anXa == null)
            {
                return HttpNotFound();
            }
            return View(anXa);
        }

        // POST: AnXas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnXa anXa = db.AnXa.Find(id);
            db.AnXa.Remove(anXa);
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
