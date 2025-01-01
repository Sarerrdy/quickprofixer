// File: Services/RatingService.cs
using QuickProFixer.Data;
using QuickProFixer.DTOs;
using QuickProFixer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace QuickProFixer.Services
{
	public class RatingService : IRatingService
	{
		private readonly ApplicationDbContext _context;

		public RatingService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<FixerRatingDto?> SubmitFixerRatingAsync(FixerRatingDto fixerRatingDto)
		{
			var client = await _context.Clients.FindAsync(fixerRatingDto.ClientId);
			var fixer = await _context.Fixers.FindAsync(fixerRatingDto.FixerId);

			if (client == null || fixer == null)
			{
				return null; // Ensure client and fixer exist
			}

			var fixerRating = new FixerRating
			{
				ClientId = fixerRatingDto.ClientId!,
				Client = client,
				FixerId = fixerRatingDto.FixerId!,
				Fixer = fixer,
				Rating = fixerRatingDto.Rating,
				Review = fixerRatingDto.Review,
				CreatedAt = fixerRatingDto.CreatedAt
			};

			_context.FixerRatings.Add(fixerRating);
			await _context.SaveChangesAsync();

			fixerRatingDto.Id = fixerRating.Id;
			return fixerRatingDto;
		}

		public async Task<ClientRatingDto?> SubmitClientRatingAsync(ClientRatingDto clientRatingDto)
		{
			var client = await _context.Clients.FindAsync(clientRatingDto.ClientId);
			var fixer = await _context.Fixers.FindAsync(clientRatingDto.FixerId);

			if (client == null || fixer == null)
			{
				return null; // Ensure client and fixer exist
			}

			var clientRating = new ClientRating
			{
				FixerId = clientRatingDto.FixerId!,
				Fixer = fixer,
				ClientId = clientRatingDto.ClientId!,
				Client = client,
				Rating = clientRatingDto.Rating,
				Review = clientRatingDto.Review,
				CreatedAt = clientRatingDto.CreatedAt
			};

			_context.ClientRatings.Add(clientRating);
			await _context.SaveChangesAsync();

			clientRatingDto.Id = clientRating.Id;
			return clientRatingDto;
		}

		public async Task<IEnumerable<FixerRatingDto>> GetFixerRatingsAsync(string fixerId)
		{
			return await _context.FixerRatings
				.Where(r => r.FixerId == fixerId)
				.Select(r => new FixerRatingDto
				{
					Id = r.Id,
					ClientId = r.ClientId,
					FixerId = r.FixerId,
					Rating = r.Rating,
					Review = r.Review,
					CreatedAt = r.CreatedAt
				})
				.ToListAsync();
		}

		public async Task<IEnumerable<ClientRatingDto>> GetClientRatingsAsync(string clientId)
		{
			return await _context.ClientRatings
				.Where(r => r.ClientId == clientId)
				.Select(r => new ClientRatingDto
				{
					Id = r.Id,
					FixerId = r.FixerId,
					ClientId = r.ClientId,
					Rating = r.Rating,
					Review = r.Review,
					CreatedAt = r.CreatedAt
				})
				.ToListAsync();
		}
	}
}