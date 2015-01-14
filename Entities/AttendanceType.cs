using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GigsFirstEntities
{
    [Table("AttendanceTypes")]
    public class AttendanceType
    {
        public AttendanceType()
        {
            this.UserShows = new HashSet<UserShow>();
        }

        [Key]
        public int AttendanceTypeID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserShow> UserShows { get; set; }
    }
}
