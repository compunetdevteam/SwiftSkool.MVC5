using SwiftSkool.MVC5.Abstractions;
using SwiftSkool.MVC5.Entities;
using SwiftSkool.MVC5.Models;
using SwiftSkool.MVC5.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SwiftSkool.MVC5.Areas.Students.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentQueryManager _studQry;
        private readonly IStudentCommaneManager _studCmd;
        private readonly SchoolDb _db;

        public StudentsController(IStudentQueryManager stud, SchoolDb db)
        {
            _stud = stud;
            _db = db;
        }
        // GET: Students/Students
        public ActionResult Index()
        {
            var student = 
            return View();
        }

        // GET: Students/Students/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Students/Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Students/Create
        [HttpPost]
        public ActionResult Create(CreateStudentInputModel model)
        {
           
            try
            {
                if (!ModelState.IsValid)
                {
                    var firsName = model.FirstName;
                    var lastName = model.LastName;
                    var guardian = model.guardian;

                    var student = new Student(guardian,firsName,lastName);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
