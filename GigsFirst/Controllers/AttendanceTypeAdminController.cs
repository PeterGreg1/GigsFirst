using System.Web.Mvc;
using GigsFirstBLL;
using GigsFirstEntities;

namespace GigsFirst.Controllers
{
    public class AttendanceTypeAdminController : Controller
    {
        IAttendanceTypeRepos _repos = new AttendanceTypeRepos();

        //
        // GET: /AttendanceTypeAdmin/

        public ActionResult Index()
        {
            return View(_repos.GetAll());
        }

        //
        // GET: /AttendanceTypeAdmin/Details/5

        public ActionResult Details(int id = 0)
        {
            AttendanceType attendancetype = _repos.GetSingle(id);
            if (attendancetype == null)
            {
                return HttpNotFound();
            }
            return View(attendancetype);
        }

        //
        // GET: /AttendanceTypeAdmin/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /AttendanceTypeAdmin/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AttendanceType attendancetype)
        {
            if (ModelState.IsValid)
            {
                _repos.Insert(attendancetype);
                return RedirectToAction("Index");
            }

            return View(attendancetype);
        }

        //
        // GET: /AttendanceTypeAdmin/Edit/5

        public ActionResult Edit(int id = 0)
        {
            AttendanceType attendancetype = _repos.GetSingle(id);
            if (attendancetype == null)
            {
                return HttpNotFound();
            }
            return View(attendancetype);
        }

        //
        // POST: /AttendanceTypeAdmin/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AttendanceType attendancetype)
        {
            if (ModelState.IsValid)
            {
                _repos.Update(attendancetype);
                return RedirectToAction("Index");
            }
            return View(attendancetype);
        }

        //
        // GET: /AttendanceTypeAdmin/Delete/5

        public ActionResult Delete(int id = 0)
        {
            AttendanceType attendancetype = _repos.GetSingle(id);
            if (attendancetype == null)
            {
                return HttpNotFound();
            }
            return View(attendancetype);
        }

        //
        // POST: /AttendanceTypeAdmin/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repos.Delete(id);
            return RedirectToAction("Index");
        }
    }
}