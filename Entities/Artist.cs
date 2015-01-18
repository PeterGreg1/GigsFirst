using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigsFirstEntities
{
    [Table("Artists")]
    public class Artist : GigsFirstEntity
    {
        public Artist()
        {
            this.ArtistAliases = new HashSet<ArtistAlias>();
            this.ShowArtists = new HashSet<ShowArtist>();
        }

        [Key]
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<ArtistAlias> ArtistAliases { get; set; }
        public virtual ICollection<ShowArtist> ShowArtists { get; set; }
    }
}
