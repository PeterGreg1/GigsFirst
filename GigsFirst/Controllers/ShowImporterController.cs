﻿using System.Web.Mvc;
using GigsFirstBLL;
using GigsFirstBLL.ImportShows;

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
