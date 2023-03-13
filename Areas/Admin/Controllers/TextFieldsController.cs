using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoHelp.Data;
using MotoHelp.Models;
//using MyCompany.Domain;
//using MyCompany.Domain.Entities;
//using MyCompany.Service;

namespace MotoHelp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TextFieldsController : Controller
    {
        private readonly DataManager dataManager;
        public TextFieldsController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View(dataManager.TextFieldsRepository.TextFields);
        }

        public IActionResult Edit(string page)
        {
            var entity = dataManager.TextFieldsRepository.GetTextFieldByPageName(page);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(TextField model)
        {
            if (ModelState.IsValid)
            {
                dataManager.TextFieldsRepository.Edit(model);
                return RedirectToAction(nameof(TextFieldsController.Index), "TextFields");
            }
            return View(model);
        }
    }
}