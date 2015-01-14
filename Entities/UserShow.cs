using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GigsFirstEntities
{
    [Table("UserShows")]
    public class UserShow
    {
        [Key]
        public int UserShowID { get; set; }
        public int UserID { get; set; }
        public int ShowID { get; set; }
        public int AttendanceTypeID { get; set; }

        public virtual AttendanceType AttendanceType { get; set; }
        public virtual Show Show { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}
