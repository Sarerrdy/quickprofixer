using QuickProFixer.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuickProFixer.Services
{
	public interface IAdminService
	{
		Task<List<ProfileDto>> GetProfilesForReviewAsync();
		Task<bool> ApproveProfileAsync(int profileId, bool isFixer);
	}
}
