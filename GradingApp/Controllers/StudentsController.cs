using GradingApp.Data;
using GradingApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GradingApp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDBContext _db;
        public StudentsController(ApplicationDBContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> GradesSubject(string Username, string searchString)
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

            var crs = from c in _db.CourseHasStudents
                         select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                crs = crs.Where(s => s.Course.courseTitle!.Contains(searchString));
            }

            return View(await crs.ToListAsync());
        }


        public async Task<IActionResult> GradesSemesterAsync(string Username, string SemesterNum)
        {
            ViewBag.Course = _db.Course.ToList();
            ViewBag.Students = _db.Students.ToList();
            ViewBag.Professors = _db.Professors.ToList();
            ViewBag.CourseHasStudents = _db.CourseHasStudents.ToList();
            ViewBag.Username = Username;
            var crs = from c in _db.CourseHasStudents
                      select c;
            
            if (!String.IsNullOrEmpty(SemesterNum))
            {
                crs = crs.Where(s => s.Course.courseSemester.ToString() == SemesterNum);
            }

            return View(await crs.ToListAsync());
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
