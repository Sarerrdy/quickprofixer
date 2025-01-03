using Microsoft.EntityFrameworkCore;
using QuickProFixer.Data;
using QuickProFixer.DTOs;
using QuickProFixer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickProFixer.Services
{
	public class FixerService : IFixerService
	{
		private readonly ApplicationDbContext _context;

		public FixerService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<FixerDto>> SearchFixersAsync(string skillCategory, string location, double minRating)
		{
			return await _context.Fixers
				.Where(f => f.Specializations == skillCategory && f.Location == location && f.Rating >= minRating)
				.Select(f => new FixerDto
				{
					Id = int.Parse(f.Id),
					FirstName = f.FirstName,
					LastName = f.LastName,
					PhoneNumber = f.PhoneNumber ?? string.Empty,
					Email = f.Email ?? string.Empty,
					Specializations = f.Specializations,
					Certifications = f.Certifications,
					Rating = f.Rating,
					Location = f.Location,
					IsAvailable = f.IsAvailable,
					Address = f.Address,
					VerificationDocument = f.VerificationDocument,
					IsVerified = f.IsVerified,
					Reviews = f.Reviews,
					ExperienceYears = f.ExperienceYears,
					Portfolio = f.Portfolio,
					RateType = f.RateType,
					Rate = f.Rate
				})
				.ToListAsync();
		}

		public async Task<IEnumerable<FixerDto>> FilterFixersAsync(string skillType, double minPrice, double maxPrice, bool isAvailable, double maxDistance)
		{
			// Assuming there's a Price and Distance properties in Fixer model
			return await _context.Fixers
				.Where(f => f.Specializations == skillType && f.IsAvailable == isAvailable)
				.Select(f => new FixerDto
				{
					Id = int.Parse(f.Id),
					FirstName = f.FirstName,
					LastName = f.LastName,
					PhoneNumber = f.PhoneNumber ?? string.Empty,
					Email = f.Email ?? string.Empty,
					Specializations = f.Specializations,
					Certifications = f.Certifications,
					Rating = f.Rating,
					Location = f.Location,
					IsAvailable = f.IsAvailable,
					Address = f.Address,
					VerificationDocument = f.VerificationDocument,
					IsVerified = f.IsVerified,
					Reviews = f.Reviews,
					ExperienceYears = f.ExperienceYears,
					Portfolio = f.Portfolio,
					RateType = f.RateType,
					Rate = f.Rate
				})
				.ToListAsync();
		}

		public async Task<FixerDto?> GetFixerDetailsAsync(int id)
		{
			var fixer = await _context.Fixers.FindAsync(id);
			if (fixer == null)
			{
				return null;
			}

			return new FixerDto
			{
				Id = int.Parse(fixer.Id),
				FirstName = fixer.FirstName,
				LastName = fixer.LastName,
				PhoneNumber = fixer.PhoneNumber ?? string.Empty,
				Email = fixer.Email ?? string.Empty,
				Specializations = fixer.Specializations,
				Certifications = fixer.Certifications,
				Rating = fixer.Rating,
				Location = fixer.Location,
				IsAvailable = fixer.IsAvailable,
				Address = fixer.Address,
				VerificationDocument = fixer.VerificationDocument,
				IsVerified = fixer.IsVerified,
				Reviews = fixer.Reviews,
				ExperienceYears = fixer.ExperienceYears,
				Portfolio = fixer.Portfolio,
				RateType = fixer.RateType,
				Rate = fixer.Rate
			};
		}
	}
}
