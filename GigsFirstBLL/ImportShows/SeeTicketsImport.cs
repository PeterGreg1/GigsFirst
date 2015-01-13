using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigsFirstBLL
{
    public class SeeTicketsImporter : ShowImporter, ISeeTicketsImporter
    {
        string deltaid { get; set; }

        public SeeTicketsImporter()
        {
            this.apiurl = "http://api.seetickets.com/1/shows/all?key=a441bcf816e24f5aac22349440a89d7f&max=50";
            this.vendorid = 2;
        }

        private string GetDeltaID()
        {
            return "";
        }
    }
}
