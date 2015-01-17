using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GigsFirstEntities
{
    [Table("ImportShows")]
    public class ImportShow : GigsFirstEntity
    {
        [Key]
        public int ImportShowID { get; set; }
        public Nullable<int> VendorID { get; set; }
        public string Name { get; set; }
        public System.DateTime ShowDate { get; set; }
        public string ShowVendorRef { get; set; }
        public string VenueName { get; set; }
        public Nullable<int> GFVenueID { get; set; }
        public string VenueVendorID { get; set; }
        public string VenueTown { get; set; }
        public string VenuePostcode { get; set; }
        public string VenueLat { get; set; }
        public string VenueLong { get; set; }
        public Nullable<int> GFArtistID { get; set; }
        public string ArtistName { get; set; }
    }

    [NotMapped]
    public class SeeTicketsImportShow : ImportShow
    {
    
    }

    [NotMapped]
    public class TicketmasterImportShow : ImportShow
    {

    }
}
