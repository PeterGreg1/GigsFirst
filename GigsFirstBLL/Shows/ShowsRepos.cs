using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GigsFirstDAL;
using System.Device.Location;

namespace GigsFirstBLL
{
    public class ShowRepos : BasicCrud<Show>, IShowRepos
    {
        GigsFirstEntities db = new GigsFirstEntities();

        public IQueryable<Show> GetShowsByArtistID(int ArtistID)
        {
            var shows = (from s in db.ShowArtists where s.ArtistID == ArtistID select s.Show);
            return shows;
        }

        public IQueryable<Show> GetShowsByVenueID(int VenueID)
        {
            var shows = (from s in db.Shows where s.VenueID == VenueID select s);
            return shows;
        }

        public IQueryable<Show> GetShowsByUserID(int UserID)
        {
            var shows = (from s in db.UserShows where s.UserID == UserID select s.Show);
            return shows;
        }

        public IQueryable<UserShow> GetUserShowsByUserID(int UserID)
        {
            var usershows = (from s in db.UserShows where s.UserID == UserID select s);
            return usershows;
        }

        public IQueryable<Show> GetShowsByDateRange(DateTime StartDate, DateTime EndDate)
        {
            var shows = (from s in db.Shows where s.ShowDate >= StartDate && s.ShowDate <= EndDate select s);
            return shows;
        }
    }
}
