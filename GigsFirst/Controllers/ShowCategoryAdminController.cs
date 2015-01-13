using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GigsFirstDAL;
using GigsFirstBLL;

namespace GigsFirst.Controllers
{
    public class ShowCategoryAdminController : Controller
    {
        IShowCategoryRepos repos = new ShowCategoryRepos();

        //
        // GET: /ShowCategoryAdmin/

        public ActionResult Index()
        {
            return View(repos.GetAll());
        }

        //
        // GET: /ShowCategoryAdmin/Details/5

        public ActionResult Details(int id = 0)
        {
            ShowCategory showcategory = repos.GetSingle(id);
            if (showcategory == null)
            {
                return HttpNotFound();
            }
            return View(showcategory);
        }

        //
        // GET: /ShowCategoryAdmin/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ShowCategoryAdmin/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShowCategory showcategory)
        {
            if (ModelState.IsValid)
            {
                repos.Insert(showcategory);
                return RedirectToAction("Index");
            }

            return View(showcategory);
        }

        //
        // GET: /ShowCategoryAdmin/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ShowCategory showcategory = repos.GetSingle(id);
            if (showcategory == null)
            {
                return HttpNotFound();
            }
            return View(showcategory);
        }

        //
        // POST: /ShowCategoryAdmin/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ShowCategory showcategory)
        {
            if (ModelState.IsValid)
            {
                repos.Update(showcategory);
                return RedirectToAction("Index");
            }
            return View(showcategory);
        }

        //
        // GET: /ShowCategoryAdmin/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ShowCategory showcategory = repos.GetSingle(id);
            if (showcategory == null)
            {
                return HttpNotFound();
            }
            return View(showcategory);
        }

        //
        // POST: /ShowCategoryAdmin/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repos.Delete(id);
            return RedirectToAction("Index");
        }
    }
}