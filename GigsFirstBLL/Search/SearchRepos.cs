using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigsFirstBLL.Search
{
    public class SearchRepos
    {
        public List<SearchItem> SearchItems {get;set;}

        public void DoSearch(String keyword)
        {
            var list = new List<Search>();
            list.Add(new ShowSearch());
            list.Add(new VenueSearch());

            foreach (var item in list)
            {
                item.keyword = keyword;
               SearchItems.AddRange(item.GetSearchItems());
            }
        }
    }

    public abstract class Search
    {

        public List<SearchItem> SearchItems;

        public String keyword { get; set; }

        protected abstract List<SearchItem> DoSearch();

        public List<SearchItem> GetSearchItems()
        {
            SearchItems.AddRange(DoSearch());
            return SearchItems;
        }
    }

    public class SearchItem
    {
        public String SearchTitle { get; set; }
        public String SearchDesc { get; set; }
    }
}
