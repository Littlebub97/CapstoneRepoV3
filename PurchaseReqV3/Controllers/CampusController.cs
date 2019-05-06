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
    public class CampusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Campus
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var campus = db.Campus.Include(c => c.Address).Include(c => c.College);
            return View(campus.ToList());
        }

        // GET: Campus/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campus campus = db.Campus.Find(id);
            if (campus == null)
            {
                return HttpNotFound();
            }
            return View(campus);
        }

        // GET: Campus/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.AddressId = new SelectList(db.Address, "Id", "Country");
            ViewBag.CollegeId = new SelectList(db.College, "Id", "CollegeName");
            return View();
        }

        // POST: Campus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Id,Name,AddressId,CollegeId")] Campus campus)
        {
            if (ModelState.IsValid)
            {
                db.Campus.Add(campus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AddressId = new SelectList(db.Address, "Id", "Country", campus.AddressId);
            ViewBag.CollegeId = new SelectList(db.College, "Id", "CollegeName", campus.CollegeId);
            return View(campus);
        }

        // GET: Campus/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campus campus = db.Campus.Find(id);
            if (campus == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddressId = new SelectList(db.Address, "Id", "Country", campus.AddressId);
            ViewBag.CollegeId = new SelectList(db.College, "Id", "CollegeName", campus.CollegeId);
            return View(campus);
        }

        // POST: Campus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,Name,AddressId,CollegeId")] Campus campus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(campus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddressId = new SelectList(db.Address, "Id", "Country", campus.AddressId);
            ViewBag.CollegeId = new SelectList(db.College, "Id", "CollegeName", campus.CollegeId);
            return View(campus);
        }

        // GET: Campus/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campus campus = db.Campus.Find(id);
            if (campus == null)
            {
                return HttpNotFound();
            }
            return View(campus);
        }

        // POST: Campus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Campus campus = db.Campus.Find(id);
            db.Campus.Remove(campus);
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
