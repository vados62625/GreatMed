using System;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotoHelp.Data;
using MotoHelp.Data.Interfaces;
using MotoHelp.Models;
using MotoHelp.Service;

namespace MotoHelp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/details/{action=Index}")]
    [Authorize]
    public class GetDetailsController : Controller
    {
        private readonly ILogger _logger;
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        public GetDetailsController(DataManager dataManager, IWebHostEnvironment hostingEnvironment, ILogger<GetDetailsController> logger)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(dataManager);
        }

        public IActionResult Edit(int id)
        {
            var entity = id == default ? new MHDetail() : dataManager.GetDetails.GetDetailById(id);

            var categories = dataManager.GetDetailCategories.categories.ToList();
            ViewBag.Categories = categories;

            return View(entity);
        }
        [HttpPost]
        public IActionResult Edit(MHDetail model, IFormFile? titleImageFile, IEnumerable<IFormFile>? additionalImageFile)
        {
            if (ModelState.IsValid)
            {
                if (titleImageFile != null)
                {
                    string fileName = $"{Guid.NewGuid()}{Path.GetExtension(titleImageFile.FileName)}";
                    try
                    {
                        using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "images/", fileName), FileMode.Create))
                        {
                            titleImageFile.CopyTo(stream);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"Ошибка сохранения файла\n{ex}");
                    }

                    if (model.TitlePictire != null)
                    {
                        model.TitlePictire.Uri = fileName;
                    }
                    else
                    {
                        model.TitlePictire = new ImageUri() { Uri = fileName };
                    }                    
                }
                if (additionalImageFile != null)
                {
                    foreach (var file in additionalImageFile)
                    {
                        string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                        model.AdditionalPictures.Add(new ImageUri(){ Uri = fileName });

                        using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "images/", fileName), FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                    }
                }
                dataManager.GetDetails.EditDetail(model);
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var categories = dataManager.GetDetailCategories.categories.ToList();
            ViewBag.Categories = categories;

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            dataManager.GetDetails.DeleteDetail(id);
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        public IActionResult GetDetails()
        {
            return PartialView();
        }
        [ActionName("removepic")]
        [HttpPost]
        public void RemovePicture (int picId, int detId)
        {
            MHDetail detail = dataManager.GetDetails.GetDetailById(detId);
            if (detail != null)
            {                
                var picture = dataManager.ImagesRepository.GetImageUri(picId);
                dataManager.ImagesRepository.Delete(picId);
            }
        }
    }
}