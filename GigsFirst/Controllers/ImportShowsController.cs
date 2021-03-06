﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GigsFirst.Models.ViewModels;
using GigsFirstBLL;
using GigsFirstBLL.ImportShows;
using GigsFirstEntities;
using Kendo.Mvc.UI;
using PagedList;

namespace GigsFirst.Controllers
{
    public class ImportShowsController : Controller
    {
        readonly VenueEditorViewModel _venueviewmodel = new VenueEditorViewModel();
        readonly ArtistEditorViewModel _artistviewmodel = new ArtistEditorViewModel();
        readonly IVenueRepos _venueRepos = new VenueRepos();
        readonly IArtistRepos _artistRepos = new ArtistRepos();
        readonly IShowImporter _importshows = new SeeTicketsImporter();
        
        //
        // GET: /ImportShows/

        public ActionResult Index()
        {
            _importshows.UpdateArtists();
            _importshows.UpdateVenues();
            ViewData["Venues"] = _venueviewmodel.ConvertCollectionToViewModel(_venueRepos.GetAll());
            ViewData["Artists"] = _artistviewmodel.ConvertCollectionToViewModel(_artistRepos.GetAll());
            return View();
        }

        public ActionResult ImportMatches()
        {
            _importshows.AddShowsToGf();
            _importshows.RetrieveNewShowsFromVendor();
            return View("Index");
        }

        public ActionResult AddVenues()
        {
            _importshows.AddVenues();
            _importshows.RetrieveNewShowsFromVendor();
            return View("Index");
        }

        public ActionResult AddArtists()
        {
            _importshows.AddArtists();
            _importshows.RetrieveNewShowsFromVendor();
            return View("Index");
        }

        public ActionResult GetNewShowsFromVendor()
        {
            _importshows.RetrieveNewShowsFromVendor();
            return View("Index");
        }

        // KENDO UI specific
        // /ImportShows/KendoPageData/
        public ActionResult KendoPageData([DataSourceRequest]DataSourceRequest request)
        {     
            var shows = _importshows.GetShowsAwaitingImport();
            var result = new DataSourceResult()
            {
                Data = shows.ToPagedList(request.Page, 20), // Process data (paging and sorting applied)
                Total = shows.Count()
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ShowUpdate([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<ImportShow> shows)
        {
            var test = shows;
            //var sdsd = "";
            // Will keep the updated entitites here. Used to return the result later.
            //var entities = new List<Product>();
            //if (ModelState.IsValid)
            //{
            //    using (var northwind = new NorthwindEntities())
            //    {
            //        foreach (var product in products)
            //        {
            //            // Create a new Product entity and set its properties from the posted ProductViewModel
            //            var entity = new Product
            //            {
            //                ProductID = product.ProductID,
            //                ProductName = product.ProductName,
            //                UnitsInStock = product.UnitsInStock
            //            };
            //            // Store the entity for later use
            //            entities.Add(entity);
            //            // Attach the entity
            //            northwind.Products.Attach(entity);
            //            // Change its state to Modified so Entity Framework can update the existing product instead of creating a new one
            //            northwind.Entry(entity).State = EntityState.Modified;
            //            // Or use ObjectStateManager if using a previous version of Entity Framework
            //            // northwind.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
            //        }
            //        // Update the entities in the database
            //        northwind.SaveChanges();
            //    }
            //}
            // Return the updated entities. Also return any validation errors.
           // return Json(entities.ToDataSourceResult(request, ModelState, product => new ProductViewModel
           //// {
           //     ProductID = product.ProductID,
           //     ProductName = product.ProductName,
           //     UnitsInStock = product.UnitsInStock
           // }));

            return View();
        }

    }
}
