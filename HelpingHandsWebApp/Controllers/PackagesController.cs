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
    public class PackagesController : Controller
    {
        private HelpingHandsWebApp_Context db = new HelpingHandsWebApp_Context();

        // GET: Packages
        public ActionResult Index()
        {
            var hampers = db.Hampers.Include(p => p.donor);
            return View(hampers.ToList());
        }

        // GET: Packages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Packages packages = db.Hampers.Find(id);
            if (packages == null)
            {
                return HttpNotFound();
            }
            return View(packages);
        }

        // GET: Packages/Create
        public ActionResult Create()
        {
            ViewBag.donorID = new SelectList(db.DonorDetails, "donorID", "Name");
            return View();
        }

        // POST: Packages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "packageID,donorID,packageDetails")] Packages packages)
        {
            if (ModelState.IsValid)
            {
                db.Hampers.Add(packages);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.donorID = new SelectList(db.DonorDetails, "donorID", "Name", packages.donorID);
            return View(packages);
        }

        // GET: Packages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Packages packages = db.Hampers.Find(id);
            if (packages == null)
            {
                return HttpNotFound();
            }
            ViewBag.donorID = new SelectList(db.DonorDetails, "donorID", "Name", packages.donorID);
            return View(packages);
        }

        // POST: Packages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "packageID,donorID,packageDetails")] Packages packages)
        {
            if (ModelState.IsValid)
            {
                db.Entry(packages).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.donorID = new SelectList(db.DonorDetails, "donorID", "Name", packages.donorID);
            return View(packages);
        }

        // GET: Packages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Packages packages = db.Hampers.Find(id);
            if (packages == null)
            {
                return HttpNotFound();
            }
            return View(packages);
        }

        // POST: Packages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Packages packages = db.Hampers.Find(id);
            db.Hampers.Remove(packages);
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
