using QuickProFixer.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuickProFixer.Services
{
	/// <summary>
	/// Defines methods for managing services.
	/// </summary>
	public interface IServiceService
	{
		Task<IEnumerable<ServiceDto>> GetAllServicesAsync();
		Task<ServiceDto?> GetServiceByIdAsync(int id);
		Task<ServiceDto> CreateServiceAsync(ServiceDto serviceDto);
		Task<ServiceDto?> UpdateServiceAsync(ServiceDto serviceDto);
		Task<bool> DeleteServiceAsync(int id);
	}
}