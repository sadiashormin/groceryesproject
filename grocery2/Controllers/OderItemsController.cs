﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using grocery2;

namespace grocery2.Controllers
{
    public class OderItemsController : Controller
    {
        private groceryEntities db = new groceryEntities();

        // GET: OderItems
        public ActionResult Index()
        {
            var oderItems = db.OderItems.Include(o => o.Order).Include(o => o.Product);
            return View(oderItems.ToList());
        }

        // GET: OderItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OderItem oderItem = db.OderItems.Find(id);
            if (oderItem == null)
            {
                return HttpNotFound();
            }
            return View(oderItem);
        }

        // GET: OderItems/Create
        public ActionResult Create()
        {
            ViewBag.OrderId = new SelectList(db.Orders, "Id", "Id");
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name");
            return View();
        }

        // POST: OderItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Quantity,OrderId,ProductId")] OderItem oderItem)
        {
            if (ModelState.IsValid)
            {
                db.OderItems.Add(oderItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrderId = new SelectList(db.Orders, "Id", "Id", oderItem.OrderId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", oderItem.ProductId);
            return View(oderItem);
        }

        // GET: OderItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OderItem oderItem = db.OderItems.Find(id);
            if (oderItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderId = new SelectList(db.Orders, "Id", "Id", oderItem.OrderId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", oderItem.ProductId);
            return View(oderItem);
        }

        // POST: OderItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Quantity,OrderId,ProductId")] OderItem oderItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oderItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrderId = new SelectList(db.Orders, "Id", "Id", oderItem.OrderId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", oderItem.ProductId);
            return View(oderItem);
        }

        // GET: OderItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OderItem oderItem = db.OderItems.Find(id);
            if (oderItem == null)
            {
                return HttpNotFound();
            }
            return View(oderItem);
        }

        // POST: OderItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OderItem oderItem = db.OderItems.Find(id);
            db.OderItems.Remove(oderItem);
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
