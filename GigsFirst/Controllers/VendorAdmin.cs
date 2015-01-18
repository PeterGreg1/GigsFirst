using System.Web.Mvc;
using GigsFirstBLL;
using GigsFirstEntities;

namespace GigsFirst.Controllers
{
    public class VendorAdmin : Controller
    {
        IVendorRepos _repos = new VendorRepos();

        //
        // GET: /Default1/

        public ActionResult Index()
        {
            return View(_repos.GetAll());
        }

        //
        // GET: /Default1/Details/5

        public ActionResult Details(int id = 0)
        {
            Vendor vendor = _repos.GetSingle(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        //
        // GET: /Default1/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Default1/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                _repos.Insert(vendor);
                return RedirectToAction("Index");
            }

            return View(vendor);
        }

        //
        // GET: /Default1/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Vendor vendor = _repos.GetSingle(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                _repos.Update(vendor);
                return RedirectToAction("Index");
            }
            return View(vendor);
        }

        //
        // GET: /Default1/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Vendor vendor = _repos.GetSingle(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        //
        // POST: /Default1/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repos.Delete(id);
            return RedirectToAction("Index");
        }
    }
}