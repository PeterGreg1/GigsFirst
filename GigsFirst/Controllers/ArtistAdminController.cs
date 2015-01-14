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
    public class ArtistAdminController : Controller
    {
        IArtistRepos repos = new ArtistRepos();

        //
        // GET: /ArtistAdmin/

        public ActionResult Index()
        {
            return View(repos.GetAll());
        }

        //
        // GET: /ArtistAdmin/Details/5

        public ActionResult Details(int id = 0)
        {
            Artist artist = repos.GetSingle(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        //
        // GET: /ArtistAdmin/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ArtistAdmin/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Artist artist)
        {
            if (ModelState.IsValid)
            {
                repos.Insert(artist);
                return RedirectToAction("Index");
            }

            return View(artist);
        }

        //
        // GET: /ArtistAdmin/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Artist artist = repos.GetSingle(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        //
        // POST: /ArtistAdmin/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Artist artist)
        {
            if (ModelState.IsValid)
            {
                repos.Update(artist);
                return RedirectToAction("Index");
            }
            return View(artist);
        }

        //
        // GET: /ArtistAdmin/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Artist artist = repos.GetSingle(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        //
        // POST: /ArtistAdmin/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repos.Delete(id);
            return RedirectToAction("Index");
        }
    }
}