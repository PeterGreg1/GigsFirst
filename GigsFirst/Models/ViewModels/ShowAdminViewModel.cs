using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GigsFirstDAL;

namespace GigsFirst.Models.ViewModels
{
    public class ShowAdminViewModel : BaseViewModel<ShowAdminViewModel,Show>
    {
        public ShowAdminViewModel()
        {

        }

        public ShowAdminViewModel(Show show)
        {
            this.ShowID = show.ShowID;
            this.VenueName = show.Venue.Name;
            this.Name = show.Name;
            this.ShowDate = show.ShowDate;
            this.ShowTime = show.ShowTime;
            this.ShowStatus = show.ShowStatus.Name;
            this.Active = show.Active;
            this.Deleted = show.Deleted;
            this.AddedOn = show.AddedOn;
            this.CategoryName = show.ShowCategory.Name;    
        }

        public int ShowID { get; set; }
        public string VenueName { get; set; }
        public string Name { get; set; }
        public DateTime ShowDate { get; set; }
        public string ShowTime { get; set; }
        public string ShowStatus { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public DateTime AddedOn { get; set; }
        public string CategoryName { get; set; }
    }
}