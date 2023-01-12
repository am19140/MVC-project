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
    }
}
