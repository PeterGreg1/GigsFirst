using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GigsFirstEntities
{
    [Table("VenueAliases")]
    public class VenueAlias : GigsFirstEntity
    {
        [Key]
        public int VenueAliasID { get; set; }
        public int VenueID { get; set; }
        public string Name { get; set; }
        public string Town { get; set; }

        public virtual Venue Venue { get; set; }
    }
}
