using Microsoft.AspNetCore.Mvc;
using QuickProFixer.DTOs;
using QuickProFixer.Services;
using System.Threading.Tasks;

namespace QuickProFixer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdminController : ControllerBase
	{
		private readonly IAdminService _adminService;

		public AdminController(IAdminService adminService)
		{
			_adminService = adminService;
		}

		/// <summary>
		/// Gets the list of profiles pending review and approval by the admin.
		/// </summary>
		/// <returns>An IActionResult containing the list of profiles pending review and approval.</returns>
		[HttpGet("review/profiles")]
		public async Task<IActionResult> ReviewProfiles()
		{
			var profiles = await _adminService.GetProfilesForReviewAsync();
			return Ok(profiles);
		}

		/// <summary>
		/// Approves a profile.
		/// </summary>
		/// <param name="profileId">The ID of the profile to approve.</param>
		/// <param name="isFixer">A flag indicating if the profile is a Fixer.</param>
		/// <returns>An IActionResult indicating the result of the approval process.</returns>
		[HttpPost("approve/profile")]
		public async Task<IActionResult> ApproveProfile(int profileId, bool isFixer)
		{
			var result = await _adminService.ApproveProfileAsync(profileId, isFixer);
			if (result)
			{
				return Ok(new ApprovalResponseDto { Message = "Profile approved successfully." });
			}

			return BadRequest(new ApprovalResponseDto { Message = "Failed to approve profile." });
		}

	}
}
