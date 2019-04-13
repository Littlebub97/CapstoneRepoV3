using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PurchaseReqV3.Models;

namespace PurchaseReqV3.Controllers
{
    public class PurchaseRequisitionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PurchaseRequisitions
        public ActionResult Index()
        {
            return View(db.PurchaseRequisition.ToList());
        }

        // GET: PurchaseRequisitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseRequisition purchaseRequisition = db.PurchaseRequisition.Find(id);
            if (purchaseRequisition == null)
            {
                return HttpNotFound();
            }
            return View(purchaseRequisition);
        }

        // GET: PurchaseRequisitions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PurchaseRequisitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,CalculatedTotal,Justification")] PurchaseRequisition purchaseRequisition)
        {
            if (ModelState.IsValid)
            {
                db.PurchaseRequisition.Add(purchaseRequisition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(purchaseRequisition);
        }

        // GET: PurchaseRequisitions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseRequisition purchaseRequisition = db.PurchaseRequisition.Find(id);
            if (purchaseRequisition == null)
            {
                return HttpNotFound();
            }
            return View(purchaseRequisition);
        }

        // POST: PurchaseRequisitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,CalculatedTotal,Justification")] PurchaseRequisition purchaseRequisition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseRequisition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(purchaseRequisition);
        }

        // GET: PurchaseRequisitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseRequisition purchaseRequisition = db.PurchaseRequisition.Find(id);
            if (purchaseRequisition == null)
            {
                return HttpNotFound();
            }
            return View(purchaseRequisition);
        }

        // POST: PurchaseRequisitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PurchaseRequisition purchaseRequisition = db.PurchaseRequisition.Find(id);
            db.PurchaseRequisition.Remove(purchaseRequisition);
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
