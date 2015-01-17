using System.Collections.Generic;
using GigsFirstBLL.ImportShows;
using GigsFirstEntities;

namespace GigsFirstBLL
{
    public interface ITicketmasterImporter : IShowImporter<TicketmasterImportShow>
    {
    }

    public class TicketmasterImporter : ShowImporter<TicketmasterImportShow>, ITicketmasterImporter
    {

        public TicketmasterImporter() {
            this.Vendorid = 3;
            this.Vendor = "ticketmaster";
        }

        public override IEnumerable<TicketmasterImportShow> RetrieveNewShowsFromVendor()
        {
            //http://ticketmaster.productserve.com/v2/UK/event?apiKey=4c869421b3db9beb86ca5650d2c2d039&filter.event.parentCategoryId=10001&filter.venue.city=London&filter.artist.categoryId=200&updatedSince=2011-01-23%2000:00:00&sort.field=eventDate&sort.order=ASC

            //var tmrequest = new Request
            //{
            //    apiKey = "4c869421b3db9beb86ca5650d2c2d039",
            //    updatedSince = "2015-01-15 00:00:00",
            //    country = "UK",
            //    resultsPerPage = 50,
            //    currentPage = 1
            //};

            //var tmservice = new ServiceService();
            //var tmresponse = tmservice.findEvents(tmrequest);

            //var count = tmresponse.details.totalResults;

            //var importshows = from u in tmresponse.ImportShows() select u;

            //return importshows.ToList();

            return new List<TicketmasterImportShow>();
        }
    }
}
