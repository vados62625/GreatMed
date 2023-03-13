using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotoHelp.Data.Interfaces;
using MotoHelp.Models;

namespace MotoHelp.Controllers
{
	[Route("api/ajax")]
	[ApiController]
	public class AjaxController : ControllerBase
	{
		private readonly ICallsRepository _callsRepository;
		public AjaxController(ICallsRepository callsRepository) {
			_callsRepository = callsRepository;
		}
		[HttpPost]
		[Route("request-call")]
		public void RequestCall([FromForm] RequestedCall call)
		{
			_callsRepository.AddCall(call);
		}
	}
}
