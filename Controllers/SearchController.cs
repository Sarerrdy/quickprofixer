using Microsoft.AspNetCore.Mvc;
using QuickProFixer.DTOs;
using QuickProFixer.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuickProFixer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SearchController : ControllerBase
	{
		private readonly IFixerService _fixerService;

		public SearchController(IFixerService fixerService)
		{
			_fixerService = fixerService;
		}

		/// <summary>
		/// Search for fixers based on skill, location, and ratings.
		/// </summary>
		[HttpGet("fixers")]
		public async Task<IActionResult> SearchFixers([FromQuery] string skillCategory, [FromQuery] string location, [FromQuery] double minRating)
		{
			var fixers = await _fixerService.SearchFixersAsync(skillCategory, location, minRating);
			return Ok(fixers);
		}

		/// <summary>
		/// Filter fixers by skill type, price range, availability, and distance.
		/// </summary>
		[HttpGet("filter/fixers")]
		public async Task<IActionResult> FilterFixers([FromQuery] string skillType, [FromQuery] double minPrice, [FromQuery] double maxPrice, [FromQuery] bool isAvailable, [FromQuery] double maxDistance)
		{
			var fixers = await _fixerService.FilterFixersAsync(skillType, minPrice, maxPrice, isAvailable, maxDistance);
			return Ok(fixers);
		}

		/// <summary>
		/// Get detailed fixer profile.
		/// </summary>
		[HttpGet("fixer/{id}/details")]
		public async Task<IActionResult> GetFixerDetails(int id)
		{
			var fixer = await _fixerService.GetFixerDetailsAsync(id);
			if (fixer == null)
			{
				return NotFound();
			}
			return Ok(fixer);
		}
	}
}
