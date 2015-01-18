using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
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
        {//XmlReader.Create(New MemoryStream(client.UploadValues(url,Items)))

            var client = new WebClient();

            using (var reader = XmlReader.Create(new MemoryStream(client.UploadValues(Apiurl, new NameValueCollection()))))
            {
                var importshows = (from u in reader.ImportTmShows() select u).ToList();
                return importshows;
            }
        }
    }
}
