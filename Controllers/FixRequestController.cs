using Microsoft.AspNetCore.Mvc;
using QuickProFixer.DTOs;
using QuickProFixer.Services;
using System.Threading.Tasks;

namespace QuickProFixer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FixRequestController : ControllerBase
	{
		private readonly IFixRequestService _fixRequestService;
		private readonly IAddressService _addressService;

		public FixRequestController(IFixRequestService fixRequestService, IAddressService addressService)
		{
			_fixRequestService = fixRequestService;
			_addressService = addressService;
		}

		/// <summary>
		/// Create a new fix request.
		/// </summary>
		[HttpPost("fix-request")]
		public async Task<IActionResult> CreateFixRequest([FromBody] FixRequestDto fixRequestDto)
		{
			// Check if AddressId is null or zero, indicating a new address
			if (fixRequestDto.AddressId == 0 && fixRequestDto.Address != null)
			{
				// Create a new address
				var newAddress = new AddressDto
				{
					AddressLine = fixRequestDto.Address.AddressLine,
					Landmark = fixRequestDto.Address.Landmark,
					Town = fixRequestDto.Address.Town,
					LGA = fixRequestDto.Address.LGA,
					State = fixRequestDto.Address.State,
					ZipCode = fixRequestDto.Address.ZipCode,
					Country = fixRequestDto.Address.Country
				};

				var createdAddress = await _addressService.CreateAddressAsync(newAddress);
				fixRequestDto.AddressId = createdAddress.Id;
			}

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

		/// <summary>
		/// Accept a fix request.
		/// </summary>
		[HttpPost("fix-requests/{id}/accept")]
		public async Task<IActionResult> AcceptFixRequest(int id, [FromQuery] string fixerId)
		{
			var result = await _fixRequestService.AcceptFixRequestAsync(id, fixerId);
			if (!result)
			{
				return BadRequest("Unable to accept fix request.");
			}
			return Ok("Fix request accepted.");
		}

		/// <summary>
		/// Reject a fix request.
		/// </summary>
		[HttpPost("fix-requests/{id}/reject")]
		public async Task<IActionResult> RejectFixRequest(int id, [FromQuery] string fixerId)
		{
			var result = await _fixRequestService.RejectFixRequestAsync(id, fixerId);
			if (!result)
			{
				return BadRequest("Unable to reject fix request.");
			}
			return Ok("Fix request rejected.");
		}
	}
}