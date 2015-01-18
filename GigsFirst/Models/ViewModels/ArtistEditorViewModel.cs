using GigsFirstEntities;

namespace GigsFirst.Models.ViewModels
{
    public class ArtistEditorViewModel : BaseViewModel<ArtistEditorViewModel, Artist>
    {
        public ArtistEditorViewModel()
        {

        }

        public ArtistEditorViewModel(Artist artist)
        {
            this.ArtistId = artist.ArtistId;
            this.Name = artist.Name;
        }

        public int ArtistId { get; set; }
        public string Name { get; set; }
    }
}