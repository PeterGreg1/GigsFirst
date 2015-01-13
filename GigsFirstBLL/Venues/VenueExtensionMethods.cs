using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GigsFirstDAL;
using System.Xml;
using GigsFirstBLL.com.productserve.ticketmaster;
using System.Device.Location;
using System.Data.Spatial;

namespace GigsFirstBLL
{
    public static class VenueExtensionMethods
    {
        public static IQueryable<GigsFirstDAL.Venue> FilterByLocation(this IQueryable<GigsFirstDAL.Venue> venues, double latitude, double longitude, double distanceMiles)
        {
            var originPointString = string.Format("POINT({1} {0})",
            latitude.ToString(), longitude.ToString());

            var origin = DbGeography.FromText(originPointString);

            var distanceMeters = distanceMiles * 1609.34d;

            var res = venues.Where(a => a.Geography.Distance(origin) <= distanceMeters);

            return res;

        }

    }
}
