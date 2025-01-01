using Microsoft.AspNetCore.Mvc;
using QuickProFixer.DTOs;
using QuickProFixer.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuickProFixer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FixRequestController : ControllerBase
	{
		private readonly IFixRequestService _fixRequestService;

		public FixRequestController(IFixRequestService fixRequestService)
		{
			_fixRequestService = fixRequestService;
		}

		/// <summary>
		/// Create a new fix request.
		/// </summary>
		[HttpPost("fix-request")]
		public async Task<IActionResult> CreateFixRequest([FromBody] FixRequestDto fixRequestDto)
		{
			var createdFixRequest = await _fixRequestService.CreateFixRequestAsync(fixRequestDto);
			return CreatedAtAction(nameof(GetFixRequestById), new { id = createdFixRequest.Id }, createdFixRequest);
		}

		/// <summary>
		/// Get all fix requests for a client.
		/// </summary>
		[HttpGet("fix-requests")]
		public async Task<IActionResult> GetAllFixRequestsForClient([FromQuery] string clientId)
		{
			var fixRequests = await _fixRequestService.GetAllFixRequestsForClientAsync(clientId);
			return Ok(fixRequests);
		}

		/// <summary>
		/// Get details of a specific fix request.
		/// </summary>
		[HttpGet("fix-requests/{id}")]
		public async Task<IActionResult> GetFixRequestById(int id)
		{
			var fixRequest = await _fixRequestService.GetFixRequestByIdAsync(id);
			if (fixRequest == null)
			{
				return NotFound();
			}
			return Ok(fixRequest);
		}
	}
}
