using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GigsFirstEntities
{
    [Table("ArtistAliases")]
    public class ArtistAlias
    {
         [Key]
        public int ArtistAliasID { get; set; }
        public int ArtistID { get; set; }
        public string Name { get; set; }

        public virtual Artist Artist { get; set; }
    }
}
