using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuickProFixer.Services;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QuickProFixer.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class DashboardController : ControllerBase
	{
		private readonly IDashboardService _dashboardService;

		public DashboardController(IDashboardService dashboardService)
		{
			_dashboardService = dashboardService;
		}

		[HttpGet("client-dashboard")]
		[Authorize(Roles = "Client,Fixer")]
		public async Task<IActionResult> GetClientDashboard()
		{
			var clientId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			if (clientId == null)
			{
				return BadRequest("Client ID is missing.");
			}

			var result = await _dashboardService.GetClientRequestsDashboardAsync(clientId);
			return Ok(result);
		}

		[HttpGet("fixer-dashboard")]
		[Authorize(Roles = "Fixer")]
		public async Task<IActionResult> GetFixerDashboard()
		{
			var fixerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			if (fixerId == null)
			{
				return BadRequest("Fixer ID is missing.");
			}

			var result = await _dashboardService.GetFixerRequestsDashboardAsync(fixerId);
			return Ok(result);
		}
	}
}