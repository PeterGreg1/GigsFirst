using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GigsFirstDAL;

namespace GigsFirst.Models.ViewModels
{
    public class ArtistEditorViewModel : BaseViewModel<ArtistEditorViewModel, Artist>
    {
        public ArtistEditorViewModel()
        {

        }

        public ArtistEditorViewModel(Artist artist)
        {
            this.ArtistID = artist.ArtistID;
            this.Name = artist.Name;
        }

        public int ArtistID { get; set; }
        public string Name { get; set; }
    }
}