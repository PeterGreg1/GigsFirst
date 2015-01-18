using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigsFirstEntities
{
    [Table("UserShows")]
    public class UserShow : GigsFirstEntity
    {
        [Key]
        public int UserShowId { get; set; }
        public int UserId { get; set; }
        public int ShowId { get; set; }
        public int AttendanceTypeId { get; set; }

        public virtual AttendanceType AttendanceType { get; set; }
        public virtual Show Show { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}
