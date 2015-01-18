using System.Collections.Generic;
using System.Linq;
using System.Xml;
using GigsFirstBLL.Shows;
using GigsFirstEntities;

namespace GigsFirstBLL.ImportShows
{
    public interface ISeeTicketsImporter : IShowImporter
    {
    }

    public class SeeTicketsImporter : ShowImporter, ISeeTicketsImporter
    {
        string Deltaid { get; set; }

        public SeeTicketsImporter()
        {
            this.Apiurl = "https://api.seetickets.com/1/shows/all?key=a441bcf816e24f5aac22349440a89d7f&max=50&page=1";
            this.Vendorid = 2;
            this.Vendor = "seetickets";
        }

        //https://api.seetickets.com/EventService.svc/?key=a441bcf816e24f5aac22349440a89d7f

        private string GetDeltaId()
        {
            return "";
        }

        public override IEnumerable<ImportShow> RetrieveNewShowsFromVendor()
        {
            using (var reader = XmlReader.Create(Apiurl))
            {
                var importshows = (from u in reader.ImportShows() select u).ToList();
                return importshows;
            }
        }
    }
}
