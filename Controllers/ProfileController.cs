using Microsoft.AspNetCore.Mvc;
using QuickProFixer.DTOs;
using QuickProFixer.Services;
using System.Threading.Tasks;

namespace QuickProFixer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProfileController : ControllerBase
	{
		private readonly IProfileService _profileService;

		public ProfileController(IProfileService profileService)
		{
			_profileService = profileService;
		}

		/// <summary>
		/// Creates a new fixer profile.
		/// </summary>
		/// <param name="fixerDto">The fixer profile details.</param>
		/// <returns>An IActionResult indicating the result of the profile creation process.</returns>
		[HttpPost("fixer")]
		public async Task<IActionResult> CreateFixerProfile([FromBody] FixerDto fixerDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (fixerDto == null)
			{
				return BadRequest("Invalid fixer profile data.");
			}

			var result = await _profileService.CreateFixerProfileAsync(fixerDto);
			return CreatedAtAction(nameof(GetFixerProfile), new { id = result.Id }, result);
		}

		/// <summary>
		/// Updates an existing fixer profile.
		/// </summary>
		/// <param name="fixerDto">The updated fixer profile details.</param>
		/// <returns>An IActionResult indicating the result of the profile update process.</returns>
		[HttpPut("fixer")]
		public async Task<IActionResult> UpdateFixerProfile([FromBody] FixerDto fixerDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (fixerDto == null)
			{
				return BadRequest("Invalid fixer profile data.");
			}

			var updatedFixer = await _profileService.UpdateFixerProfileAsync(fixerDto);
			if (updatedFixer == null)
			{
				return NotFound("Fixer profile not found.");
			}

			return Ok(updatedFixer);
		}

		/// <summary>
		/// Gets the details of a fixer profile.
		/// </summary>
		/// <param name="id">The ID of the fixer.</param>
		/// <returns>An IActionResult containing the fixer profile details.</returns>
		[HttpGet("fixer/{id}")]
		public async Task<IActionResult> GetFixerProfile(string id)
		{
			var result = await _profileService.GetFixerProfileAsync(id);
			if (result == null)
			{
				return NotFound("Fixer profile not found.");
			}

			return Ok(result);
		}

		/// <summary>
		/// Creates a new client profile.
		/// </summary>
		/// <param name="clientDto">The client profile details.</param>
		/// <returns>An IActionResult indicating the result of the profile creation process.</returns>
		[HttpPost("client")]
		public async Task<IActionResult> CreateClientProfile([FromBody] ClientDto clientDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var result = await _profileService.CreateClientProfileAsync(clientDto);
			return Ok(result);
		}

		/// <summary>
		/// Updates an existing client profile.
		/// </summary>
		/// <param name="clientDto">The updated client profile details.</param>
		/// <returns>An IActionResult indicating the result of the profile update process.</returns>
		[HttpPut("client")]
		public async Task<IActionResult> UpdateClientProfile([FromBody] ClientDto clientDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var result = await _profileService.UpdateClientProfileAsync(clientDto);
			return Ok(result);
		}

		/// <summary>
		/// Gets the details of a client profile.
		/// </summary>
		/// <param name="id">The ID of the client.</param>
		/// <returns>An IActionResult containing the client profile details.</returns>
		[HttpGet("client/{id}")]
		public async Task<IActionResult> GetClientProfile(string id)
		{
			var result = await _profileService.GetClientProfileAsync(id);
			if (result == null)
			{
				return NotFound();
			}

			return Ok(result);
		}
	}
}
