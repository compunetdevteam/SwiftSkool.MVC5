using System.Web.Mvc;
using SwiftSkool.MVC5.Abstractions;
using System.Threading.Tasks;
using System.Net;
using SwiftSkool.MVC5.ViewModels;

namespace SwiftSkool.MVC5.Areas.Students.Controllers
{
    public class ClassesController : Controller
    {
        private IClassCommandManager db;
        private readonly IClassQueryManager qdb;

        public ClassesController(IClassCommandManager _db, IClassQueryManager _qdb)
        {
            db = _db;
            qdb = _qdb;
        }

        // GET: Students/Classes
        public async Task<ActionResult> Index()
        {
            return View(await qdb.GetClassesAsync());
        }


        // GET: Students/Classes/Details/5
        public async Task<ActionResult> Details(int? id)
        {

            var aclass = await qdb.GetClassesAsync();
            return View(aclass);
        }

        // GET: Students/Classes/Create
        public ActionResult Create()
        {
            var newclass = new CreateClassVM();
            return View(newclass);
        }


        //// POST: Students/Classes/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Level,ClassName,Section,TeacherId,CreatedBy,CreatedAt,ModifiedBy,UpdatedAt,Version")] Class @class)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(@class).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(@class);
        //}

        //// GET: Students/Classes/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Class @class = db.Classes.Find(id);
        //    if (@class == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(@class);
        //}

        //// POST: Students/Classes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Class @class = db.Classes.Find(id);
        //    db.Classes.Remove(@class);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
