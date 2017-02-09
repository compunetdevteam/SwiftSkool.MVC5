﻿using System;
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
using SwiftSkool.MVC5.ViewModels;

namespace SwiftSkool.MVC5.Areas.Students.Controllers
{
    public class GuardiansController : Controller
    {
        private SchoolDb db = new SchoolDb();

        // GET: Students/Guardians
        public async Task<ActionResult> Index()
        {
            return View(await db.Guardians.ToListAsync());
        }

        // GET: Students/Guardians/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guardian guardian = await db.Guardians.FindAsync(id);
            if (guardian == null)
            {
                return HttpNotFound();
            }
            return View(guardian);
        }

        // GET: Students/Guardians/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Guardians/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(GuardianViewModel guardian)
        {
            if (ModelState.IsValid)
            {
                var street = guardian.StreetName;
                var area = guardian.NameOfArea;
                var city = guardian.city;
                var add = new Address(street,area,city);
               // db.Guardians.Add(guardian);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(guardian);
        }

        // GET: Students/Guardians/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guardian guardian = await db.Guardians.FindAsync(id);
            if (guardian == null)
            {
                return HttpNotFound();
            }
            return View(guardian);
        }

        // POST: Students/Guardians/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,LastName,OtherName,Occupation,AddressId,Address,Relationship,CreatedBy,CreatedAt,ModifiedBy,UpdatedAt,Version")] Guardian guardian)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guardian).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(guardian);
        }

        // GET: Students/Guardians/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guardian guardian = await db.Guardians.FindAsync(id);
            if (guardian == null)
            {
                return HttpNotFound();
            }
            return View(guardian);
        }

        // POST: Students/Guardians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Guardian guardian = await db.Guardians.FindAsync(id);
            db.Guardians.Remove(guardian);
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