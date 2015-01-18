using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigsFirstEntities
{
    [Table("ShowCategories")]
    public class ShowCategory : GigsFirstEntity
    {
        public ShowCategory()
        {
            this.Shows = new HashSet<Show>();
        }

        [Key]
        public int ShowCategoryId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<Show> Shows { get; set; }
    }
}
