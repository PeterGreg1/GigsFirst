using System.Linq;
using System.Web.Mvc;
using GigsFirst.Models.ViewModels;
using GigsFirstBLL;
using GigsFirstEntities;
using Kendo.Mvc.UI;
using PagedList;

namespace GigsFirst.Controllers
{
    public class VenueAdminController : Controller
    {
        IVenueRepos _repos = new VenueRepos();
        VenueAdminViewModel _viewmodel = new VenueAdminViewModel();
        private int _pageSize = 20;

        //
        // GET: /VenueAdmin/

        public ActionResult Index([DataSourceRequest]DataSourceRequest request)
        {
            int total = _repos.GetAll().Count();
            request.PageSize = total;
            ViewData["total"] = total;
            return View(_viewmodel.ConvertCollectionToViewModel(_repos.GetAll().OrderBy(s => s.Name).ToPagedList(1, _pageSize)));
        }

        //
        // GET: /VenueAdmin/Details/5

        public ActionResult Details(int id = 0)
        {
            Venue venue = _repos.GetSingle(id);
            if (venue == null)
            {
                return HttpNotFound();
            }
            return View(venue);
        }

        //
        // GET: /VenueAdmin/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /VenueAdmin/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Venue venue)
        {
            if (ModelState.IsValid)
            {
                _repos.Insert(venue); 
                return RedirectToAction("Index");
            }

            return View(venue);
        }

        //
        // GET: /VenueAdmin/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Venue venue = _repos.GetSingle(id);
            if (venue == null)
            {
                return HttpNotFound();
            }
            return View(venue);
        }

        //
        // POST: /VenueAdmin/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Venue venue)
        {
            if (ModelState.IsValid)
            {
                _repos.Update(venue);
                return RedirectToAction("Index");
            }
            return View(venue);
        }

        //
        // GET: /VenueAdmin/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Venue venue = _repos.GetSingle(id);
            if (venue == null)
            {
                return HttpNotFound();
            }
            return View(venue);
        }

        //
        // POST: /VenueAdmin/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repos.Delete(id);
            return RedirectToAction("Index");
        }

        // KENDO UI specific
        // /ShowAdmin/KendoPageData/
        public ActionResult KendoPageData([DataSourceRequest]DataSourceRequest request)
        {
            int total = _repos.GetAll().Count();

            var result = new DataSourceResult()
            {
                Data = _viewmodel.ConvertCollectionToViewModel(_repos.GetAll().OrderBy(s => s.Name).ToPagedList(request.Page, _pageSize)), // Process data (paging and sorting applied)
                Total = total // Total number of records
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}