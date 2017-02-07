using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SettleFramework.Models;

namespace SettleFramework.Controllers
{
    public class PaymentRequestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PaymentRequests
        public ActionResult Index()
        {
            return View(db.PaymentRequests.ToList());
        }

        // GET: PaymentRequests/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentRequest paymentRequest = db.PaymentRequests.Find(id);
            if (paymentRequest == null)
            {
                return HttpNotFound();
            }
            return View(paymentRequest);
        }

        // GET: PaymentRequests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymentRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RequestID,RequestAmount,RequestedEmail,RequestedPhone,RequestFromNickName,RequestFromFirstName,RequestFromLastName,RequestFromAddress1,RequestFromAddress2,RequestTime")] PaymentRequest paymentRequest)
        {
            if (ModelState.IsValid)
            {
                paymentRequest.RequestID = Guid.NewGuid();
                db.PaymentRequests.Add(paymentRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paymentRequest);
        }

        // GET: PaymentRequests/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentRequest paymentRequest = db.PaymentRequests.Find(id);
            if (paymentRequest == null)
            {
                return HttpNotFound();
            }
            return View(paymentRequest);
        }

        // POST: PaymentRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RequestID,RequestAmount,RequestedEmail,RequestedPhone,RequestFromNickName,RequestFromFirstName,RequestFromLastName,RequestFromAddress1,RequestFromAddress2,RequestTime")] PaymentRequest paymentRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paymentRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paymentRequest);
        }

        // GET: PaymentRequests/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentRequest paymentRequest = db.PaymentRequests.Find(id);
            if (paymentRequest == null)
            {
                return HttpNotFound();
            }
            return View(paymentRequest);
        }

        // POST: PaymentRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            PaymentRequest paymentRequest = db.PaymentRequests.Find(id);
            db.PaymentRequests.Remove(paymentRequest);
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
