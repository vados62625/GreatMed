using Microsoft.AspNetCore.Mvc;
using MotoHelp.Data.Interfaces;
using MotoHelp.Models;

namespace MotoHelp.Controllers
{
	public class HomeController : Controller
    {
        private readonly ITextFieldsRepository textFieldsRepository;
        public HomeController (ITextFieldsRepository textFieldsRepository)
        {
            this.textFieldsRepository = textFieldsRepository;
        }
		public IActionResult Index()
        {
            TextField page = textFieldsRepository.GetTextFieldByPageName("PageIndex");
            return View(page);
        }
        [Route("privacy")]
        public IActionResult Privacy()
        {
            TextField page = textFieldsRepository.GetTextFieldByPageName("PagePrivacy");
            return View(page);
        }

    }
}
