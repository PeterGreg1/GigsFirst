using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GigsFirstDAL;
using GigsFirstBLL;
using PagedList;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using GigsFirst.Models.ViewModels;

namespace GigsFirst.Controllers
{
    public class ShowAdminController : Controller
    {
        IShowRepos showrepos = new ShowRepos();
        IVenueRepos venuerepos = new VenueRepos();
        IShowStatusRepos showstatusrepos = new ShowStatusRepos();
        IShowCategoryRepos showcategoryrepos = new ShowCategoryRepos();
        ShowAdminViewModel viewmodel = new ShowAdminViewModel();

        private int _PageSize = 20;

        //
        // GET: /ShowAdmin/

        public ActionResult Index([DataSourceRequest]DataSourceRequest request)
        {
            int total = showrepos.GetAll().Count();
            request.PageSize = total;
            ViewData["total"] = total;
            return View(viewmodel.ConvertCollectionToViewModel(showrepos.GetAll().OrderBy(s => s.ShowDate).ToPagedList(1, _PageSize)));
        }

        //
        // GET: /ShowAdmin/Details/5

        public ActionResult Details(int id = 0)
        {
            Show show = showrepos.GetSingle(id);
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
            ViewBag.VenueID = new SelectList(venuerepos.GetAll(), "VenueID", "Name");
            ViewBag.CategoryID = new SelectList(showcategoryrepos.GetAll(), "ShowCategoryID", "Name");
            ViewBag.StatusID = new SelectList(showstatusrepos.GetAll(), "StatusID", "Name");
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
                showrepos.Insert(show);
                return RedirectToAction("Index");
            }

            ViewBag.VenueID = new SelectList(venuerepos.GetAll(), "VenueID", "Name", show.VenueID);
            ViewBag.CategoryID = new SelectList(showcategoryrepos.GetAll(), "ShowCategoryID", "Name", show.CategoryID);
            ViewBag.StatusID = new SelectList(showstatusrepos.GetAll(), "StatusID", "Name", show.StatusID);
            return View(show);
        }

        //
        // GET: /ShowAdmin/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Show show = showrepos.GetSingle(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            ViewBag.VenueID = new SelectList(venuerepos.GetAll(), "VenueID", "Name", show.VenueID);
            ViewBag.CategoryID = new SelectList(showcategoryrepos.GetAll(), "ShowCategoryID", "Name", show.CategoryID);
            ViewBag.StatusID = new SelectList(showstatusrepos.GetAll(), "StatusID", "Name", show.StatusID);
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
                showrepos.Update(show);
                return RedirectToAction("Index");
            }
            ViewBag.VenueID = new SelectList(venuerepos.GetAll(), "VenueID", "Name", show.VenueID);
            ViewBag.CategoryID = new SelectList(showcategoryrepos.GetAll(), "ShowCategoryID", "Name", show.CategoryID);
            ViewBag.StatusID = new SelectList(showstatusrepos.GetAll(), "StatusID", "Name", show.StatusID);
            return View(show);
        }

        //
        // GET: /ShowAdmin/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Show show = showrepos.GetSingle(id);
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
            showrepos.Delete(id);
            return RedirectToAction("Index");
        }

        // KENDO UI specific
        // /ShowAdmin/KendoPageData/
        public ActionResult KendoPageData([DataSourceRequest]DataSourceRequest request)
        {
            int total = showrepos.GetAll().Count();
            var returnViewModel = viewmodel.ConvertCollectionToViewModel(showrepos.GetAll().OrderBy(s => s.ShowDate).ToPagedList(request.Page, _PageSize));
     
            var result = new DataSourceResult()
            {
                Data = returnViewModel, // Process data (paging and sorting applied)
                Total = total // Total number of records
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}