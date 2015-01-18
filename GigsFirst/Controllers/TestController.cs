using System.Text;
using System.Web.Mvc;
using System.Xml;

namespace GigsFirst.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index()
        {
            StringBuilder testing = new StringBuilder();
            XmlReader source = XmlReader.Create("http://api.seetickets.com/1/shows/all/delta?deltaid=22039500&key=a441bcf816e24f5aac22349440a89d7f");     
           while (source.Read()) {
               source.ReadToFollowing("Show");
               testing.Append(source.GetAttribute("Code") + ",");
           }
           string test = testing.ToString();
            return View();
        }

    }
}
