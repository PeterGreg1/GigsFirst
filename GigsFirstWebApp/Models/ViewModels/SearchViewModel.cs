using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GigsFirstDAL;
using GigsFirstBLL.Search;

namespace GigsFirstWebApp.Models.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        public SearchModel searchModel { get; set; }
        public IEnumerable<Show> shows {get;set;}
        public IEnumerable<Venue> venues { get; set; }
        public IEnumerable<Search> searchResults { get; set; }

        public SearchViewModel()
        {
            searchModel = new SearchModel();
            shows = new List<Show>();
            venues = new List<Venue>();
            searchResults = new List<Search>();
        }
    }


}