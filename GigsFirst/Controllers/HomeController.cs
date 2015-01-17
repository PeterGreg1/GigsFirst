using System.Linq;
using System.Web.Mvc;
using GigsFirst.Models.ViewModels;
using GigsFirstBLL;
using GigsFirstBLL.Shows;

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
