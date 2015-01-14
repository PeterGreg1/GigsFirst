using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GigsFirstEntities
{
    [Table("ShowArtists")]
    public class ShowArtist
    {
        [Key]
        public int ShowArtistID { get; set; }
        public int ShowID { get; set; }
        public int ArtistID { get; set; }
        public System.DateTime AddedOn { get; set; }
        public Nullable<System.Guid> AddedBy { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual Show Show { get; set; }
    }
}
