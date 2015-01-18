using System;
using System.Linq;
using GigsFirstEntities;

namespace GigsFirstBLL
{
    public class ShowRepos : BasicCrud<Show>, IShowRepos
    {
        public IQueryable<Show> GetShowsByArtistId(int artistId)
        {
            var shows = (from s in Db.ShowArtists where s.ArtistId == artistId select s.Show);
            return shows;
        }

        public IQueryable<Show> GetShowsByVenueId(int venueId)
        {
            var shows = (from s in Db.Shows where s.VenueId == venueId select s);
            return shows;
        }

        public IQueryable<Show> GetShowsByUserId(int userId)
        {
            var shows = (from s in Db.UserShows where s.UserId == userId select s.Show);
            return shows;
        }

        public IQueryable<UserShow> GetUserShowsByUserId(int userId)
        {
            var usershows = (from s in Db.UserShows where s.UserId == userId select s);
            return usershows;
        }

        public IQueryable<Show> GetShowsByDateRange(DateTime startDate, DateTime endDate)
        {
            var shows = (from s in Db.Shows where s.ShowDate >= startDate && s.ShowDate <= endDate select s);
            return shows;
        }
    }
}
