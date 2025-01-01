using Microsoft.EntityFrameworkCore;
using QuickProFixer.Data;
using QuickProFixer.DTOs;
using QuickProFixer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickProFixer.Services
{
	public class FixRequestService : IFixRequestService
	{
		private readonly ApplicationDbContext _context;

		public FixRequestService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<FixRequestDto> CreateFixRequestAsync(FixRequestDto fixRequestDto)
		{
			var fixRequest = new FixRequest
			{
				JobDescription = fixRequestDto.JobDescription,
				RequiredSkills = fixRequestDto.RequiredSkills,
				Location = fixRequestDto.Location,
				PreferredSchedule = fixRequestDto.PreferredSchedule,
				FixerIds = fixRequestDto.FixerIds,
				ClientId = fixRequestDto.ClientId,
				Status = "Pending" // Initial status
			};

			_context.FixRequests.Add(fixRequest);
			await _context.SaveChangesAsync();

			// Send notifications to selected fixers (Email and SMS logic here)

			return fixRequestDto;
		}

		public async Task<IEnumerable<FixRequestDto>> GetAllFixRequestsForClientAsync(string clientId)
		{
			return await _context.FixRequests
				.Where(fr => fr.ClientId == clientId)
				.Select(fr => new FixRequestDto
				{
					Id = fr.Id,
					JobDescription = fr.JobDescription,
					RequiredSkills = fr.RequiredSkills,
					Location = fr.Location,
					PreferredSchedule = fr.PreferredSchedule,
					FixerIds = fr.FixerIds,
					ClientId = fr.ClientId,
					Status = fr.Status
				})
				.ToListAsync();
		}

		public async Task<FixRequestDto?> GetFixRequestByIdAsync(int id)
		{
			var fixRequest = await _context.FixRequests.FindAsync(id);
			if (fixRequest == null)
			{
				return null;
			}

			return new FixRequestDto
			{
				Id = fixRequest.Id,
				JobDescription = fixRequest.JobDescription,
				RequiredSkills = fixRequest.RequiredSkills,
				Location = fixRequest.Location,
				PreferredSchedule = fixRequest.PreferredSchedule,
				FixerIds = fixRequest.FixerIds,
				ClientId = fixRequest.ClientId,
				Status = fixRequest.Status
			};
		}


		public async Task<bool> AcceptFixRequestAsync(int requestId, string fixerId)
		{
			var fixRequest = await _context.FixRequests.FindAsync(requestId);
			if (fixRequest == null || !fixRequest.FixerIds.Contains(fixerId))
			{
				return false;
			}

			fixRequest.Status = "Accepted";
			_context.FixRequests.Update(fixRequest);
			await _context.SaveChangesAsync();
			return true;
		}

		public async Task<bool> RejectFixRequestAsync(int requestId, string fixerId)
		{
			var fixRequest = await _context.FixRequests.FindAsync(requestId);
			if (fixRequest == null || !fixRequest.FixerIds.Contains(fixerId))
			{
				return false;
			}

			fixRequest.Status = "Rejected";
			_context.FixRequests.Update(fixRequest);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
