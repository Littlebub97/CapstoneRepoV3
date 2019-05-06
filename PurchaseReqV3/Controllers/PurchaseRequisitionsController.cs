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
        [Authorize(Roles ="Employee")]
        public ActionResult Index()
        {
            var purchaseRequisition = db.PurchaseRequisition.Include(p => p.User);
            return View(purchaseRequisition.ToList());
        }

        // GET: PurchaseRequisitions/Details/5
        [Authorize(Roles = "Employee")]
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
        [Authorize(Roles = "Employee")]
        public ActionResult Create()
        {
            ViewBag.dateCreated = DateTime.Now;
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: PurchaseRequisitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employee")]
        public ActionResult Create([Bind(Include = "Id,UserId,Date,Justification,ApprovalStatus")] PurchaseRequisition purchaseRequisition)
        {
            if (ModelState.IsValid)
            {
                db.PurchaseRequisition.Add(purchaseRequisition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", purchaseRequisition.UserId);
            return View(purchaseRequisition);
        }

        // GET: PurchaseRequisitions/Edit/5
        [Authorize(Roles = "Employee")]
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
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", purchaseRequisition.UserId);
            return View(purchaseRequisition);
        }

        // POST: PurchaseRequisitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employee")]
        public ActionResult Edit([Bind(Include = "Id,UserId,Date,Justification,ApprovalStatus")] PurchaseRequisition purchaseRequisition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseRequisition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", purchaseRequisition.UserId);
            return View(purchaseRequisition);
        }

        // GET: PurchaseRequisitions/Delete/5
        [Authorize(Roles = "Employee")]
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
        [Authorize(Roles = "Employee")]
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
