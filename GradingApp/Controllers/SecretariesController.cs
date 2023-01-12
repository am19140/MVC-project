using Microsoft.AspNetCore.Mvc;

namespace GradingApp.Controllers
{
    public class SecretariesController : Controller
    {
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
            ViewBag.Username = Username;
            return View("AllCourses");
        }
    }
}
