using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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
        public int ArtistID { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<ArtistAlias> ArtistAliases { get; set; }
        public virtual ICollection<ShowArtist> ShowArtists { get; set; }
    }
}
