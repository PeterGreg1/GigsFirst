using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GigsFirstEntities;
using GigsFirstBLL;

namespace GigsFirst.Controllers
{
    public class ShowStatusAdminController : Controller
    {
        IShowStatusRepos repos = new ShowStatusRepos();

        //
        // GET: /ShowStatusAdmin/

        public ActionResult Index()
        {
            return View(repos.GetAll());
        }

        //
        // GET: /ShowStatusAdmin/Details/5

        public ActionResult Details(int id = 0)
        {
            ShowStatus showstatus = repos.GetSingle(id);
            if (showstatus == null)
            {
                return HttpNotFound();
            }
            return View(showstatus);
        }

        //
        // GET: /ShowStatusAdmin/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ShowStatusAdmin/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShowStatus showstatus)
        {
            if (ModelState.IsValid)
            {
                repos.Update(showstatus);
                return RedirectToAction("Index");
            }

            return View(showstatus);
        }

        //
        // GET: /ShowStatusAdmin/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ShowStatus showstatus = repos.GetSingle(id);
            if (showstatus == null)
            {
                return HttpNotFound();
            }
            return View(showstatus);
        }

        //
        // POST: /ShowStatusAdmin/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ShowStatus showstatus)
        {
            if (ModelState.IsValid)
            {
                repos.Update(showstatus);
                return RedirectToAction("Index");
            }
            return View(showstatus);
        }

        //
        // GET: /ShowStatusAdmin/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ShowStatus showstatus = repos.GetSingle(id);
            if (showstatus == null)
            {
                return HttpNotFound();
            }
            return View(showstatus);
        }

        //
        // POST: /ShowStatusAdmin/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repos.Delete(id);
            return RedirectToAction("Index");
        }
    }
}