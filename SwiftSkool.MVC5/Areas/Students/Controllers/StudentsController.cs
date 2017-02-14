using AutoMapper;
using SwiftSkool.MVC5.Abstractions;
using SwiftSkool.MVC5.BusinessLogic;
using SwiftSkool.MVC5.Entities;
using SwiftSkool.MVC5.Models;
using SwiftSkool.MVC5.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SwiftSkool.MVC5.Areas.Students.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentQueryManager _studQry;
        private readonly IStudentCommandManager _studCmd;
        private readonly SchoolDb _db;

        public StudentsController(IStudentQueryManager stud, SchoolDb db,IStudentCommandManager studCmd)
        {
            _studQry = stud;
            _studCmd = studCmd;
            _db = db;
        }
        // GET: Students/Students
        public async Task<ActionResult> Index()
        {
            var students = await _studQry.GetStudentsAsync();
            return View(students);
        }

        // GET: Students/Students/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Students/Students/Create
        public ActionResult Create()
        {
            var student = new CreateStudentInputModel();

            student.Guardian = new SelectList(_db.Guardians,"Id","FullName");
            return View(student);
        }

        // POST: Students/Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateStudentInputModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Guardian = new SelectList(_db.Guardians, "Id", "FullName", model.GuardianId);
                return View(model);
            }
            await _studCmd.RegisterStudent(model);
            return RedirectToAction("Index");
        }

        // GET: Students/Students/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var studentvm = await _studQry.GetStudentToUpdate(id);
            studentvm.Class = new SelectList(await _db.Classes.ToListAsync(), "Id", "ClassName");
            studentvm.Club = new SelectList(await _db.Clubs.ToListAsync(), "Id", "ClubName");
            studentvm.Guardian = new SelectList(await _db.Guardians.ToListAsync(), "Id", "FullName");
            studentvm.Hostel = new SelectList(await _db.Hostels.ToListAsync(), "Id", "Name");
            studentvm.StateOfOrigin = new SelectList(await _db.States.ToListAsync(), "Id", "Name");

            return View(studentvm);
        }

        // POST: Students/Students/Edit/5
        [HttpPost]
        public ActionResult Edit(UpdateStudentVM model)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Students/Students/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Students/Students/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
