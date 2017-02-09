using SwiftSkool.MVC5.Abstractions;
using SwiftSkool.MVC5.BusinessLogic;
using SwiftSkool.MVC5.Entities;
using SwiftSkool.MVC5.Models;
using SwiftSkool.MVC5.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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

            student.guardian = new SelectList(_db.Guardians,"Id","FullName");
            return View(student);
        }

        // POST: Students/Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateStudentInputModel model)
        {
           
            try
            {
                if (!ModelState.IsValid)
                {
                    await _studCmd.RegisterStudent(model);
                }

                return RedirectToAction("Index");
            }
            catch(Exception)
            {
               
            }
            model.guardian = new SelectList(_db.Guardians,"Id","FullName",model.GuardianId);
            return View();
        }

        // GET: Students/Students/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Students/Students/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
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
