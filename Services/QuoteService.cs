using Microsoft.EntityFrameworkCore;
using QuickProFixer.Data;
using QuickProFixer.DTOs;
using QuickProFixer.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using QuickProFixer.Hubs;
using System.Linq;
using System.Threading.Tasks;

namespace QuickProFixer.Services
{
	public class QuoteService : IQuoteService
	{
		private readonly ApplicationDbContext _context;
		private readonly IHubContext<NotificationHub> _hubContext;
		private readonly IEmailService _emailService;

		public QuoteService(ApplicationDbContext context, IHubContext<NotificationHub> hubContext, IEmailService emailService)
		{
			_context = context;
			_hubContext = hubContext;
			_emailService = emailService;
		}

		public async Task<QuoteDto?> CreateQuoteAsync(QuoteDto quoteDto)
		{
			var fixRequest = await _context.FixRequests.FindAsync(quoteDto.FixRequestId);
			if (fixRequest == null || fixRequest.Status != "Accepted")
			{
				return null; // Only create quotes for accepted requests
			}

			var fixer = await _context.Fixers.FindAsync(quoteDto.FixerId);
			var client = await _context.Clients.FindAsync(quoteDto.ClientId);

			if (fixer == null || client == null)
			{
				return null; // Ensure fixer and client exist
			}


			var quote = new Quote
			{
				FixRequestId = quoteDto.FixRequestId,
				FixerId = quoteDto.FixerId,
				Fixer = fixer,
				Client = client,
				FixRequest = fixRequest,
				ClientId = quoteDto.ClientId,
				Description = quoteDto.Description,
				Amount = quoteDto.Amount,
			};

			_context.Quotes.Add(quote);
			await _context.SaveChangesAsync();

			quoteDto.Id = quote.Id;
			quoteDto.CreatedAt = quote.CreatedAt;

			// Send real-time notification
			await _hubContext.Clients.User(quoteDto.ClientId).SendAsync("ReceiveNotification", "You have received a new quote.");

			// Send email notification
			await _emailService.SendEmailAsync(quoteDto.ClientId, "New Quote Received", "You have received a new quote.");


			return quoteDto;
		}

		public async Task<IEnumerable<QuoteDto>> GetAllQuotesForFixerAsync(string fixerId)
		{
			return await _context.Quotes
				.Where(q => q.FixerId == fixerId)
				.Select(q => new QuoteDto
				{
					Id = q.Id,
					FixRequestId = q.FixRequestId,
					FixerId = q.FixerId,
					ClientId = q.ClientId,
					Description = q.Description,
					Amount = q.Amount,
					CreatedAt = q.CreatedAt
				})
				.ToListAsync();
		}

		public async Task<QuoteDto?> GetQuoteByIdAsync(int id)
		{
			var quote = await _context.Quotes.FindAsync(id);
			if (quote == null)
			{
				return null;
			}

			return new QuoteDto
			{
				Id = quote.Id,
				FixRequestId = quote.FixRequestId,
				FixerId = quote.FixerId,
				ClientId = quote.ClientId,
				Description = quote.Description,
				Amount = quote.Amount,
				CreatedAt = quote.CreatedAt
			};
		}
	}
}
