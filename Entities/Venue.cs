using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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
        public int VenueID { get; set; }
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Town { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public Nullable<double> Latitude { get; set; }
        public Nullable<double> Longitude { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public System.Data.Entity.Spatial.DbGeography Geography { get; set; }

        public virtual ICollection<Show> Shows { get; set; }
        public virtual ICollection<VenueAlias> VenueAliases { get; set; }
    }
}
