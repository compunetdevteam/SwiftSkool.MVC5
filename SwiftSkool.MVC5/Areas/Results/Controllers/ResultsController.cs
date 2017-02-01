using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using SwiftSkool.MVC5.Entities;
using SwiftSkool.MVC5.Models;
using SwiftSkool.MVC5.ViewModels;
using SwiftSkool.MVC5.Abstractions;

namespace SwiftSkool.MVC5.Areas.Results.Controllers
{
    public class ResultsController : Controller
    {
        private IResultCommandManager db;
        private readonly IResultQueryManager qdb;
        private readonly SchoolDb _ctx;

        public ResultsController(IResultCommandManager _db, IResultQueryManager _qdb, SchoolDb ctx)
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

        // POST: Results/Results/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateResultViewModel model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    await db.CreateResult(model);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                throw;
            }

            model.SchoolSession = new SelectList(_ctx.Sessions, "Id", "SessionName", model.SessionId);
            model.Student = new SelectList(_ctx.Students, "Id", "FirstName", model.StudentId);
            model.Subject = new SelectList(_ctx.Subjects, "Id", "Name", model.SubjectId);
            return View(model);
        }

        // GET: Results/Results/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = new UpdateResultViewModel();
            
            result.SchoolSessions = new SelectList(await _ctx.Sessions.ToListAsync(), "Id", "SessionName", result.SchoolSessionId);
            result.Students = new SelectList(await _ctx.Students.ToListAsync(), "Id", "FullName", result.StudentId);
            result.Subjects = new SelectList(await _ctx.Subjects.ToListAsync(), "Id", "Name", result.SubjectId);
            return View(result);
        }

        // POST: Results/Results/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UpdateResultViewModel result)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await db.ChangeResult(result);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction("Index");
            }
            result.SchoolSessions = new SelectList(_ctx.Sessions, "Id", "SessionName", result.SchoolSessionId);
            result.Students = new SelectList(_ctx.Students, "Id", "FirstName", result.StudentId);
            result.Subjects = new SelectList(_ctx.Subjects, "Id", "Name", result.SubjectId);
            return View(result);
        }

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

        // POST: Results/Results/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Result result = await _ctx.Results.FindAsync(id);
            _ctx.Results.Remove(result);
            await _ctx.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
