using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GigsFirstDAL;
using GigsFirstEntities;

namespace GigsFirstBLL
{
    public class ArtistRepos : BasicCrud<Artist>, IArtistRepos
    {
        public bool MergeArtists(Artist artisttodelete, Artist artisttokeep)
        {
            var shows = from a in db.Shows where a.VenueID == artisttodelete.ArtistID select a;
            foreach (var show in shows)
            {
                show.VenueID = artisttokeep.ArtistID;
            }
            artisttodelete.Deleted = true;
            db.SaveChanges();
            return true;
        }
    }
}
