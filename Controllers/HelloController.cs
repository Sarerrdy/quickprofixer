using Microsoft.AspNetCore.Mvc;

namespace QuickProFixer.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class HelloController : ControllerBase
	{
		[HttpGet]
		public IActionResult Get()
		{
			return Ok("Hello World!");
		}
	}
}
