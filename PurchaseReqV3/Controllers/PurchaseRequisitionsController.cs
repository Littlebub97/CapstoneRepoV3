using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PurchaseReqV3.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PurchaseReqV3.ViewModels;

namespace PurchaseReqV3.Controllers
{
    public class PurchaseRequisitionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private UserManager<User> userManager;

        public PurchaseRequisitionsController()
        {
            userManager = new UserManager<User>(new UserStore<User>(db));
        }

          public ActionResult CreatePurchaseReqwithItemsandVendor()
        {
            var User = new List<User>()
            {
                new User {UserName = "Admin@web.com"}
            };
            var Item = new List<Item>()
            {
              new Item {Name="dumb", UnitPrice =50.00M, Description="Because", Quantity= 1  }
            };
            var Vendor = new List<Vendor>()
            {
               new Vendor{Name="Amazon", StateContract=false, Phone=null}
            };
            var PurchaseReq = new List<PurchaseRequisition>()
            {
                new PurchaseRequisition{Date = DateTime.Now, Justification="Because" }
            };

            var Budget = new List<Budget>()
            {
                new Budget { Amount= 500.00M, DateCreated=DateTime.Now, Name="CS", Type = Models.Budget.TYPE.Annual, DateEnded=null }
            };

            var PurchaseReqwithItemsandVendor = new PurchaseReqWithItemsandVendor
            {
                Items = Item,
                Users = User


            };
            return View(PurchaseReqwithItemsandVendor);
        }


        // GET: PurchaseRequisitions
        [Authorize(Roles = "Employee, President, Chair Science Technology Engineering and Math, readonly")]
        public async Task<ActionResult> Index()
        {
            var loggedInUser = await userManager.FindByNameAsync(User.Identity.Name);
            
            var purchaseRequisition = db.PurchaseRequisition.Include(p => p.Budgets).Include(p => p.User).Where(x =>  x.User.Id == loggedInUser.Id);
            try
            {
                return View(purchaseRequisition.ToList());
            }
            catch(Exception e)
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
        }

        public ActionResult CannotDelete()
        {
            return View();
        }

        // GET: PurchaseRequisitions/Details/5
        [Authorize(Roles = "Employee, President")]
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
        [Authorize(Roles = "Employee, President")]
        public async Task<ActionResult> Create()
        {
            var loggedInUser = await userManager.FindByNameAsync(User.Identity.Name);

            ViewBag.dateCreated = DateTime.Now;
            ViewBag.BudgetId = new SelectList(db.Budget, "Id", "Name");
            return View(new PurchaseRequisition()
            {
                UserId = loggedInUser.Id
            });
        }

        // POST: PurchaseRequisitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employee, President")]
        public ActionResult Create([Bind(Include = "Id,UserId,Date,Justification,BudgetId")] PurchaseRequisition purchaseRequisition)
        {
            purchaseRequisition.Date = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.PurchaseRequisition.Add(purchaseRequisition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BudgetId = new SelectList(db.Budget, "Id", "Name", purchaseRequisition.BudgetId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", purchaseRequisition.UserId);
            return View(purchaseRequisition);
        }

        // GET: PurchaseRequisitions/Edit/5
        [Authorize(Roles = "Employee, President")]
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
            ViewBag.BudgetId = new SelectList(db.Budget, "Id", "Name", purchaseRequisition.BudgetId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", purchaseRequisition.UserId);
            return View(purchaseRequisition);
        }

        // POST: PurchaseRequisitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employee, President")]
        public ActionResult Edit([Bind(Include = "Id,UserId,Date,Justification,ApprovalStatus,BudgetId")] PurchaseRequisition purchaseRequisition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseRequisition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BudgetId = new SelectList(db.Budget, "Id", "Name", purchaseRequisition.BudgetId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", purchaseRequisition.UserId);
            return View(purchaseRequisition);
        }

        // GET: PurchaseRequisitions/Delete/5
        [Authorize(Roles = "Employee, President")]
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
        [Authorize(Roles = "Employee, President")]
        public ActionResult DeleteConfirmed(int id)
        {
            PurchaseRequisition purchaseRequisition = db.PurchaseRequisition.Find(id);
            Item item = db.Item.Find(id);
            Approval approval = db.Approval.Find(id);
            db.PurchaseRequisition.Remove(purchaseRequisition);
            try
            {
                db.Item.Remove(item);
            }
            catch (Exception e)
            {
                return RedirectToAction("CannotDelete");
            }
            try
            {
                db.Approval.Remove(approval);
            }
            catch(Exception e)
            {
                return RedirectToAction("CannotDelete");
            }
            try
            {
                db.SaveChanges();
            }
            catch(Exception e)
            { return RedirectToAction("CannotDelete"); }
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
