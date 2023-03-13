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
    [Route("admin/calls/{action=Index}")]
    [Authorize]
    public class CallsController : Controller
    {
        private readonly ILogger logger;
        private readonly ICallsRepository callsRepository;
        private readonly IWebHostEnvironment hostingEnvironment;
        public CallsController(ICallsRepository callsRepository, IWebHostEnvironment hostingEnvironment, ILogger<CallsController> logger)
        {
            this.callsRepository = callsRepository;
            this.hostingEnvironment = hostingEnvironment;
            this.logger = logger;
        }

        public IActionResult Index()
        {
            return View(callsRepository.calls.OrderBy(c => c.IsProcessed).ThenByDescending(c => c.DateTime));
        }      

        [HttpPost]
        public IActionResult Delete(int id)
        {
            callsRepository.DeleteCall(id);
            return RedirectToAction(nameof(CallsController.Index), "Calls");
        }
        [HttpPost]
        public IActionResult MarkProcessed(int id)
        {
            callsRepository.UpdateCallStatus(id);
            return RedirectToAction(nameof(HomeController.Index), "Calls");
        }
    }
}