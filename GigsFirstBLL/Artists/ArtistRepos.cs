using System.Linq;
using GigsFirstEntities;

namespace GigsFirstBLL
{
    public class ArtistRepos : BasicCrud<Artist>, IArtistRepos
    {
        public bool MergeArtists(Artist artisttodelete, Artist artisttokeep)
        {
            var shows = from a in Db.Shows where a.VenueId == artisttodelete.ArtistId select a;
            foreach (var show in shows)
            {
                show.VenueId = artisttokeep.ArtistId;
            }
            artisttodelete.Deleted = true;
            Db.SaveChanges();
            return true;
        }
    }
}
