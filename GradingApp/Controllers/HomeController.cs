using GradingApp.Data;
using GradingApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GradingApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDBContext _db;
        string error;

        public HomeController(ILogger<HomeController> logger, ApplicationDBContext db)
        {
            _logger = logger;
            _db = db;
            error = "";
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginModel model)
        {
            string username = model.Username;
            string password = model.Password;
            
            List<Users> usersList = _db.Users.ToList();
            
            foreach (Users u in usersList)
            {
                if (u.username == username && u.password == password)
                {
                    ViewBag.Username = model.Username;
                    switch (u.role)
                    {
                        case "secretary":
                            return View("~/Views/Secretaries/SecretaryHomepage.cshtml", model);
                        case "professor":
                            return View("~/Views/Professors/TeacherHomepage.cshtml", model);
                        case "student":
                            return View("~/Views/Students/StudentHomepage.cshtml", model);
                        default:
                            return RedirectToAction("Error");
                    }
                }
            }
            return RedirectToAction("Error");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}