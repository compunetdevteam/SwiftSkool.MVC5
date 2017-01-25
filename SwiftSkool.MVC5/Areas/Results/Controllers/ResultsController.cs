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
using SwiftSkool.MVC5.BusinessLogic;
using SwiftSkool.BusinessLogic;
using SwiftSkool.MVC5.ViewModels;

namespace SwiftSkool.MVC5.Areas.Results.Controllers
{
    public class ResultsController : Controller
    {
        private ResultCommandManager db;
        private readonly ResultQueryManager qdb;
        private readonly SchoolDb _ctx;

        public ResultsController(ResultCommandManager _db, ResultQueryManager _qdb, SchoolDb ctx)
        {
            db = _db;
            qdb = _qdb;
            _ctx = ctx;
        }

        // GET: Results/Results
        public async Task<ActionResult> Index()
        {
            return View(await qdb.GetAllResultsAsync());
        }

        // GET: Results/Results/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = await qdb.GetAllResultsByIdAsync(id.Value);
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        // GET: Results/Results/Create
        public ActionResult Create()
        {
            var rim = new CreateResultViewModel();

            rim.SchoolSession = new SelectList(_ctx.Sessions, "Id", "SessionName");
            rim.Student = new SelectList(_ctx.Students, "Id", "FullName");
            rim.Subject = new SelectList(_ctx.Subjects, "SubjectCode", "Name");
            return View(rim);
        }

        //// POST: Results/Results/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "Id,SchoolSessionId,StudentId,SubjectId,ScoreGradeId,TermTotal,ClassAverage,Position,Status,CreatedBy,CreatedAt,ModifiedBy,UpdatedAt,Version")] Result result)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Results.Add(result);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.SchoolSessionId = new SelectList(db.Sessions, "Id", "SessionName", result.SchoolSessionId);
        //    ViewBag.ScoreGradeId = new SelectList(db.ScoreGrades, "Id", "Level", result.ScoreGradeId);
        //    ViewBag.StudentId = new SelectList(db.Students, "Id", "FirstName", result.StudentId);
        //    ViewBag.Id = new SelectList(db.Subjects, "Id", "Name", result.Id);
        //    return View(result);
        //}

        //// GET: Results/Results/Edit/5
        //public async Task<ActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Result result = await db.Results.FindAsync(id);
        //    if (result == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.SchoolSessionId = new SelectList(db.Sessions, "Id", "SessionName", result.SchoolSessionId);
        //    ViewBag.ScoreGradeId = new SelectList(db.ScoreGrades, "Id", "Level", result.ScoreGradeId);
        //    ViewBag.StudentId = new SelectList(db.Students, "Id", "FirstName", result.StudentId);
        //    ViewBag.Id = new SelectList(db.Subjects, "Id", "Name", result.Id);
        //    return View(result);
        //}

        //// POST: Results/Results/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "Id,SchoolSessionId,StudentId,SubjectId,ScoreGradeId,TermTotal,ClassAverage,Position,Status,CreatedBy,CreatedAt,ModifiedBy,UpdatedAt,Version")] Result result)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(result).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.SchoolSessionId = new SelectList(db.Sessions, "Id", "SessionName", result.SchoolSessionId);
        //    ViewBag.ScoreGradeId = new SelectList(db.ScoreGrades, "Id", "Level", result.ScoreGradeId);
        //    ViewBag.StudentId = new SelectList(db.Students, "Id", "FirstName", result.StudentId);
        //    ViewBag.Id = new SelectList(db.Subjects, "Id", "Name", result.Id);
        //    return View(result);
        //}

        //// GET: Results/Results/Delete/5
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Result result = await db.Results.FindAsync(id);
        //    if (result == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(result);
        //}

        //// POST: Results/Results/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    Result result = await db.Results.FindAsync(id);
        //    db.Results.Remove(result);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}
    }
}
