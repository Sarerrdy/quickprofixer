using System.Threading.Tasks;

namespace QuickProFixer.Services
{
	public interface IDashboardService
	{
		Task<object> GetClientRequestsDashboardAsync(string clientId);
		Task<object> GetClientBookingsDashboardAsync(string clientId);
		Task<object> GetFixerRequestsDashboardAsync(string fixerId);
	}
}