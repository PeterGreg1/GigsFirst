using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GigsFirstEntities
{
    [Table("ShowStatuses")]
    public class ShowStatus
    {
        public ShowStatus()
        {
            this.Shows = new HashSet<Show>();
        }

        [Key]
        public int StatusID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Show> Shows { get; set; }
    }
}
