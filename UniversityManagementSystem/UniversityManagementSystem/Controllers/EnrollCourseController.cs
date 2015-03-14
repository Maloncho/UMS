using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class EnrollCourseController : Controller
    {
        private UniversityDBContext db = new UniversityDBContext();

        // GET: /EnrollCourse/
        public ActionResult Index()
        {
            var enrollcourses = db.EnrollCourses.Include(e => e.Course);
            return View(enrollcourses.ToList());
        }

        // GET: /EnrollCourse/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnrollCourse enrollcourse = db.EnrollCourses.Find(id);
            if (enrollcourse == null)
            {
                return HttpNotFound();
            }
            return View(enrollcourse);
        }

        // GET: /EnrollCourse/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code");





            ViewBag.RegNo = new SelectList(db.Students, "RegNo", "RegNo");
            
            
            return View();
        }

        // POST: /EnrollCourse/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="RegNo,CourseId,EnrollCourseId,Date")] EnrollCourse enrollcourse)
        {
            if (ModelState.IsValid)
            {
                db.EnrollCourses.Add(enrollcourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code", enrollcourse.CourseId);




            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "RegNo", enrollcourse.RegNo);
            return View(enrollcourse);
        }

        // GET: /EnrollCourse/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnrollCourse enrollcourse = db.EnrollCourses.Find(id);
            if (enrollcourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code", enrollcourse.CourseId);





            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "RegNo", enrollcourse.RegNo);
            return View(enrollcourse);
        }

        // POST: /EnrollCourse/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="RegNo,CourseId,EnrollCourseId,Date")] EnrollCourse enrollcourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrollcourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code", enrollcourse.CourseId);



            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "RegNo", enrollcourse.RegNo);
            
            return View(enrollcourse);
        }

        // GET: /EnrollCourse/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnrollCourse enrollcourse = db.EnrollCourses.Find(id);
            if (enrollcourse == null)
            {
                return HttpNotFound();
            }
            return View(enrollcourse);
        }

        // POST: /EnrollCourse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnrollCourse enrollcourse = db.EnrollCourses.Find(id);
            db.EnrollCourses.Remove(enrollcourse);
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
