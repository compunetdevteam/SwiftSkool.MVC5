using System.Data.Entity;
using System.Threading.Tasks;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SwiftSkool.Entities;
using SwiftSkool.MVC5.Models;
using AutoMapper.QueryableExtensions;
using SwiftSkool.MVC5.ViewModels;
using SwiftSkool.Abstractions;

namespace SwiftSkool.MVC5.Areas.Results.Controllers
{
    public class ResultsDashboardController : Controller
    {
        private SchoolDb db;
        private readonly IResultQueryManager _rqm;
        private readonly ISubjectQueryManager _sqm;

        public ResultsDashboardController(SchoolDb _db, IResultQueryManager rqm,
            ISubjectQueryManager sqm)
        {
            db = _db;
            _rqm = rqm;
            _sqm = sqm;
        }

        // GET: Results/ResultsDashboard
        public async Task<ActionResult> Index()
        {
            var results = await _rqm.GetAllResultsAsync();
            return View(results);
        }

        // GET: Results/ResultsDashboard/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Result result = await db.Results.FindAsync(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        // GET: Results/ResultsDashboard/Create
        public async Task<ActionResult> Create()
        {
            var rvm = new ResultViewModel();
            var result = await _rqm.GetAllResultsAsync();
            var subjects = await _sqm.GetSubjects();
            rvm.Subject = result.Select(x => x.Subject).FirstOrDefault();
            
            return View(rvm);
        }

        // POST: Results/ResultsDashboard/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,SchoolSessionId,StudentId,SubjectId,ScoreGradeId,TermTotal,ClassAverage,Position,Status,CreatedBy,CreatedAt,ModifiedBy,UpdatedAt,Version")] Result result)
        {
            if (ModelState.IsValid)
            {
                db.Results.Add(result);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SchoolSessionId = new SelectList(db.Sessions, "Id", "SessionName", result.SchoolSessionId);
            ViewBag.ScoreGradeId = new SelectList(db.ScoreGrades, "Id", "Level", result.ScoreGradeId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "FirstName", result.StudentId);
            ViewBag.Id = new SelectList(db.Subjects, "Id", "Name", result.Id);
            return View(result);
        }

        // GET: Results/ResultsDashboard/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Result result = await db.Results.FindAsync(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            ViewBag.SchoolSessionId = new SelectList(db.Sessions, "Id", "SessionName", result.SchoolSessionId);
            ViewBag.ScoreGradeId = new SelectList(db.ScoreGrades, "Id", "Level", result.ScoreGradeId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "FirstName", result.StudentId);
            ViewBag.Id = new SelectList(db.Subjects, "Id", "Name", result.Id);
            return View(result);
        }

        // POST: Results/ResultsDashboard/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,SchoolSessionId,StudentId,SubjectId,ScoreGradeId,TermTotal,ClassAverage,Position,Status,CreatedBy,CreatedAt,ModifiedBy,UpdatedAt,Version")] Result result)
        {
            if (ModelState.IsValid)
            {
                db.Entry(result).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SchoolSessionId = new SelectList(db.Sessions, "Id", "SessionName", result.SchoolSessionId);
            ViewBag.ScoreGradeId = new SelectList(db.ScoreGrades, "Id", "Level", result.ScoreGradeId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "FirstName", result.StudentId);
            ViewBag.Id = new SelectList(db.Subjects, "Id", "Name", result.Id);
            return View(result);
        }

        // GET: Results/ResultsDashboard/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Result result = await db.Results.FindAsync(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        // POST: Results/ResultsDashboard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Result result = await db.Results.FindAsync(id);
            db.Results.Remove(result);
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
