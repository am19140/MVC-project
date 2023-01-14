using GradingApp.Data;
using GradingApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IActionResult> GradesList(string Username, string SemesterNum, string searchString)
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
            else
            {
                crs = from c in _db.CourseHasStudents
                      select c;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                crs = crs.Where(s => s.Course.courseTitle!.Contains(searchString));
            }


            return View(await crs.ToListAsync());
        }

        public async Task<IActionResult> EnterGrades(string Username, string SemesterNum, string searchString)
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
            else
            {
                crs = from c in _db.CourseHasStudents
                      select c;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                crs = crs.Where(s => s.Course.courseTitle!.Contains(searchString));
            }


            return View(await crs.ToListAsync());
        }

        public IActionResult SubmitGrade()
        {
            int x = Int32.Parse(Request.Form["regnum"].ToString());
            CourseHasStudents chs = _db.CourseHasStudents.ToList().First(chs => chs.registrationNumber == x);
            chs.grade = Int32.Parse(Request.Form["gradeInput"].ToString());
            _db.CourseHasStudents.Update(chs);
            _db.SaveChanges();
            return View();
        }

        public IActionResult Profile(string Username)
        {
            ViewBag.Professor = _db.Professors.ToList().First(s => s.username == Username);

            ViewBag.Users = _db.Users.ToList().First(s => s.username == Username);
            ViewBag.Username = Username;
            return View("Profile");
        }
    }
}
