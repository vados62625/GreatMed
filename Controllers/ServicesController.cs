using MotoHelp.Data.Interfaces;
using MotoHelp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MotoHelp.Controllers
{
    [Route("services")]
    public class ServicesController : Controller
    {

        private readonly IGetServices _getServices;

        public ServicesController(IGetServices getServices)
        {
            _getServices = getServices;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Услуги";
            var serviceList = _getServices.activeServices;
            return View(serviceList);
        }

        [HttpPost]
        [Route("detail/{id}")]
        public IActionResult Detail(int id)
        {
            var service = _getServices.GetService(id);
            return PartialView(service);
        }

    }
}
