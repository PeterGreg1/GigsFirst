using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GigsFirstBLL;
using GigsFirstWebApp.Models;
using GigsFirstWebApp.Models.ViewModels;
using System.Data;
using GigsFirstDAL;
using PagedList;

namespace GigsFirstWebApp.Controllers
{
    public class ShowController : BaseContoller
    {
        IShowRepos repos = new ShowRepos();

        public ActionResult Index(int id = 0)
        {
            var viewmodel = new ShowViewModel();
            viewmodel.Show = repos.GetSingle(id);
            return View(viewmodel);
        }

    }
}
