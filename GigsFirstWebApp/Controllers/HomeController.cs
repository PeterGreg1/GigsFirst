using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GigsFirstBLL;
using GigsFirstWebApp.Models.ViewModels;
using System.Data;
using GigsFirstBLL.Shows;

namespace GigsFirstWebApp.Controllers
{
    public class HomeController : BaseContoller
    {
        IShowRepos repos = new ShowRepos();
        IVenueRepos venuerepos = new VenueRepos();

        //
        // GET: /Home/

        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            model.shows = repos.GetAll().FilterByLocation(53.5546, -2.6491, 10).ToList();


         //   venuerepos.UpdateGeographyFieldOnVenues();

           

            return View(model);
        }

    }
}
