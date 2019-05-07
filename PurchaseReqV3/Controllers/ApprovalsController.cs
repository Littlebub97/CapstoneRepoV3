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
    public class ApprovalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Approvals
        public ActionResult Index()
        {
            var approvals = db.Approval.Include(a => a.purchaseRequisition);
            return View(approvals.ToList());
        }

        // GET: Approvals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Approval approval = db.Approval.Find(id);
            if (approval == null)
            {
                return HttpNotFound();
            }
            return View(approval);
        }

        // GET: Approvals/Create
        public ActionResult Create()
        {
            ViewBag.PurchaseRequisitionId = new SelectList(db.PurchaseRequisition, "Id", "UserId");
            return View();
        }

        // POST: Approvals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PurchaseRequisitionId,ApprovalStatus,ReasonForDenial")] Approval approval)
        {
            if (ModelState.IsValid)
            {
                db.Approval.Add(approval);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PurchaseRequisitionId = new SelectList(db.PurchaseRequisition, "Id", "UserId", approval.PurchaseRequisitionId);
            return View(approval);
        }

        // GET: Approvals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Approval approval = db.Approval.Find(id);
            if (approval == null)
            {
                return HttpNotFound();
            }
            ViewBag.PurchaseRequisitionId = new SelectList(db.PurchaseRequisition, "Id", "UserId", approval.PurchaseRequisitionId);
            return View(approval);
        }

        // POST: Approvals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PurchaseRequisitionId,ApprovalStatus,ReasonForDenial")] Approval approval)
        {
            if (ModelState.IsValid)
            {
                db.Entry(approval).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PurchaseRequisitionId = new SelectList(db.PurchaseRequisition, "Id", "UserId", approval.PurchaseRequisitionId);
            return View(approval);
        }

        // GET: Approvals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Approval approval = db.Approval.Find(id);
            if (approval == null)
            {
                return HttpNotFound();
            }
            return View(approval);
        }

        // POST: Approvals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Approval approval = db.Approval.Find(id);
            db.Approval.Remove(approval);
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
