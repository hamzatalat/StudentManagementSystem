using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    public class AssignCoursesController : Controller
    {
        private StudentManagementSystemContext db = new StudentManagementSystemContext();

        // GET: AssignCourses
        public ActionResult Index()
        {
            return View(db.AssignCourses.ToList());
        }

        // GET: AssignCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignCourse assignCourse = db.AssignCourses.Find(id);
            if (assignCourse == null)
            {
                return HttpNotFound();
            }
            return View(assignCourse);
        }

        // GET: AssignCourses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AssignCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,CourseId")] AssignCourse assignCourse)
        {
            if (ModelState.IsValid)
            {
                db.AssignCourses.Add(assignCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(assignCourse);
        }

        // GET: AssignCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignCourse assignCourse = db.AssignCourses.Find(id);
            if (assignCourse == null)
            {
                return HttpNotFound();
            }
            return View(assignCourse);
        }

        // POST: AssignCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,CourseId")] AssignCourse assignCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assignCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(assignCourse);
        }

        // GET: AssignCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignCourse assignCourse = db.AssignCourses.Find(id);
            if (assignCourse == null)
            {
                return HttpNotFound();
            }
            return View(assignCourse);
        }

        // POST: AssignCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssignCourse assignCourse = db.AssignCourses.Find(id);
            db.AssignCourses.Remove(assignCourse);
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
