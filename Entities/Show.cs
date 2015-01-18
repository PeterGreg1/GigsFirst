using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigsFirstEntities
{
    [Table("Shows")]
    public class Show : GigsFirstEntity
    {
        public Show()
        {
            this.ShowArtists = new HashSet<ShowArtist>();
            this.ShowVendors = new HashSet<ShowVendor>();
            this.UserShows = new HashSet<UserShow>();
        }

        [Key]
        public int ShowId { get; set; }
        public int VenueId { get; set; }
        [ForeignKey("ShowCategory")]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public DateTime ShowDate { get; set; }
        public string ShowTime { get; set; }
        public int StatusId { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public DateTime AddedOn { get; set; }
        public Guid? AddedBy { get; set; }

        public virtual ICollection<ShowArtist> ShowArtists { get; set; }
        public virtual ShowCategory ShowCategory { get; set; }
        public virtual ShowStatus ShowStatus { get; set; }
        public virtual Venue Venue { get; set; }
        public virtual ICollection<ShowVendor> ShowVendors { get; set; }
        public virtual ICollection<UserShow> UserShows { get; set; }
    }
}
