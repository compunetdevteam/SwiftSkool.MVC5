using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using SwiftSkool.MVC5.Entities;
using SwiftSkool.MVC5.Models;
using SwiftSkool.MVC5.Abstractions;
using System.Linq;

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
        public async Task<ActionResult> Index(string filter, string sort)
        {
            //check to see if the sorting is not empty and apply sorting to result
            var results = await _rqm.GetAllResultsAsync();

            if (!string.IsNullOrWhiteSpace(sort))
            {
                if (sort == "asc")
                {
                    results = results.OrderBy(x => x.Student.FirstName).ToList();
                }
                else if (sort == "desc")
                {
                    results = results.OrderByDescending(x => x.Student.FirstName).ToList();
                }
            }

            //check to see if the sorting is not empty and apply sorting to result

            if (!string.IsNullOrWhiteSpace(filter))
            {
                results = results.Where(x => x.Student.FirstName.Contains(filter) || x.Student.LastName.Contains(filter)
                                  || x.CA.Name.Contains(filter) || x.Subject.Name.Contains(filter)).ToList();
            }
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
