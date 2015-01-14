using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GigsFirstDAL;
using System.Data.Entity.Spatial;
using GigsFirstEntities;

namespace GigsFirstBLL
{
    public class VenueRepos : BasicCrud<Venue>, IVenueRepos
    {
        public bool MergeVenues(Venue venuetodelete, Venue venuetokeep)
        {
            var shows = from a in db.Shows where a.VenueID == venuetodelete.VenueID select a;
            foreach (var show in shows)
            {
                show.VenueID = venuetokeep.VenueID;
            }
            venuetodelete.Deleted = true;
            db.SaveChanges();
            return true;           
        }

        public void UpdateGeographyFieldOnVenues()
        {
            var venues = db.Venues.Where(a => a.Latitude != null && a.Longitude != null).ToList();
            foreach (var venue in venues)
            {
                var latitude = venue.Latitude;
                var longitude = venue.Longitude;
                var pointStringFormat = "POINT({1} {0})";

                var pointString = string.Format(pointStringFormat, latitude.ToString(), longitude.ToString());

                var location = DbGeography.FromText(pointString);
                venue.Geography = location;
                
            }
            db.SaveChanges();
        }
    }
}
