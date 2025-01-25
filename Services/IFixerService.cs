using QuickProFixer.DTOs;


namespace QuickProFixer.Services
{
	public interface IFixerService
	{
		Task<IEnumerable<FixerDto>> GetAllFixersAsync();
		Task<IEnumerable<FixerDto>> SearchFixersAsync(string skillCategory, string location, double minRating);
		Task<IEnumerable<FixerDto>> FilterFixersAsync(string skillType, double minPrice, double maxPrice, bool isAvailable, double maxDistance);
		Task<FixerDto?> GetFixerDetailsAsync(int id);
	}
}
