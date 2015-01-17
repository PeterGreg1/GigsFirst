using System.Data.Entity.Spatial;
using System.Linq;
using GigsFirstEntities;

namespace GigsFirstBLL.Venues
{
    public static class VenueExtensionMethods
    {
        public static IQueryable<Venue> FilterByLocation(this IQueryable<Venue> venues, double latitude, double longitude, double distanceMiles)
        {
            var originPointString = string.Format("POINT({1} {0})",
            latitude, longitude);

            var origin = DbGeography.FromText(originPointString);

            var distanceMeters = distanceMiles * 1609.34d;

            var res = venues.Where(a => a.Geography.Distance(origin) <= distanceMeters);

            return res;

        }

    }
}
