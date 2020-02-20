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
    public class HampersController : Controller
    {
        private HelpingHandsWebApp_Context db = new HelpingHandsWebApp_Context();

        // GET: Hampers
        public ActionResult Index()
        {
            var hampers = db.Hampers.Include(h => h.donor);
            return View(hampers.ToList());
        }

        // GET: Hampers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hamper hamper = db.Hampers.Find(id);
            if (hamper == null)
            {
                return HttpNotFound();
            }
            return View(hamper);
        }

        // GET: Hampers/Create
        public ActionResult Create()
        {
            ViewBag.donorID = new SelectList(db.DonorDetails, "donorID", "Name");
            return View();
        }

        // POST: Hampers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "hamperID,donorID,hamperDetails")] Hamper hamper)
        {
            if (ModelState.IsValid)
            {
                db.Hampers.Add(hamper);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.donorID = new SelectList(db.DonorDetails, "donorID", "Name", hamper.donorID);
            return View(hamper);
        }

        // GET: Hampers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hamper hamper = db.Hampers.Find(id);
            if (hamper == null)
            {
                return HttpNotFound();
            }
            ViewBag.donorID = new SelectList(db.DonorDetails, "donorID", "Name", hamper.donorID);
            return View(hamper);
        }

        // POST: Hampers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "hamperID,donorID,hamperDetails")] Hamper hamper)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hamper).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.donorID = new SelectList(db.DonorDetails, "donorID", "Name", hamper.donorID);
            return View(hamper);
        }

        // GET: Hampers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hamper hamper = db.Hampers.Find(id);
            if (hamper == null)
            {
                return HttpNotFound();
            }
            return View(hamper);
        }

        // POST: Hampers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hamper hamper = db.Hampers.Find(id);
            db.Hampers.Remove(hamper);
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
