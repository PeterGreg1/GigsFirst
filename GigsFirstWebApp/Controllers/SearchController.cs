using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GigsFirstBLL;
using GigsFirstBLL.Search;
using GigsFirstBLL.Shows;
using GigsFirstBLL.Venues;
using GigsFirstEntities;
using GigsFirstWebApp.Models;
using GigsFirstWebApp.Models.ViewModels;
using PagedList;

namespace GigsFirstWebApp.Controllers
{
    public class SearchController : BaseContoller
    {
        IShowRepos _showRepos = new ShowRepos();
        IVenueRepos _venueRepos = new VenueRepos();
        SearchRepos _searchRepos = new SearchRepos();

        public ActionResult Index(SearchModel searchModel)
        {
            var viewmodel = new SearchViewModel();

            if (String.IsNullOrEmpty(searchModel.Keyword))
            {
                return View(viewmodel);
            }

            viewmodel.Shows = DoShowSearch(searchModel);
            viewmodel.Venues = DoVenueSearch(searchModel);
           // viewmodel.searchResults = searchRepos.SearchItems;
            viewmodel.SearchModel = searchModel;

            return View(viewmodel);
        }

        public PartialViewResult GetShows(SearchModel searchModel)
        {
            return PartialView(DoShowSearch(searchModel));
        }

        

        private IEnumerable<Show> DoShowSearch(SearchModel searchModel)
        {
            var shows = _showRepos.Search(a => a.Name.Contains(searchModel.Keyword));

            if (searchModel.FutureShows)
            {
                shows = shows.FilterActiveNotDeletedAndFutureShowsExt();
            }

            if (!String.IsNullOrEmpty(searchModel.Postcode))
            {
                // some function to get lat/long from postcode
                shows = shows.FilterByLocation(53.5546, -2.6491, 10);
            }

            return shows.OrderBy(a => a.ShowDate).ToPagedList(searchModel.PageIndex, searchModel.PageSize).ToList();
        }

        private IEnumerable<Venue> DoVenueSearch(SearchModel searchModel)
        {
            var venues = _venueRepos.Search(a => a.Name.Contains(searchModel.Keyword));

            if (!String.IsNullOrEmpty(searchModel.Postcode))
            {
                // some function to get lat/long from postcode
                venues = venues.FilterByLocation(53.5546, -2.6491, 10);
            }

            return venues.OrderBy(a => a.Name).ToPagedList(searchModel.PageIndex, searchModel.PageSize).ToList();
        }

    }
}
