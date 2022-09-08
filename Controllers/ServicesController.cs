using Microsoft.AspNetCore.Mvc;

namespace GreatMed.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
