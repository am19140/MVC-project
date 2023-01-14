using GradingApp.Data;
using Microsoft.AspNetCore.Mvc;
using GradingApp.Models;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> AssignCourse(string Username) 
        {
            ViewBag.Username = Username;
            ViewBag.Professors = _db.Professors.ToList();
            var crs = from c in _db.Course
                      select c;
            return View(await crs.ToListAsync());
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

        public IActionResult RegisterUser() {
            
            Users u = new Users();
            u.username = Request.Form["username"].ToString();
            u.password = Request.Form["password"].ToString();
            if (Request.Form["radio"].ToString() == "professor")
            {
                Professors p = new Professors();
                p.name = Request.Form["name"].ToString();
                p.surname = Request.Form["surname"].ToString();
                p.department = Request.Form["department"].ToString();
                p.afm = Int32.Parse(Request.Form["code"].ToString());
                p.username = Request.Form["username"].ToString();
                u.role = "professor";
                _db.Users.Add(u);
                _db.Professors.Add(p);
            }
            else if (Request.Form["radio"].ToString() == "student")
            {
                Students s = new Students();
                s.name = Request.Form["name"].ToString();
                s.surname = Request.Form["surname"].ToString();
                s.department = Request.Form["department"].ToString();
                s.registressionNumber = Int32.Parse(Request.Form["code"].ToString());
                s.username = Request.Form["username"].ToString();
                u.role = "student";
                _db.Users.Add(u);
                _db.Students.Add(s);        
            }
            else
            {
                
            }
            _db.SaveChanges();
            return View();
        }
        public IActionResult RegisterCourse()
        {
            Course c = new Course();
            c.afm = -1;
            c.courseTitle = Request.Form["title"].ToString();
            c.courseSemester = Int32.Parse(Request.Form["semester"].ToString());
            _db.Course.Add(c);
            _db.SaveChanges();
            return View();
        }

        public IActionResult AssignProfessor()
        {
            int x = Int32.Parse(Request.Form["course"].ToString());
            Course c = _db.Course.ToList().First(c => c.idCourse == x);
            c.afm = Int32.Parse(Request.Form["professor"].ToString());
            _db.Course.Update(c);
            _db.SaveChanges();
            return View();
        }

        public IActionResult AssignStudent()
        {
            CourseHasStudents chs = new CourseHasStudents();
            chs.idCourse = Int32.Parse(Request.Form["course_student"].ToString());
            chs.registrationNumber = Int32.Parse(Request.Form["student"].ToString());
            chs.grade = -1;
            _db.CourseHasStudents.Add(chs);
            _db.SaveChanges();
            return View();
        }
    }
}
