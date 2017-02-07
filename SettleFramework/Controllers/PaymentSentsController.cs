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
    public class PaymentSentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PaymentSents
        public ActionResult Index()
        {
            return View(db.PaymentsSent.ToList());
        }

        // GET: PaymentSents/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentSent paymentSent = db.PaymentsSent.Find(id);
            if (paymentSent == null)
            {
                return HttpNotFound();
            }
            return View(paymentSent);
        }

        // GET: PaymentSents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymentSents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RequestID,RequestAmount,SendToEmail,SendToPhone,SendToNickName,SendToFirstName,SendToLastName,SendToAddress1,SendTOAddress2,SentTime")] PaymentSent paymentSent)
        {
            if (ModelState.IsValid)
            {
                paymentSent.RequestID = Guid.NewGuid();
                db.PaymentsSent.Add(paymentSent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paymentSent);
        }

        // GET: PaymentSents/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentSent paymentSent = db.PaymentsSent.Find(id);
            if (paymentSent == null)
            {
                return HttpNotFound();
            }
            return View(paymentSent);
        }

        // POST: PaymentSents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RequestID,RequestAmount,SendToEmail,SendToPhone,SendToNickName,SendToFirstName,SendToLastName,SendToAddress1,SendTOAddress2,SentTime")] PaymentSent paymentSent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paymentSent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paymentSent);
        }

        // GET: PaymentSents/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentSent paymentSent = db.PaymentsSent.Find(id);
            if (paymentSent == null)
            {
                return HttpNotFound();
            }
            return View(paymentSent);
        }

        // POST: PaymentSents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            PaymentSent paymentSent = db.PaymentsSent.Find(id);
            db.PaymentsSent.Remove(paymentSent);
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
