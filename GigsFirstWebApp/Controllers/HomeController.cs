using System.Linq;
using System.Web.Mvc;
using GigsFirstBLL;
using GigsFirstBLL.Shows;
using GigsFirstWebApp.Models.ViewModels;

namespace GigsFirstWebApp.Controllers
{
    public class HomeController : BaseContoller
    {
        IShowRepos _repos = new ShowRepos();
        IVenueRepos _venuerepos = new VenueRepos();

        //
        // GET: /Home/

        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            model.Shows = _repos.GetAll().FilterByLocation(53.5546, -2.6491, 10).ToList();


         //   venuerepos.UpdateGeographyFieldOnVenues();

           

            return View(model);
        }

    }
}
