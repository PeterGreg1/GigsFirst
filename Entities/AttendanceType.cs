using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigsFirstEntities
{
    [Table("AttendanceTypes")]
    public class AttendanceType : GigsFirstEntity
    {
        public AttendanceType()
        {
            this.UserShows = new HashSet<UserShow>();
        }

        [Key]
        public int AttendanceTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserShow> UserShows { get; set; }
    }
}
