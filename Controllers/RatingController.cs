// File: Controllers/RatingController.cs
using Microsoft.AspNetCore.Mvc;
using QuickProFixer.DTOs;
using QuickProFixer.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuickProFixer.Controllers
{
	/// <summary>
	/// Controller for managing ratings and reviews.
	/// </summary>
	[ApiController]
	[Route("api/[controller]")]
	public class RatingController : ControllerBase
	{
		private readonly IRatingService _ratingService;

		/// <summary>
		/// Initializes a new instance of the <see cref="RatingController"/> class.
		/// </summary>
		/// <param name="ratingService">The rating service.</param>
		public RatingController(IRatingService ratingService)
		{
			_ratingService = ratingService;
		}

		/// <summary>
		/// Submits a rating and review for a fixer.
		/// </summary>
		/// <param name="fixerRatingDto">The fixer rating data transfer object.</param>
		/// <returns>The submitted fixer rating data transfer object.</returns>
		[HttpPost("fixer")]
		public async Task<IActionResult> SubmitFixerRating([FromBody] FixerRatingDto fixerRatingDto)
		{
			var result = await _ratingService.SubmitFixerRatingAsync(fixerRatingDto);
			if (result == null)
			{
				return BadRequest("Invalid rating details.");
			}
			return Ok(result);
		}

		/// <summary>
		/// Submits a rating and review for a client.
		/// </summary>
		/// <param name="clientRatingDto">The client rating data transfer object.</param>
		/// <returns>The submitted client rating data transfer object.</returns>
		[HttpPost("client")]
		public async Task<IActionResult> SubmitClientRating([FromBody] ClientRatingDto clientRatingDto)
		{
			var result = await _ratingService.SubmitClientRatingAsync(clientRatingDto);
			if (result == null)
			{
				return BadRequest("Invalid rating details.");
			}
			return Ok(result);
		}

		/// <summary>
		/// Gets all ratings and reviews for a fixer.
		/// </summary>
		/// <param name="fixerId">The fixer ID.</param>
		/// <returns>A list of fixer rating data transfer objects.</returns>
		[HttpGet("fixer/{fixerId}")]
		public async Task<IActionResult> GetFixerRatings(string fixerId)
		{
			var ratings = await _ratingService.GetFixerRatingsAsync(fixerId);
			return Ok(ratings);
		}

		/// <summary>
		/// Gets all ratings and reviews for a client.
		/// </summary>
		/// <param name="clientId">The client ID.</param>
		/// <returns>A list of client rating data transfer objects.</returns>
		[HttpGet("client/{clientId}")]
		public async Task<IActionResult> GetClientRatings(string clientId)
		{
			var ratings = await _ratingService.GetClientRatingsAsync(clientId);
			return Ok(ratings);
		}
	}
}