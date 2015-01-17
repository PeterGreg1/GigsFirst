using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GigsFirstEntities
{
    [Table("USerProfiles")]
    public class UserProfile : GigsFirstEntity
    {
        public UserProfile()
        {
            this.UserShows = new HashSet<UserShow>();
        }

        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<UserShow> UserShows { get; set; }
    }
}
