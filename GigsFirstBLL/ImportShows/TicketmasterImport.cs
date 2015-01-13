using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GigsFirstBLL.com.productserve.ticketmaster;
using GigsFirstDAL;

namespace GigsFirstBLL
{
    public class TicketmasterImporter : ShowImporter, ITicketmasterImporter
    {
    //API key: 4c869421b3db9beb86ca5650d2c2d039
    //WSDL: http://ticketmaster.productserve.com/v2/soap.php?wsdl

        public TicketmasterImporter() {
            this.vendorid = 3;
        }

        public override int RetrieveNewShowsFromVendor()
        {
            //http://ticketmaster.productserve.com/v2/UK/event?apiKey=4c869421b3db9beb86ca5650d2c2d039&filter.event.parentCategoryId=10001&filter.venue.city=London&filter.artist.categoryId=200&updatedSince=2011-01-23%2000:00:00&sort.field=eventDate&sort.order=ASC


            Request tmrequest = new Request();
            tmrequest.apiKey = "4c869421b3db9beb86ca5650d2c2d039";
            tmrequest.updatedSince = "2012-10-28 13:42:27";
            tmrequest.country = "UK";
            tmrequest.resultsPerPage = 100;

            ServiceService tmservice = new ServiceService();
            Response tmresponse = tmservice.findEvents(tmrequest);

            int? count = tmresponse.details.totalResults;

            var importshows = from u in tmresponse.ImportShows() select u;

            return ExtractNewShows(importshows.ToList());
        }
    }
}
