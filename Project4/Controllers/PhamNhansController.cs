﻿using System;
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
    public class PhamNhansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PhamNhans
        public ActionResult Index()      
        { 
            var khuList = db.Khu.ToList();
            ViewBag.Khu = new SelectList(khuList, "ID", "ID");
              
            var phongList = db.PhongGiam.ToList(); 
            ViewBag.Phong = new SelectList(phongList, "ID", "ID");

            return View(db.PhamNhan.ToList());
        } 

        // GET: PhamNhans/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhamNhan phamNhan = db.PhamNhan.Find(id);
            if (phamNhan == null)
            {
                return HttpNotFound();
            }
            return View(phamNhan);
        }

        // GET: PhamNhans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhamNhans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenPhamNhan,BiDanh,AnhNhanDien,QueQuan,NgaySinh,GioiTinh,IDKhu,ToiDanh,MucDoNguyHiem,SoNgayGiamGiu,CMND,QuaTrinhGayAn,DiaDiemGayAn,PhongGiamID")] PhamNhan phamNhan)
        {
            if (ModelState.IsValid)
            {
                phamNhan.ID = Guid.NewGuid();
                db.PhamNhan.Add(phamNhan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phamNhan);
        }

        // GET: PhamNhans/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhamNhan phamNhan = db.PhamNhan.Find(id);
            if (phamNhan == null)
            {
                return HttpNotFound();
            }
            return View(phamNhan);
        }

        // POST: PhamNhans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenPhamNhan,BiDanh,AnhNhanDien,QueQuan,NgaySinh,GioiTinh,IDKhu,ToiDanh,MucDoNguyHiem,SoNgayGiamGiu,CMND,QuaTrinhGayAn,DiaDiemGayAn,PhongGiamID")] PhamNhan phamNhan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phamNhan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phamNhan);
        }

        // GET: PhamNhans/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhamNhan phamNhan = db.PhamNhan.Find(id);
            if (phamNhan == null)
            {
                return HttpNotFound();
            }
            return View(phamNhan);
        }

        // POST: PhamNhans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            PhamNhan phamNhan = db.PhamNhan.Find(id);
            db.PhamNhan.Remove(phamNhan);
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
