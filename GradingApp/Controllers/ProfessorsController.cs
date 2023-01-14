using GradingApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace GradingApp.Controllers
{
    public class ProfessorsController : Controller
    {
        private readonly ApplicationDBContext _db;
        public ProfessorsController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GradesList(string Username)
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
            return View("GradesList");
        }
    }
}
