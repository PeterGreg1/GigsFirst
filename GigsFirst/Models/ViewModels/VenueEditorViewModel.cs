﻿using GigsFirstEntities;

namespace GigsFirst.Models.ViewModels
{
    public class VenueEditorViewModel : BaseViewModel<VenueEditorViewModel, Venue>
    {
        public VenueEditorViewModel()
        {

        }

        public VenueEditorViewModel(Venue venue)
        {
            this.VenueId = venue.VenueId;
            this.Name = venue.Name;
            this.AddressLine1 = venue.AddressLine1;
            this.AddressLine2 = venue.AddressLine2;
            this.Town = venue.Town;
            this.City = venue.City;
            this.County = venue.County;
            this.Postcode = venue.Postcode;
        }

        public int VenueId { get; set; }
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Town { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
    }
}