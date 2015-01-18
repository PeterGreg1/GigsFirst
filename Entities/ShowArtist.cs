using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigsFirstEntities
{
    [Table("ShowArtists")]
    public class ShowArtist : GigsFirstEntity
    {
        [Key]
        public int ShowArtistId { get; set; }
        public int ShowId { get; set; }
        public int ArtistId { get; set; }
        public DateTime AddedOn { get; set; }
        public Guid? AddedBy { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual Show Show { get; set; }
    }
}
