using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GigsFirstDAL;

namespace GigsFirst.Models.ViewModels
{
    public class VenueAdminViewModel : BaseViewModel<VenueAdminViewModel,Venue>
    {
        public VenueAdminViewModel()
        {
        }

        public VenueAdminViewModel(Venue venue)
        {
            this.VenueID =venue.VenueID;
            this.Name =venue.Name;
            this.AddressLine1 =venue.AddressLine1;
            this.AddressLine2  =venue.AddressLine2;
            this.Town  =venue.Town;
            this.City  =venue.City;
            this.County  =venue.County;
            this.Postcode  =venue.Postcode;
            this.Latitude  =venue.Latitude;
            this.Longitude  =venue.Longitude;
            this.Active  =venue.Active;
            this.Deleted = venue.Deleted;
        }

        public int VenueID { get; set; }
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Town { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public Nullable<double> Latitude { get; set; }
        public Nullable<double> Longitude { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
    }
}