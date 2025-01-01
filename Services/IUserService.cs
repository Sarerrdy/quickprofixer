using QuickProFixer.Models;
using System.Threading.Tasks;

namespace QuickProFixer.Services
{
	public interface IUserService
	{
		Task<ApplicationUser?> GetUserByIdAsync(string userId);
	}
}
