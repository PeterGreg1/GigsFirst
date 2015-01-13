using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GigsFirstDAL;

namespace GigsFirstBLL
{
    public interface IShowRepos : IBasicCrud<Show>
    {
        IQueryable<Show> GetShowsByArtistID(int ArtistID);
        IQueryable<Show> GetShowsByVenueID(int VenueID);
        IQueryable<Show> GetShowsByDateRange(DateTime StartDate, DateTime EndDate);
    }
}
