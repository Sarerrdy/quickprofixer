using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
		private readonly ILogger<FixerService> _logger;

		public FixerService(ApplicationDbContext context, ILogger<FixerService> logger)
		{
			_context = context;
			_logger = logger;
		}

		public async Task<IEnumerable<FixerDto>> GetAllFixersAsync()
		{
			_logger.LogInformation("Retrieving all fixers from the database");
			return await _context.Fixers
				.Select(f => new FixerDto
				{
					Id = f.Id,
					FirstName = f.FirstName,
					LastName = f.LastName,
					Email = f.Email ?? string.Empty,
					PhoneNumber = f.PhoneNumber ?? string.Empty,
					Specializations = f.Specializations,
					Certifications = f.Certifications,
					Location = f.Location,
					Rating = f.Rating,
					IsAvailable = f.IsAvailable,
					Reviews = f.Reviews,
					ExperienceYears = f.ExperienceYears,
					Portfolio = f.Portfolio,
					RateType = f.RateType,
					Rate = f.Rate
				})
				.ToListAsync();
		}

		public async Task<IEnumerable<FixerDto>> SearchFixersAsync(string skillCategory, string location, double minRating)
		{
			_logger.LogInformation("Searching fixers with skillCategory: {SkillCategory}, location: {Location}, minRating: {MinRating}", skillCategory, location, minRating);
			var fixers = await _context.Fixers
				.Where(f => f.Specializations == skillCategory && f.Location == location && f.Rating >= minRating)
				.Select(f => new FixerDto
				{
					Id = f.Id,
					FirstName = f.FirstName,
					LastName = f.LastName,
					MiddleName = f.MiddleName ?? string.Empty,
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

			if (!fixers.Any())
			{
				_logger.LogWarning("No fixers found for the given criteria");
			}

			return fixers;
		}

		public async Task<IEnumerable<FixerDto>> FilterFixersAsync(string skillType, double minPrice, double maxPrice, bool isAvailable, double maxDistance)
		{
			_logger.LogInformation("Filtering fixers with skillType: {SkillType}, minPrice: {MinPrice}, maxPrice: {MaxPrice}, isAvailable: {IsAvailable}, maxDistance: {MaxDistance}", skillType, minPrice, maxPrice, isAvailable, maxDistance);
			// Assuming there's a Price and Distance properties in Fixer model
			var fixers = await _context.Fixers
				.Where(f => f.Specializations == skillType && f.IsAvailable == isAvailable)
				.Select(f => new FixerDto
				{
					Id = f.Id,
					FirstName = f.FirstName,
					LastName = f.LastName,
					MiddleName = f.MiddleName ?? string.Empty,
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

			if (!fixers.Any())
			{
				_logger.LogWarning("No fixers found for the given criteria");
			}

			return fixers;
		}

		public async Task<FixerDto?> GetFixerDetailsAsync(int id)
		{
			_logger.LogInformation("Getting fixer details for ID: {Id}", id);
			var fixer = await _context.Fixers.FindAsync(id);
			if (fixer == null)
			{
				_logger.LogWarning("Fixer not found for ID: {Id}", id);
				return null;
			}

			return new FixerDto
			{
				Id = fixer.Id,
				FirstName = fixer.FirstName,
				LastName = fixer.LastName,
				MiddleName = fixer.MiddleName ?? string.Empty,
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