using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using SwiftSkool.Entities;
using SwiftSkool.MVC5.Models;
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
    }
}
