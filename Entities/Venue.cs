using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace GigsFirstEntities
{
    [Table("Venues")]
    public class Venue : GigsFirstEntity
    {
        public Venue()
        {
            this.Shows = new HashSet<Show>();
            this.VenueAliases = new HashSet<VenueAlias>();
        }

        [Key]
        public int VenueId { get; set; }
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Town { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public DbGeography Geography { get; set; }

        public virtual ICollection<Show> Shows { get; set; }
        public virtual ICollection<VenueAlias> VenueAliases { get; set; }
    }
}
