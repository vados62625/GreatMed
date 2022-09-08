using Microsoft.AspNetCore.Mvc;

namespace GreatMed.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
