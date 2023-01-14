using GradingApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace GradingApp.Controllers
{
    public class SecretariesController : Controller
    {
        private readonly ApplicationDBContext _db;
        public SecretariesController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registration(string Username)
        {
            ViewBag.Username = Username;
            return View("Registration");
        }
        public IActionResult AssignCourse(string Username) 
        {
            ViewBag.Username = Username;
            return View("AssignCourse");
        }
        public IActionResult AllCourses(string Username)
        {
            ViewBag.Course = _db.Course.ToList();
            ViewBag.Students = _db.Students.ToList();
            ViewBag.Professors = _db.Professors.ToList();
            ViewBag.CourseHasStudents = _db.CourseHasStudents.ToList();
            ViewBag.Username = Username;
            if (_db.Course == null)
            {
                return Problem("Entity set 'ApplicationDBContext.Course'  is null.");
            }

            return View("AllCourses");
        }

        public IActionResult Register() {
            return View();
        }
    }
}
