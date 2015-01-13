using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GigsFirstDAL;

namespace GigsFirstBLL
{
    public interface IShowImporter
    {
        int AddShowsToGF();
        int AddVenues();
        int AddArtists();
        int UpdateVenues();
        int UpdateArtists();
        int RetrieveNewShowsFromVendor();
        IQueryable<ImportShow> GetShowsAwaitingImport();
    }
}
