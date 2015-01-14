using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GigsFirstDAL;
using System.Xml;
using GigsFirstEntities;

namespace GigsFirstBLL
{
    public interface ISeeTicketsImporter : IShowImporter
    {
    }

    public class SeeTicketsImporter : ShowImporter, ISeeTicketsImporter
    {
        string deltaid { get; set; }

        public SeeTicketsImporter()
        {
            this.apiurl = "http://api.seetickets.com/1/shows/all?key=a441bcf816e24f5aac22349440a89d7f&max=50";
            this.vendorid = 2;
            this.vendor = "seetickets";
        }

        private string GetDeltaID()
        {
            return "";
        }

        public override IEnumerable<ImportShow> RetrieveNewShowsFromVendor()
        {
            using (XmlReader reader = XmlReader.Create(apiurl))
            {
                List<ImportShow> importshows = (from u in reader.ImportShows() select u).ToList();
                return importshows;
            }
        }
    }
}
