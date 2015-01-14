using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GigsFirstEntities
{
    [Table("Shows")]
    public class Show
    {
        public Show()
        {
            this.ShowArtists = new HashSet<ShowArtist>();
            this.ShowVendors = new HashSet<ShowVendor>();
            this.UserShows = new HashSet<UserShow>();
        }

        [Key]
        public int ShowID { get; set; }
        public int VenueID { get; set; }
        [ForeignKey("ShowCategory")]
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public System.DateTime ShowDate { get; set; }
        public string ShowTime { get; set; }
        public int StatusID { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime AddedOn { get; set; }
        public Nullable<System.Guid> AddedBy { get; set; }

        public virtual ICollection<ShowArtist> ShowArtists { get; set; }
        public virtual ShowCategory ShowCategory { get; set; }
        public virtual ShowStatus ShowStatus { get; set; }
        public virtual Venue Venue { get; set; }
        public virtual ICollection<ShowVendor> ShowVendors { get; set; }
        public virtual ICollection<UserShow> UserShows { get; set; }
    }
}
