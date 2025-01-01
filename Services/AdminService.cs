using QuickProFixer.DTOs;
using QuickProFixer.Data;
using QuickProFixer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickProFixer.Services
{
	public class AdminService : IAdminService
	{
		private readonly ApplicationDbContext _context;

		public AdminService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<List<ProfileDto>> GetProfilesForReviewAsync()
		{
			var fixerProfiles = await _context.Fixers
				.Where(f => !f.IsVerified)
				.Select(f => new ProfileDto
				{
					Id = int.Parse(f.Id), // Ensure the returned DTO contains f.Id,
					FirstName = f.FirstName,
					LastName = f.LastName,
					Email = f.Email ?? string.Empty,
					PhoneNumber = f.PhoneNumber ?? string.Empty,
					Address = f.Address,
					IsFixer = true
				})
				.ToListAsync();

			var clientProfiles = await _context.Clients
				.Where(c => !c.IsVerified)
				.Select(c => new ProfileDto
				{
					Id = int.Parse(c.Id), // Ensure the returned DTO contains c.Id,
					FirstName = c.FirstName,
					LastName = c.LastName,
					Email = c.Email ?? string.Empty,
					PhoneNumber = c.PhoneNumber ?? string.Empty,
					Address = c.Address,
					IsFixer = false
				})
				.ToListAsync();

			return fixerProfiles.Concat(clientProfiles).ToList();
		}

		public async Task<bool> ApproveProfileAsync(int profileId, bool isFixer)
		{
			if (isFixer)
			{
				var fixer = await _context.Fixers.FindAsync(profileId);
				if (fixer != null)
				{
					fixer.IsVerified = true;
					_context.Fixers.Update(fixer);
					await _context.SaveChangesAsync();
					return true;
				}
			}
			else
			{
				var client = await _context.Clients.FindAsync(profileId);
				if (client != null)
				{
					client.IsVerified = true;
					_context.Clients.Update(client);
					await _context.SaveChangesAsync();
					return true;
				}
			}

			return false;
		}
	}
}
