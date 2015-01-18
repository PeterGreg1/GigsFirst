using GigsFirstEntities;

namespace GigsFirstBLL
{
    public interface IVenueRepos : IBasicCrud<Venue>
    {
        bool MergeVenues(Venue venuetodelete, Venue venuetokeep);
        void UpdateGeographyFieldOnVenues();
    }
}
