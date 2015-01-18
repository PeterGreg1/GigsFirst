using System.Data.Entity.Spatial;
using System.Linq;
using GigsFirstEntities;

namespace GigsFirstBLL
{
    public class VenueRepos : BasicCrud<Venue>, IVenueRepos
    {
        public bool MergeVenues(Venue venuetodelete, Venue venuetokeep)
        {
            var shows = from a in Db.Shows where a.VenueId == venuetodelete.VenueId select a;
            foreach (var show in shows)
            {
                show.VenueId = venuetokeep.VenueId;
            }
            venuetodelete.Deleted = true;
            Db.SaveChanges();
            return true;           
        }

        public void UpdateGeographyFieldOnVenues()
        {
            var venues = Db.Venues.Where(a => a.Latitude != null && a.Longitude != null).ToList();
            foreach (var venue in venues)
            {
                var latitude = venue.Latitude;
                var longitude = venue.Longitude;
                var pointStringFormat = "POINT({1} {0})";

                var pointString = string.Format(pointStringFormat, latitude.ToString(), longitude.ToString());

                var location = DbGeography.FromText(pointString);
                venue.Geography = location;
                
            }
            Db.SaveChanges();
        }
    }
}
