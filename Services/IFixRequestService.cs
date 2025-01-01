using QuickProFixer.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuickProFixer.Services
{
	public interface IFixRequestService
	{
		Task<FixRequestDto> CreateFixRequestAsync(FixRequestDto fixRequestDto);
		Task<IEnumerable<FixRequestDto>> GetAllFixRequestsForClientAsync(string clientId);
		Task<FixRequestDto?> GetFixRequestByIdAsync(int id);
		Task<bool> AcceptFixRequestAsync(int requestId, string fixerId);
		Task<bool> RejectFixRequestAsync(int requestId, string fixerId);
	}
}
