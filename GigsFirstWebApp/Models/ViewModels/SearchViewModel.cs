using System.Collections.Generic;
using GigsFirstBLL.Search;
using GigsFirstEntities;

namespace GigsFirstWebApp.Models.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        public SearchModel SearchModel { get; set; }
        public IEnumerable<Show> Shows {get;set;}
        public IEnumerable<Venue> Venues { get; set; }
        public IEnumerable<Search> SearchResults { get; set; }

        public SearchViewModel()
        {
            SearchModel = new SearchModel();
            Shows = new List<Show>();
            Venues = new List<Venue>();
            SearchResults = new List<Search>();
        }
    }


}