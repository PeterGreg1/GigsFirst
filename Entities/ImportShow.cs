using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigsFirstEntities
{
    [Table("ImportShows")]
    public class ImportShow : GigsFirstEntity
    {
        [Key]
        public int ImportShowId { get; set; }
        public int? VendorId { get; set; }
        public string Name { get; set; }
        public DateTime ShowDate { get; set; }
        public string ShowVendorRef { get; set; }
        public string VenueName { get; set; }
        public string VenueVendorId { get; set; }
        public string VenueTown { get; set; }
        public string VenuePostcode { get; set; }
        public string VenueLat { get; set; }
        public string VenueLong { get; set; }
        public string ArtistName { get; set; }
        public int? GfArtistId { get; set; }
        public int? GfVenueId { get; set; }
        public int? GfShowId { get; set; }
    }
}
