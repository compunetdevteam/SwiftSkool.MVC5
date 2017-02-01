using SwiftSkool.MVC5.Abstractions;
using SwiftSkool.MVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SwiftSkool.MVC5.Areas.Results.Controllers
{
    public class ReportsController : Controller
    {
        public readonly SchoolDb _db;
        public readonly IResultQueryManager _rqm;
        public readonly IStudentQueryManager _sqm;
        public readonly IClassQueryManager _cqm;

        public ReportsController(SchoolDb db, IResultQueryManager rqm, IStudentQueryManager sqm,
            IClassQueryManager cqm)
        {
            _db = db;
            _rqm = rqm;
            _sqm = sqm;
            _cqm = cqm;
        }
        // GET: Results/Reports
        public ActionResult Index()
        {

            return View();
        }

        // GET: Results/Reports/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Results/Reports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Results/Reports/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Results/Reports/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Results/Reports/Edit/5
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

        // GET: Results/Reports/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Results/Reports/Delete/5
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
