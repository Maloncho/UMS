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
    public class CourseAssignController : Controller
    {
        private UniversityDBContext db = new UniversityDBContext();

        // GET: /CourseAssign/

        public ActionResult Index()
        {
            var courseassigns = db.CourseAssigns.Include(c => c.Course).Include(c => c.Department).Include(c => c.Teacher);
            return View(courseassigns.ToList());
        }

        // GET: /CourseAssign/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseAssign courseassign = db.CourseAssigns.Find(id);
            if (courseassign == null)
            {
                return HttpNotFound();
            }
            return View(courseassign);
        }

        // GET: /CourseAssign/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code");
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Code");
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "Name");
            return View();
        }

        // POST: /CourseAssign/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CourseAssignId,DepartmentId,TeacherId,AssignTaken,RemainingTaken,CourseId")] CourseAssign courseassign)
        {
            if (ModelState.IsValid)
            {
                db.CourseAssigns.Add(courseassign);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code", courseassign.CourseId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Code", courseassign.DepartmentId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "Name", courseassign.TeacherId);
            return View(courseassign);
        }

        // GET: /CourseAssign/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseAssign courseassign = db.CourseAssigns.Find(id);
            if (courseassign == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code", courseassign.CourseId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Code", courseassign.DepartmentId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "Name", courseassign.TeacherId);
            return View(courseassign);
        }

        // POST: /CourseAssign/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CourseAssignId,DepartmentId,TeacherId,AssignTaken,RemainingTaken,CourseId")] CourseAssign courseassign)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseassign).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code", courseassign.CourseId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Code", courseassign.DepartmentId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "Name", courseassign.TeacherId);
            return View(courseassign);
        }

        // GET: /CourseAssign/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseAssign courseassign = db.CourseAssigns.Find(id);
            if (courseassign == null)
            {
                return HttpNotFound();
            }
            return View(courseassign);
        }

        // POST: /CourseAssign/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseAssign courseassign = db.CourseAssigns.Find(id);
            db.CourseAssigns.Remove(courseassign);
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

        public JsonResult GetInfo(int teacherID)
        {
            using (var context = new UniversityDBContext())
            {
                context.Configuration.ProxyCreationEnabled = false;
              
                var courseInfo2 = context.CourseAssigns.Where(x => x.TeacherId == teacherID).ToList();
                var courseInfo = context.CourseAssigns.Where(x => x.TeacherId == teacherID).FirstOrDefault();
                if (courseInfo2.Count > 0)
                {
                var a = courseInfo2.Min(x => x.RemainingTaken);
                courseInfo = context.CourseAssigns.Where(x => x.TeacherId == teacherID && x.RemainingTaken == a).FirstOrDefault();
                }
             
               
              if (courseInfo == null)
               {
                   var tmp = context.Teachers.Where(x => x.TeacherId == teacherID).FirstOrDefault();
                   courseInfo = new CourseAssign();
                   courseInfo.AssignTaken = 0;
                   courseInfo.RemainingTaken = tmp.Credit;
               }

                return Json(courseInfo, JsonRequestBehavior.AllowGet);
            }
        }



    }
}
