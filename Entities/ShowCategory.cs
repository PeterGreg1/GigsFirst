using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GigsFirstEntities
{
    [Table("ShowCategories")]
    public class ShowCategory
    {
        public ShowCategory()
        {
            this.Shows = new HashSet<Show>();
        }

        [Key]
        public int ShowCategoryID { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<Show> Shows { get; set; }
    }
}
