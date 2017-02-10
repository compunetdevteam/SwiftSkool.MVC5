using System;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using SwiftSkool.MVC5.ViewModels;
using SwiftSkool.MVC5.Abstractions;

namespace SwiftSkool.MVC5.Areas.Students.Controllers
{
    public class GuardiansController : Controller
    {
        private readonly IGuardianQueryManager _gqm;
        private IGuardianCommandManager _gcm;

        public GuardiansController(IGuardianQueryManager gqm, IGuardianCommandManager gcm)
        {
            _gqm = gqm;
            _gcm = gcm;
        }

        // GET: Students/Guardians
        public async Task<ActionResult> Index()
        {

            return View(await _gqm.ShowAllGuardians());
        }

        // GET: Students/Guardians/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var guardian = await _gqm.ShowGuardianDetails(id);
            if (guardian == null)
            {
                return HttpNotFound();
            }
            return View(guardian);
        }

        // GET: Students/Guardians/Create
        public ActionResult Create()
        {
            var guardian = new GuardianViewModel();

            return View(guardian);
        }

        // POST: Students/Guardians/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(GuardianViewModel guardian)
        {
            if (!ModelState.IsValid)
                return View(guardian);

            await _gcm.RegisterGuardian(guardian);
            return RedirectToAction("Index");

            
        }

        // GET: Students/Guardians/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var uguardian = await _gqm.GetGuardianToUpdate(id);

            return View(uguardian);
        }

        // POST: Students/Guardians/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UpdateGuardianVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _gcm.UpdateGuardianDetails(model);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    //show friendly error page.
                }
            }
            return View(model);
        }
    }
}
