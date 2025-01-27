using QuickProFixer.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuickProFixer.Services
{
	/// <summary>
	/// Defines methods for managing addresses.
	/// </summary>
	public interface IAddressService
	{
		Task<IEnumerable<AddressDto>> GetAllAddressesAsync();
		Task<AddressDto?> GetAddressByIdAsync(int id);
		Task<AddressDto> CreateAddressAsync(AddressDto addressDto);
		Task<AddressDto?> UpdateAddressAsync(AddressDto addressDto);
		Task<bool> DeleteAddressAsync(int id);
	}
}