using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigsFirstEntities
{
    [Table("ShowStatuses")]
    public class ShowStatus : GigsFirstEntity
    {
        public ShowStatus()
        {
            this.Shows = new HashSet<Show>();
        }

        [Key]
        public int StatusId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Show> Shows { get; set; }
    }
}
