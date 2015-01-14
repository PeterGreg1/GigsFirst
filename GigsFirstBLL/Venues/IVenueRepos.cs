using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GigsFirstDAL;
using GigsFirstEntities;

namespace GigsFirstBLL
{
    public interface IVenueRepos : IBasicCrud<Venue>
    {
        bool MergeVenues(Venue venuetodelete, Venue venuetokeep);
        void UpdateGeographyFieldOnVenues();
    }
}
