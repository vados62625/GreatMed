using System;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotoHelp.Data;
using MotoHelp.Models;
using MotoHelp.Service;

namespace MotoHelp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/services/{action=Index}")]
    [Authorize]
    public class GetServicesController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        public GetServicesController(DataManager dataManager, IWebHostEnvironment hostingEnvironment)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View(dataManager);
        }

        public IActionResult Edit(int id)
        {
            var entity = id == default ? new MHService() : dataManager.GetServices.GetService(id);
            return View(entity);
        }
        [HttpPost]
        public IActionResult Edit(MHService model, IFormFile? titleImageFile)
        //public IActionResult Edit(MHService model)
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
                        return StatusCode(500);
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
                dataManager.GetServices.EditService(model);
                return RedirectToAction(nameof(HomeController.Index), "GetServices");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            dataManager.GetServices.DeleteService(id);
            return RedirectToAction(nameof(HomeController.Index), "GetServices");
        }

        [ActionName("removepic")]
        [HttpPost]
        public void RemovePicture(int picId, int detId)
        {
            MHService service = dataManager.GetServices.GetService(detId);
            if (service != null)
            {
                var picture = dataManager.ImagesRepository.GetImageUri(picId);
                dataManager.ImagesRepository.Delete(picId);
            }
        }
    }
}