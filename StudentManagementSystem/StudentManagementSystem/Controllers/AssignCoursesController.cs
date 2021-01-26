using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    public class AssignCoursesController : ApiController
    {
        private StudentManagementSystemContext db = new StudentManagementSystemContext();

        // GET: api/AssignCourses
        public IQueryable<AssignCourse> GetAssignCourses()
        {
            return db.AssignCourses;
        }

        // GET: api/AssignCourses/5
        [ResponseType(typeof(AssignCourse))]
        public IHttpActionResult GetAssignCourse(int id)
        {
            AssignCourse assignCourse = db.AssignCourses.Find(id);
            if (assignCourse == null)
            {
                return NotFound();
            }

            return Ok(assignCourse);
        }

        // PUT: api/AssignCourses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAssignCourse(int id, AssignCourse assignCourse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != assignCourse.StudentId)
            {
                return BadRequest();
            }

            db.Entry(assignCourse).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignCourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/AssignCourses
        [ResponseType(typeof(AssignCourse))]
        public IHttpActionResult PostAssignCourse(AssignCourse assignCourse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AssignCourses.Add(assignCourse);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = assignCourse.StudentId }, assignCourse);
        }

        // DELETE: api/AssignCourses/5
        [ResponseType(typeof(AssignCourse))]
        public IHttpActionResult DeleteAssignCourse(int id)
        {
            AssignCourse assignCourse = db.AssignCourses.Find(id);
            if (assignCourse == null)
            {
                return NotFound();
            }

            db.AssignCourses.Remove(assignCourse);
            db.SaveChanges();

            return Ok(assignCourse);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AssignCourseExists(int id)
        {
            return db.AssignCourses.Count(e => e.StudentId == id) > 0;
        }
    }
}