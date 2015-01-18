using System.Web.Mvc;
using GigsFirstBLL;
using GigsFirstWebApp.Models.ViewModels;

namespace GigsFirstWebApp.Controllers
{
    public class ShowController : BaseContoller
    {
        IShowRepos _repos = new ShowRepos();

        public ActionResult Index(int id = 0)
        {
            var viewmodel = new ShowViewModel();
            viewmodel.Show = _repos.GetSingle(id);
            return View(viewmodel);
        }

    }
}
