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
using SwiftSkool.MVC5.Abstractions;

namespace SwiftSkool.MVC5.Areas.Results.Controllers
{
    public class ContinuousAssessmentsController : Controller
    {
        private readonly ICAQueryManager _cqm;
        private SchoolDb db;

        public ContinuousAssessmentsController(ICAQueryManager cqm, SchoolDb _db)
        {
            db = _db;
            _cqm = cqm;
        }

        // GET: Results/ContinuousAssessments
        public async Task<ActionResult> Index()
        {
            return View(await _cqm.ReturnCAList());
        }

        // GET: Results/ContinuousAssessments/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var contaccess = await _cqm.ReturnCADetails(id.Value);
            if (contaccess == null)
            {
                return HttpNotFound();
            }
            return View(contaccess);
        }

        // GET: Results/ContinuousAssessments/Create
        public ActionResult Create()
        {
            ViewBag.ResultId = new SelectList(db.Results, "Id", "Position");
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name");
            return View();
        }

        // POST: Results/ContinuousAssessments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Score,Name,SubjectId,ResultId,CreatedBy,CreatedAt,ModifiedBy,UpdatedAt,Version")] ContinuousAssessment continuousAssessment)
        {
            if (ModelState.IsValid)
            {
                db.ContinuousAssessment.Add(continuousAssessment);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ResultId = new SelectList(db.Results, "Id", "Position", continuousAssessment.ResultId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", continuousAssessment.SubjectId);
            return View(continuousAssessment);
        }

        // GET: Results/ContinuousAssessments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContinuousAssessment continuousAssessment = await db.ContinuousAssessment.FindAsync(id);
            if (continuousAssessment == null)
            {
                return HttpNotFound();
            }
            ViewBag.ResultId = new SelectList(db.Results, "Id", "Position", continuousAssessment.ResultId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", continuousAssessment.SubjectId);
            return View(continuousAssessment);
        }

        // POST: Results/ContinuousAssessments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Score,Name,SubjectId,ResultId,CreatedBy,CreatedAt,ModifiedBy,UpdatedAt,Version")] ContinuousAssessment continuousAssessment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(continuousAssessment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ResultId = new SelectList(db.Results, "Id", "Position", continuousAssessment.ResultId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", continuousAssessment.SubjectId);
            return View(continuousAssessment);
        }

        // GET: Results/ContinuousAssessments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContinuousAssessment continuousAssessment = await db.ContinuousAssessment.FindAsync(id);
            if (continuousAssessment == null)
            {
                return HttpNotFound();
            }
            return View(continuousAssessment);
        }

        // POST: Results/ContinuousAssessments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ContinuousAssessment continuousAssessment = await db.ContinuousAssessment.FindAsync(id);
            db.ContinuousAssessment.Remove(continuousAssessment);
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
