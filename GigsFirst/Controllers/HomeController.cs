using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GigsFirstDAL;
using GigsFirstBLL;
using GigsFirst.Models.ViewModels;

namespace GigsFirst.Controllers
{
    public class HomeController : Controller
    {
        IShowRepos repos = new ShowRepos();

        //
        // GET: /Home/

        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel(); 
            model.shows = repos.GetAll().FilterActiveNotDeletedAndFutureShowsExt().ToList();

            return View(model);
        }

    }
}
