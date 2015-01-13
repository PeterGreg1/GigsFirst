using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigsFirstWebApp.Models
{
    public class MenuModel
    {
        public List<MenuItem> MenuItems { get; set; }

        public MenuModel()
        {
            MenuItems = new List<MenuItem>();

            MenuItems.Add(new MenuItem
            {
                MenuTitle = "Home",
                NavUrl = "/"
            });
            MenuItems.Add(new MenuItem
            {
                MenuTitle = "Search",
                NavUrl = "/"
            });
        }
    }

    public class MenuItem
    {
        public String MenuTitle { get; set; }
        public String NavUrl { get; set; }
    }
}