using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigsFirstEntities
{
    [Table("ArtistAliases")]
    public class ArtistAlias : GigsFirstEntity
    {
         [Key]
        public int ArtistAliasId { get; set; }
        public int ArtistId { get; set; }
        public string Name { get; set; }

        public virtual Artist Artist { get; set; }
    }
}
