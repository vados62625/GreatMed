using GreatMed.Data.Interfaces;
using GreatMed.Models;
using Microsoft.AspNetCore.Mvc;

namespace GreatMed.Controllers
{
    public class ServicesController : Controller
    {

        private readonly IGetServices _getServices;

        public ServicesController(IGetServices getServices)
        {
            _getServices = getServices;
        }

        public IActionResult Index()
        {
            var gMServiceList = _getServices;
            return View(_getServices);
        }

    }
}
