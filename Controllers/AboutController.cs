using Microsoft.AspNetCore.Mvc;
using MotoHelp.Data.Interfaces;

namespace MotoHelp.Controllers
{
    [Route("about")]
    public class AboutController : Controller
    {
        private readonly ITextFieldsRepository textFieldsRepository;
        public AboutController(ITextFieldsRepository textFieldsRepository)
        {
            this.textFieldsRepository = textFieldsRepository;
        }
        public IActionResult Index()
        {
            var page = textFieldsRepository.GetTextFieldByPageName("PageAbout");
            return View(page);
        }
    }
}
