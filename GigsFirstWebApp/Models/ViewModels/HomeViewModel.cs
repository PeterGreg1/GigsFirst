using System.Collections.Generic;
using GigsFirstEntities;

namespace GigsFirstWebApp.Models.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public List<Show> Shows { get; set; }
    }
}