using Microsoft.AspNetCore.Mvc;

namespace GradingApp.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
