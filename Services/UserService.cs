using Microsoft.AspNetCore.Identity;
using QuickProFixer.Models;
using System.Threading.Tasks;

namespace QuickProFixer.Services
{
	public class UserService : IUserService
	{
		private readonly UserManager<ApplicationUser> _userManager;

		public UserService(UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<ApplicationUser?> GetUserByIdAsync(string userId)
		{
			return await _userManager.FindByIdAsync(userId);
		}
	}
}
