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
    public class OrgDetailsController : Controller
    {
        private HelpingHandsWebApp_Context db = new HelpingHandsWebApp_Context();

        // GET: OrgDetails
        public ActionResult Index()
        {
            return View(db.OrgDetails.ToList());
        }

        // GET: OrgDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrgDetails orgDetails = db.OrgDetails.Find(id);
            if (orgDetails == null)
            {
                return HttpNotFound();
            }
            return View(orgDetails);
        }

        // GET: OrgDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrgDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "orgID,orgName,orgImage,email,Address")] OrgDetails orgDetails)
        {
            if (ModelState.IsValid)
            {
                db.OrgDetails.Add(orgDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orgDetails);
        }

        // GET: OrgDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrgDetails orgDetails = db.OrgDetails.Find(id);
            if (orgDetails == null)
            {
                return HttpNotFound();
            }
            return View(orgDetails);
        }

        // POST: OrgDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "orgID,orgName,orgImage,email,Address")] OrgDetails orgDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orgDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orgDetails);
        }

        // GET: OrgDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrgDetails orgDetails = db.OrgDetails.Find(id);
            if (orgDetails == null)
            {
                return HttpNotFound();
            }
            return View(orgDetails);
        }

        // POST: OrgDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrgDetails orgDetails = db.OrgDetails.Find(id);
            db.OrgDetails.Remove(orgDetails);
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
