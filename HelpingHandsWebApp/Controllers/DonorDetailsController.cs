using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HelpingHandsWebApp.Models;

namespace HelpingHandsWebApp.Controllers
{
    public class DonorDetailsController : Controller
    {
        private HelpingHandsWebApp_Context db = new HelpingHandsWebApp_Context();

        // GET: DonorDetails
        public ActionResult Index()
        {
            return View(db.DonorDetails.ToList());
        }

        // GET: DonorDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorDetails donorDetails = db.DonorDetails.Find(id);
            if (donorDetails == null)
            {
                return HttpNotFound();
            }
            return View(donorDetails);
        }

        // GET: DonorDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DonorDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "donorID,Name,Surname,email")] DonorDetails donorDetails)
        {
            if (ModelState.IsValid)
            {
                db.DonorDetails.Add(donorDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donorDetails);
        }

        // GET: DonorDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorDetails donorDetails = db.DonorDetails.Find(id);
            if (donorDetails == null)
            {
                return HttpNotFound();
            }
            return View(donorDetails);
        }

        // POST: DonorDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "donorID,Name,Surname,email")] DonorDetails donorDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donorDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donorDetails);
        }

        // GET: DonorDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorDetails donorDetails = db.DonorDetails.Find(id);
            if (donorDetails == null)
            {
                return HttpNotFound();
            }
            return View(donorDetails);
        }

        // POST: DonorDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonorDetails donorDetails = db.DonorDetails.Find(id);
            db.DonorDetails.Remove(donorDetails);
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
