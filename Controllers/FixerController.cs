using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuickProFixer.DTOs;
using QuickProFixer.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuickProFixer.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class FixerController : ControllerBase
	{
		private readonly IFixerService _fixerService;
		private readonly ILogger<FixerController> _logger;

		public FixerController(IFixerService fixerService, ILogger<FixerController> logger)
		{
			_fixerService = fixerService;
			_logger = logger;
		}

		/// <summary>
		/// Gets all fixers.
		/// </summary>
		/// <returns>A list of all fixers.</returns>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<FixerDto>>> GetAllFixers()
		{
			_logger.LogInformation("Getting all fixers");
			var fixers = await _fixerService.GetAllFixersAsync();
			if (fixers == null)
			{
				_logger.LogWarning("No fixers found");
				return NotFound("No fixers found.");
			}
			return Ok(fixers);
		}

		/// <summary>
		/// Searches for fixers based on skill category, location, and minimum rating.
		/// </summary>
		/// <param name="skillCategory">The skill category of the fixer.</param>
		/// <param name="location">The location of the fixer.</param>
		/// <param name="minRating">The minimum rating of the fixer.</param>
		/// <returns>A list of fixers that match the search criteria.</returns>
		[HttpGet("search")]
		public async Task<ActionResult<IEnumerable<FixerDto>>> SearchFixers([FromQuery] string skillCategory, [FromQuery] string location, [FromQuery] double minRating)
		{
			_logger.LogInformation("Searching fixers with skillCategory: {SkillCategory}, location: {Location}, minRating: {MinRating}", skillCategory, location, minRating);
			var fixers = await _fixerService.SearchFixersAsync(skillCategory, location, minRating);
			if (fixers == null)
			{
				_logger.LogWarning("No fixers found for the given criteria");
				return NotFound("No fixers found.");
			}
			return Ok(fixers);
		}

		/// <summary>
		/// Filters fixers based on skill type, price range, availability, and distance.
		/// </summary>
		/// <param name="skillType">The skill type of the fixer.</param>
		/// <param name="minPrice">The minimum price of the fixer.</param>
		/// <param name="maxPrice">The maximum price of the fixer.</param>
		/// <param name="isAvailable">The availability of the fixer.</param>
		/// <param name="maxDistance">The maximum distance of the fixer.</param>
		/// <returns>A list of fixers that match the filter criteria.</returns>
		[HttpGet("filter")]
		public async Task<ActionResult<IEnumerable<FixerDto>>> FilterFixers([FromQuery] string skillType, [FromQuery] double minPrice, [FromQuery] double maxPrice, [FromQuery] bool isAvailable, [FromQuery] double maxDistance)
		{
			_logger.LogInformation("Filtering fixers with skillType: {SkillType}, minPrice: {MinPrice}, maxPrice: {MaxPrice}, isAvailable: {IsAvailable}, maxDistance: {MaxDistance}", skillType, minPrice, maxPrice, isAvailable, maxDistance);
			var fixers = await _fixerService.FilterFixersAsync(skillType, minPrice, maxPrice, isAvailable, maxDistance);
			if (fixers == null)
			{
				_logger.LogWarning("No fixers found for the given criteria");
				return NotFound("No fixers found.");
			}
			return Ok(fixers);
		}

		/// <summary>
		/// Gets the details of a specific fixer by ID.
		/// </summary>
		/// <param name="id">The ID of the fixer.</param>
		/// <returns>The details of the fixer.</returns>
		[HttpGet("{id}")]
		public async Task<ActionResult<FixerDto>> GetFixerById(int id)
		{
			_logger.LogInformation("Getting fixer details for ID: {Id}", id);
			var fixer = await _fixerService.GetFixerDetailsAsync(id);
			if (fixer == null)
			{
				_logger.LogWarning("Fixer not found for ID: {Id}", id);
				return NotFound("Fixer not found.");
			}
			return Ok(fixer);
		}
	}
}