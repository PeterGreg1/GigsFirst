//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GigsFirstDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Artist
    {
        public Artist()
        {
            this.ArtistAliases = new HashSet<ArtistAlias>();
            this.ShowArtists = new HashSet<ShowArtist>();
        }
    
        public int ArtistID { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
    
        public virtual ICollection<ArtistAlias> ArtistAliases { get; set; }
        public virtual ICollection<ShowArtist> ShowArtists { get; set; }
    }
}