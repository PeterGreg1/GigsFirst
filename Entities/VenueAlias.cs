using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigsFirstEntities
{
    [Table("VenueAliases")]
    public class VenueAlias : GigsFirstEntity
    {
        [Key]
        public int VenueAliasId { get; set; }
        public int VenueId { get; set; }
        public string Name { get; set; }
        public string Town { get; set; }

        public virtual Venue Venue { get; set; }
    }
}
