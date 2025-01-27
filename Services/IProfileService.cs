using QuickProFixer.DTOs;
using System.Threading.Tasks;

namespace QuickProFixer.Services
{
	public interface IProfileService
	{
		Task<FixerDto> CreateFixerProfileAsync(FixerDto fixerDto);
		Task<FixerDto?> UpdateFixerProfileAsync(FixerDto fixerDto);
		Task<FixerDto?> GetFixerProfileAsync(string id);

		Task<ClientDto> CreateClientProfileAsync(ClientDto clientDto);
		Task<ClientDto?> UpdateClientProfileAsync(ClientDto clientDto);
		Task<ClientDto?> GetClientProfileAsync(string id);
	}
}
