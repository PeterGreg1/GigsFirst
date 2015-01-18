using System.Collections.Generic;
using System.Linq;
using GigsFirstBLL.com.productserve.ticketmaster;
using GigsFirstBLL.ImportShows;
using GigsFirstBLL.Shows;
using GigsFirstEntities;

namespace GigsFirstBLL
{
    public interface ITicketmasterImporter : IShowImporter
    {
    }

    public class TicketmasterImporter : ShowImporter, ITicketmasterImporter
    {

        public TicketmasterImporter() {
            this.Apiurl = "http://ticketmaster.productserve.com/v3/event?apiKey=4c869421b3db9beb86ca5650d2c2d039&country=UK&filter.event.parentCategoryId=10001&filter.venue.city=London&filter.artist.categoryId=200&updatedSince=2014-01-23%2000:00:00&sort.field=eventDate&sort.order=ASC&resultsPerPage=1&currentPage=1";
            this.Vendorid = 3;
            this.Vendor = "ticketmaster";
        }

        public override IEnumerable<ImportShow> RetrieveNewShowsFromVendor()
        {
            var tmrequest = new FindEventsRequest()
            {
                apiKey = "4c869421b3db9beb86ca5650d2c2d039",
                updatedSince = "2015-01-15 00:00:00",
                country = "UK",
                resultsPerPage = 50,
                currentPage = 1
            };

            var tmservice = new ServiceService();
            var tmresponse = tmservice.findEvents(tmrequest);

            var count = tmresponse.details.totalResults;

            var importshows = from u in tmresponse.ImportShows() select u;

            return importshows.ToList();

            //using (var reader = XmlReader.Create(Apiurl))
            //{
            //    var importshows = (from u in reader.ImportTmShows() select u).ToList();
            //    return importshows;
            //}
        }
    }
}
