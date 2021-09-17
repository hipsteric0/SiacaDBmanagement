using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiacaCSAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DBManagementController : ControllerBase
	{
		[HttpGet]
		public IActionResult Get()
		{
			return Ok("wenas");
		}

		[HttpPost]
		public IActionResult Post(JObject payload)
		{
			return Ok(payload);
		}
	}
}
