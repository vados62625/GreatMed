using Microsoft.AspNetCore.Mvc;

namespace GreatMed.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
