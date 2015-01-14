using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GigsFirstEntities;

namespace GigsFirstWebApp.Models.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public List<Show> shows { get; set; }
    }
}