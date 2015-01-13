using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GigsFirstBLL;

namespace GigsFirst.Controllers
{
    public class ShowImporterController : Controller
    {
        //
        // GET: /ShowImporter/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ImportSeeTickets()
        {
            var importshows = new SeeTicketsImporter();
            importshows.RetrieveNewShows();
            return View("Index");
        }

        public ActionResult ImportTicketmaster()
        {
            var importshows = new TicketmasterImporter();
            importshows.RetrieveNewShows();
            return View("Index");
        }

    }
}
