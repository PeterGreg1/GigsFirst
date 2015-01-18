using System;

namespace GigsFirstWebApp.Models
{
    public class SearchModel
    {
        public String Keyword { get; set; }
        public Boolean FutureShows { get; set; }
        public String Postcode { get; set; }
        public Int32 Distance { get; set; }
        public Int32 PageSize { get; set; }
        public Int32 PageIndex { get; set; }

        public SearchModel()
        {
            FutureShows = false;
            Distance = 30;
            PageSize = 10;
            PageIndex = 1;
        }
    }
}