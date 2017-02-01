using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SwiftSkool.MVC5.Entities;
using SwiftSkool.MVC5.Models;
using SwiftSkool.MVC5.Abstractions;
using SwiftSkool.MVC5.ViewModels;

namespace SwiftSkool.MVC5.Areas.Results.Controllers
{
    public class ContinuousAssessmentsController : Controller
    {
        private readonly ICAQueryManager _cqm;
        private ICACommandManager _ccm;
        private SchoolDb db;

        public ContinuousAssessmentsController(ICAQueryManager cqm, SchoolDb _db, ICACommandManager ccm)
        {
            db = _db;
            _cqm = cqm;
            _ccm = ccm;
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
            var canew = new CreateCAViewModel();
            canew.Results = new SelectList(db.Results, "Id", "Id");
            canew.Subject = new SelectList(db.Subjects, "Id", "Name");
            return View(canew);
        }

        // POST: Results/ContinuousAssessments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateCAViewModel cont)
        {

            try
            {
                var result = await db.Results.FindAsync(cont.ResultId);
                var subject = await db.Subjects.FindAsync(cont.SubjectId);

                var continuousAssessment = new ContinuousAssessment(cont.Score.Value, cont.CAName, subject, result);
                if (ModelState.IsValid)
                {
                    db.ContinuousAssessment.Add(continuousAssessment);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                throw;
            }

            cont.Results = new SelectList(db.Results, "Id", "Position", cont.ResultId);
            cont.Subject = new SelectList(db.Subjects, "Id", "Name", cont.SubjectId);
            return View(cont);
        }

        // GET: Results/ContinuousAssessments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {

            var continuousAssessment = new CAUpdateViewModel();
            
            continuousAssessment.Subject = new SelectList(await db.Subjects.ToListAsync(),
                "Id", "Name", continuousAssessment.SubjectId);
            return View(continuousAssessment);
        }

        // POST: Results/ContinuousAssessments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CAUpdateViewModel cont)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _ccm.CorrectCA(cont);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                throw;
            }
            cont.Subject = new SelectList(await db.Subjects.ToListAsync(), "Id", "Name", cont.SubjectId);
            return View(cont);
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
            try
            {
                await _ccm.DeleteCA(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
