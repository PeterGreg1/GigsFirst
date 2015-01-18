using System;
using System.Linq;
using GigsFirstEntities;

namespace GigsFirstBLL
{
    public interface IShowRepos : IBasicCrud<Show>
    {
        IQueryable<Show> GetShowsByArtistId(int artistId);
        IQueryable<Show> GetShowsByVenueId(int venueId);
        IQueryable<Show> GetShowsByDateRange(DateTime startDate, DateTime endDate);
    }
}
