using System.Linq;
using System.Web.Mvc;
using GigsFirst.Models.ViewModels;
using GigsFirstBLL;
using GigsFirstEntities;
using Kendo.Mvc.UI;
using PagedList;

namespace GigsFirst.Controllers
{
    public class ShowAdminController : Controller
    {
        IShowRepos _showrepos = new ShowRepos();
        IVenueRepos _venuerepos = new VenueRepos();
        IShowStatusRepos _showstatusrepos = new ShowStatusRepos();
        IShowCategoryRepos _showcategoryrepos = new ShowCategoryRepos();
        ShowAdminViewModel _viewmodel = new ShowAdminViewModel();

        private int _pageSize = 20;

        //
        // GET: /ShowAdmin/

        public ActionResult Index([DataSourceRequest]DataSourceRequest request)
        {
            int total = _showrepos.GetAll().Count();
            request.PageSize = total;
            ViewData["total"] = total;
            return View(_viewmodel.ConvertCollectionToViewModel(_showrepos.GetAll().OrderBy(s => s.ShowDate).ToPagedList(1, _pageSize)));
        }

        //
        // GET: /ShowAdmin/Details/5

        public ActionResult Details(int id = 0)
        {
            Show show = _showrepos.GetSingle(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            return View(show);
        }

        //
        // GET: /ShowAdmin/Create

        public ActionResult Create()
        {
            ViewBag.VenueID = new SelectList(_venuerepos.GetAll(), "VenueID", "Name");
            ViewBag.CategoryID = new SelectList(_showcategoryrepos.GetAll(), "ShowCategoryID", "Name");
            ViewBag.StatusID = new SelectList(_showstatusrepos.GetAll(), "StatusID", "Name");
            return View();
        }

        //
        // POST: /ShowAdmin/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Show show)
        {
            if (ModelState.IsValid)
            {
                _showrepos.Insert(show);
                return RedirectToAction("Index");
            }

            ViewBag.VenueID = new SelectList(_venuerepos.GetAll(), "VenueID", "Name", show.VenueId);
            ViewBag.CategoryID = new SelectList(_showcategoryrepos.GetAll(), "ShowCategoryID", "Name", show.CategoryId);
            ViewBag.StatusID = new SelectList(_showstatusrepos.GetAll(), "StatusID", "Name", show.StatusId);
            return View(show);
        }

        //
        // GET: /ShowAdmin/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Show show = _showrepos.GetSingle(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            ViewBag.VenueID = new SelectList(_venuerepos.GetAll(), "VenueID", "Name", show.VenueId);
            ViewBag.CategoryID = new SelectList(_showcategoryrepos.GetAll(), "ShowCategoryID", "Name", show.CategoryId);
            ViewBag.StatusID = new SelectList(_showstatusrepos.GetAll(), "StatusID", "Name", show.StatusId);
            return View(show);
        }

        //
        // POST: /ShowAdmin/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Show show)
        {
            if (ModelState.IsValid)
            {
                _showrepos.Update(show);
                return RedirectToAction("Index");
            }
            ViewBag.VenueID = new SelectList(_venuerepos.GetAll(), "VenueID", "Name", show.VenueId);
            ViewBag.CategoryID = new SelectList(_showcategoryrepos.GetAll(), "ShowCategoryID", "Name", show.CategoryId);
            ViewBag.StatusID = new SelectList(_showstatusrepos.GetAll(), "StatusID", "Name", show.StatusId);
            return View(show);
        }

        //
        // GET: /ShowAdmin/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Show show = _showrepos.GetSingle(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            return View(show);
        }

        //
        // POST: /ShowAdmin/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _showrepos.Delete(id);
            return RedirectToAction("Index");
        }

        // KENDO UI specific
        // /ShowAdmin/KendoPageData/
        public ActionResult KendoPageData([DataSourceRequest]DataSourceRequest request)
        {
            int total = _showrepos.GetAll().Count();
            var returnViewModel = _viewmodel.ConvertCollectionToViewModel(_showrepos.GetAll().OrderBy(s => s.ShowDate).ToPagedList(request.Page, _pageSize));
     
            var result = new DataSourceResult()
            {
                Data = returnViewModel, // Process data (paging and sorting applied)
                Total = total // Total number of records
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}