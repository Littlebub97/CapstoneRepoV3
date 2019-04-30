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
    public class UserBudgetCodesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserBudgetCodes
        [Authorize(Roles = "CFO, State Auditor, readonly")]
        public ActionResult Index()
        {
            var userBudgetCodes = db.UserBudgetCode.Include(u => u.Budget).Include(u => u.User);
            return View(userBudgetCodes.ToList());
        }

        // GET: UserBudgetCodes/Details/5
        [Authorize(Roles = "CFO, State Auditor, readonly")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserBudgetCode userBudgetCode = db.UserBudgetCode.Find(id);
            if (userBudgetCode == null)
            {
                return HttpNotFound();
            }
            return View(userBudgetCode);
        }

        // GET: UserBudgetCodes/Create
        [Authorize(Roles = "CFO, State Auditor, readonly")]
        public ActionResult Create()
        {
            ViewBag.BudgetId = new SelectList(db.Budget, "Id", "Name");
            ViewBag.UserId = new SelectList(db.User, "Id", "Email");
            return View();
        }

        // POST: UserBudgetCodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CFO, State Auditor, readonly")]
        public ActionResult Create([Bind(Include = "Id,UserId,BudgetId")] UserBudgetCode userBudgetCode)
        {
            if (ModelState.IsValid)
            {
                db.UserBudgetCode.Add(userBudgetCode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BudgetId = new SelectList(db.Budget, "Id", "Name", userBudgetCode.BudgetId);
            ViewBag.UserId = new SelectList(db.User, "Id", "Email", userBudgetCode.UserId);
            return View(userBudgetCode);
        }

        // GET: UserBudgetCodes/Edit/5
        [Authorize(Roles = "CFO, State Auditor, readonly")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserBudgetCode userBudgetCode = db.UserBudgetCode.Find(id);
            if (userBudgetCode == null)
            {
                return HttpNotFound();
            }
            ViewBag.BudgetId = new SelectList(db.Budget, "Id", "Name", userBudgetCode.BudgetId);
            ViewBag.UserId = new SelectList(db.User, "Id", "Email", userBudgetCode.UserId);
            return View(userBudgetCode);
        }

        // POST: UserBudgetCodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CFO, State Auditor, readonly")]
        public ActionResult Edit([Bind(Include = "Id,UserId,BudgetId")] UserBudgetCode userBudgetCode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userBudgetCode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BudgetId = new SelectList(db.Budget, "Id", "Name", userBudgetCode.BudgetId);
            ViewBag.UserId = new SelectList(db.User, "Id", "Email", userBudgetCode.UserId);
            return View(userBudgetCode);
        }

        // GET: UserBudgetCodes/Delete/5
        [Authorize(Roles = "CFO, State Auditor, readonly")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserBudgetCode userBudgetCode = db.UserBudgetCode.Find(id);
            if (userBudgetCode == null)
            {
                return HttpNotFound();
            }
            return View(userBudgetCode);
        }

        // POST: UserBudgetCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CFO, State Auditor, readonly")]
        public ActionResult DeleteConfirmed(int id)
        {
            UserBudgetCode userBudgetCode = db.UserBudgetCode.Find(id);
            db.UserBudgetCode.Remove(userBudgetCode);
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
