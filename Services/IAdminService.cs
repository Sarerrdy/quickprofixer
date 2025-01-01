using QuickProFixer.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuickProFixer.Services
{
	/// <summary>
	/// Defines methods for admin-related operations.
	/// </summary>
	public interface IAdminService
	{
		/// <summary>
		/// Gets the list of profiles pending review and approval by the admin.
		/// </summary>
		/// <returns>A list of profiles pending review and approval.</returns>
		Task<List<ProfileDto>> GetProfilesForReviewAsync();

		/// <summary>
		/// Approves a profile.
		/// </summary>
		/// <param name="profileId">The ID of the profile to approve.</param>
		/// <param name="isFixer">A flag indicating if the profile is a Fixer.</param>
		/// <returns>A boolean indicating whether the approval was successful.</returns>
		Task<bool> ApproveProfileAsync(int profileId, bool isFixer);

		/// <summary>
		/// Gets platform analytics for the admin dashboard.
		/// </summary>
		/// <returns>The platform analytics data.</returns>
		Task<AdminAnalyticsDto> GetPlatformAnalyticsAsync();
	}
}