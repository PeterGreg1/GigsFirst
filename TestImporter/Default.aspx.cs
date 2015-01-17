using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace TestImporter
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var test = new XmlTextReader("https://api.seetickets.com/1/shows/all?key=a441bcf816e24f5aac22349440a89d7f&max=1&page=1").Read();
            var blah = "";
        }
    }
}