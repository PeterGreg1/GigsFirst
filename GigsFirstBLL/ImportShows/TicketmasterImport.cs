using System.Collections.Generic;
using System.Linq;
using System.Xml;
using GigsFirstBLL.ImportShows;
using GigsFirstBLL.Shows;
using GigsFirstEntities;

namespace GigsFirstBLL
{
    public interface ITicketmasterImporter : IShowImporter<TicketmasterImportShow>
    {
    }

    public class TicketmasterImporter : ShowImporter<TicketmasterImportShow>, ITicketmasterImporter
    {

        public TicketmasterImporter() {
            this.Apiurl = "http://ticketmaster.productserve.com/v3/event?apiKey=4c869421b3db9beb86ca5650d2c2d039&country=UK&filter.event.parentCategoryId=10001&filter.venue.city=London&filter.artist.categoryId=200&updatedSince=2014-01-23%2000:00:00&sort.field=eventDate&sort.order=ASC&resultsPerPage=1&currentPage=1";
            this.Vendorid = 3;
            this.Vendor = "ticketmaster";
        }

        public override IEnumerable<TicketmasterImportShow> RetrieveNewShowsFromVendor()
        {
            //http://ticketmaster.productserve.com/v2/UK/event?apiKey=4c869421b3db9beb86ca5650d2c2d039&filter.event.parentCategoryId=10001&filter.venue.city=London&filter.artist.categoryId=200&updatedSince=2011-01-23%2000:00:00&sort.field=eventDate&sort.order=ASC

            using (var reader = new XmlTextReader(Apiurl))
            {
                var importshows = (from u in reader.ImportTmShows() select u).ToList();
                return importshows;
            }
        }
    }
}
