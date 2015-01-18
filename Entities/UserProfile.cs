using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
