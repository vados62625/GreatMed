using Microsoft.AspNetCore.Mvc;
using MotoHelp.Data.Interfaces;
using MotoHelp.Models;

namespace MotoHelp.Controllers
{
    [Route("catalog/{category?}")]
    public class DetailsController : Controller
	{
		private readonly IGetDetails details;
		private readonly IGetDetailCategories categories;
		public DetailsController(IGetDetails _details, IGetDetailCategories _categories)
		{
			details = _details;
			categories = _categories;
		}
        [Route("")]
        public IActionResult Index(string? category)
		{
			IEnumerable<MHDetail> getDetails;
			if (category != null) 
			{
				getDetails = details.GetDetailsByCategory(category);
				MHCategory getCategory = categories.GetCategoryByUrl(category);
				if (getCategory == null) {
					return NotFound();
				}
				ViewBag.Title = getCategory.Name;
				ViewBag.Description = getCategory.Description;
				ViewBag.CurrentCategory = getCategory.Url;
            }
            else
			{
				getDetails = details.details;
				ViewBag.Title = "Запчасти";
			}
			ViewBag.Categories = categories.categories;
            return View(getDetails);
		}
		[Route("{id:int}")]
        public IActionResult Detail(int id)
        {            
            var detail = details.GetDetailById(id);
            return View(detail);
        }
    }
}
