using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using University;
using University.Models;

namespace University.Controllers
{
    public class OfficeAssignmentsController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: OfficeAssignments
        public ActionResult Index()
        {
            var officeAssignments = db.OfficeAssignments.Include(o => o.Instructor);
			return View(officeAssignments.Where(d => d.Active).ToList());
        }

        // GET: OfficeAssignments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeAssignment officeAssignment = db.OfficeAssignments.Find(id);
            if (officeAssignment == null)
            {
                return HttpNotFound();
            }
            return View(officeAssignment);
        }

        // GET: OfficeAssignments/Create
        public ActionResult Create()
        {
            ViewBag.InstructorID = new SelectList(db.Instructors, "ID", "LastName");
            return View();
        }

        // POST: OfficeAssignments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InstructorID,Location,Active")] OfficeAssignment officeAssignment)
        {
            if (ModelState.IsValid)
            {
                db.OfficeAssignments.Add(officeAssignment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InstructorID = new SelectList(db.Instructors, "ID", "LastName", officeAssignment.InstructorID);
            return View(officeAssignment);
        }

        // GET: OfficeAssignments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeAssignment officeAssignment = db.OfficeAssignments.Find(id);
            if (officeAssignment == null)
            {
                return HttpNotFound();
            }
            ViewBag.InstructorID = new SelectList(db.Instructors, "ID", "LastName", officeAssignment.InstructorID);
            return View(officeAssignment);
        }

        // POST: OfficeAssignments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InstructorID,Location,Active")] OfficeAssignment officeAssignment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(officeAssignment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InstructorID = new SelectList(db.Instructors, "ID", "LastName", officeAssignment.InstructorID);
            return View(officeAssignment);
        }

        // GET: OfficeAssignments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeAssignment officeAssignment = db.OfficeAssignments.Find(id);
            if (officeAssignment == null)
            {
                return HttpNotFound();
            }
            return View(officeAssignment);
        }

        // POST: OfficeAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OfficeAssignment officeAssignment = db.OfficeAssignments.Find(id);
			officeAssignment.Active = false;
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
