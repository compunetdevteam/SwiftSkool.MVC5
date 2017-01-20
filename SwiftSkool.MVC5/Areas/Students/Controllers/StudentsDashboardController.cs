using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SwiftSkool.Entities;
using SwiftSkool.MVC5.Models;

namespace SwiftSkool.MVC5.Areas.Students.Controllers
{
    public class StudentsDashboardController : Controller
    {
        private SchoolDb db = new SchoolDb();

        // GET: Students/StudentsDashboard
        public async Task<ActionResult> Index()
        {
            var students = db.Students.Include(s => s.Attendance).Include(s => s.Class).Include(s => s.Club).Include(s => s.Guardian).Include(s => s.Hostel).Include(s => s.MedicalHistory).Include(s => s.StateOfOrigin);
            return View(await students.ToListAsync());
        }

        // GET: Students/StudentsDashboard/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await db.Students.FindAsync(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/StudentsDashboard/Create
        public ActionResult Create()
        {
            ViewBag.AttendanceId = new SelectList(db.Attendance, "Id", "StatusDescription");
            ViewBag.ClassId = new SelectList(db.Classes, "Id", "Level");
            ViewBag.ClubId = new SelectList(db.Clubs, "Id", "Clubname");
            ViewBag.GuardianId = new SelectList(db.Guardians, "Id", "FirstName");
            ViewBag.HostelId = new SelectList(db.Hostels, "Id", "Name");
            ViewBag.Id = new SelectList(db.MedicalHistories, "Id", "CreatedBy");
            ViewBag.StateId = new SelectList(db.States, "Id", "Name");
            return View();
        }

        // POST: Students/StudentsDashboard/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,LastName,OtherName,Age,DateOfBirth,Email,AdmissionDate,Gender,StudentPassport,AdmissionNumber,Country,Active,AttendanceId,ClassId,ClubId,GuardianId,HostelId,MedicalHistoryId,StateId,Address,CreatedBy,CreatedAt,ModifiedBy,UpdatedAt,Version")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AttendanceId = new SelectList(db.Attendance, "Id", "StatusDescription", student.AttendanceId);
            ViewBag.ClassId = new SelectList(db.Classes, "Id", "Level", student.ClassId);
            ViewBag.ClubId = new SelectList(db.Clubs, "Id", "Clubname", student.ClubId);
            ViewBag.GuardianId = new SelectList(db.Guardians, "Id", "FirstName", student.GuardianId);
            ViewBag.HostelId = new SelectList(db.Hostels, "Id", "Name", student.HostelId);
            ViewBag.Id = new SelectList(db.MedicalHistories, "Id", "CreatedBy", student.Id);
            ViewBag.StateId = new SelectList(db.States, "Id", "Name", student.StateId);
            return View(student);
        }

        // GET: Students/StudentsDashboard/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await db.Students.FindAsync(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.AttendanceId = new SelectList(db.Attendance, "Id", "StatusDescription", student.AttendanceId);
            ViewBag.ClassId = new SelectList(db.Classes, "Id", "Level", student.ClassId);
            ViewBag.ClubId = new SelectList(db.Clubs, "Id", "Clubname", student.ClubId);
            ViewBag.GuardianId = new SelectList(db.Guardians, "Id", "FirstName", student.GuardianId);
            ViewBag.HostelId = new SelectList(db.Hostels, "Id", "Name", student.HostelId);
            ViewBag.Id = new SelectList(db.MedicalHistories, "Id", "CreatedBy", student.Id);
            ViewBag.StateId = new SelectList(db.States, "Id", "Name", student.StateId);
            return View(student);
        }

        // POST: Students/StudentsDashboard/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,LastName,OtherName,Age,DateOfBirth,Email,AdmissionDate,Gender,StudentPassport,AdmissionNumber,Country,Active,AttendanceId,ClassId,ClubId,GuardianId,HostelId,MedicalHistoryId,StateId,Address,CreatedBy,CreatedAt,ModifiedBy,UpdatedAt,Version")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AttendanceId = new SelectList(db.Attendance, "Id", "StatusDescription", student.AttendanceId);
            ViewBag.ClassId = new SelectList(db.Classes, "Id", "Level", student.ClassId);
            ViewBag.ClubId = new SelectList(db.Clubs, "Id", "Clubname", student.ClubId);
            ViewBag.GuardianId = new SelectList(db.Guardians, "Id", "FirstName", student.GuardianId);
            ViewBag.HostelId = new SelectList(db.Hostels, "Id", "Name", student.HostelId);
            ViewBag.Id = new SelectList(db.MedicalHistories, "Id", "CreatedBy", student.Id);
            ViewBag.StateId = new SelectList(db.States, "Id", "Name", student.StateId);
            return View(student);
        }

        // GET: Students/StudentsDashboard/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await db.Students.FindAsync(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/StudentsDashboard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Student student = await db.Students.FindAsync(id);
            db.Students.Remove(student);
            await db.SaveChangesAsync();
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
