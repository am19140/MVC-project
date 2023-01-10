using Microsoft.AspNetCore.Mvc;

namespace GradingApp.Controllers
{
    public class ProfessorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
