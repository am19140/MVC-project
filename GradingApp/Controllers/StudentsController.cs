using GradingApp.Data;
using GradingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace GradingApp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDBContext _db;
        public StudentsController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GradesSubject(string Username)
        {
            ViewBag.Course = _db.Course.ToList();
            ViewBag.Students = _db.Students.ToList();
            ViewBag.CourseHasStudents = _db.CourseHasStudents.ToList();
            ViewBag.Username = Username;
            return View("GradesSubject");
        }

        public IActionResult GradesSemester(string Username)
        {
            ViewBag.Course = _db.Course.ToList();
            ViewBag.Students = _db.Students.ToList();
            ViewBag.CourseHasStudents = _db.CourseHasStudents.ToList();
            ViewBag.Username = Username;
            return View("GradesSemester");
        }

        public IActionResult MyCard(string Username)
        {
            ViewBag.Course = _db.Course.ToList();
            ViewBag.Students = _db.Students.ToList();
            ViewBag.CourseHasStudents = _db.CourseHasStudents.ToList();
            ViewBag.Username = Username;
            return View("MyCard");
        }
    }
}
