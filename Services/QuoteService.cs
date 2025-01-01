using Microsoft.EntityFrameworkCore;
using QuickProFixer.Data;
using QuickProFixer.DTOs;
using QuickProFixer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickProFixer.Services
{
	public class QuoteService : IQuoteService
	{
		private readonly ApplicationDbContext _context;

		public QuoteService(ApplicationDbContext context)
		{
			_context = context;
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
				FixRequest = fixRequest, // Initialize required member
				FixerId = quoteDto.FixerId,
				Fixer = fixer, // Initialize required member
				ClientId = quoteDto.ClientId,
				Client = client, // Initialize required member
				Description = quoteDto.Description,
				Amount = quoteDto.Amount,
				CreatedAt = quoteDto.CreatedAt,
				SupportingImage = quoteDto.SupportingImage != null ? new SupportingFile
				{
					FileName = quoteDto.SupportingImage.FileName,
					FileType = quoteDto.SupportingImage.FileType,
					FileUrl = quoteDto.SupportingImage.FileUrl
				} : null,
				SupportingDocument = quoteDto.SupportingDocument != null ? new SupportingFile
				{
					FileName = quoteDto.SupportingDocument.FileName,
					FileType = quoteDto.SupportingDocument.FileType,
					FileUrl = quoteDto.SupportingDocument.FileUrl
				} : null,
				SupportingFiles = quoteDto.SupportingFiles
			};

			// Initialize QuoteItem objects after the quote object is created
			quote.Items = quoteDto.Items.Select(i => new QuoteItem
			{
				Name = i.Name,
				Quantity = i.Quantity,
				UnitPrice = i.UnitPrice,
				Quote = quote // Initialize required member
			}).ToList();

			_context.Quotes.Add(quote);
			await _context.SaveChangesAsync();

			quoteDto.Id = quote.Id;
			return quoteDto;
		}

		public async Task<IEnumerable<QuoteDto>> GetAllQuotesForFixerAsync(string fixerId)
		{
			return await _context.Quotes
				.Where(q => q.FixerId == fixerId)
				.Include(q => q.Items) // Include quote items
				.Select(q => new QuoteDto
				{
					Id = q.Id,
					FixRequestId = q.FixRequestId,
					FixerId = q.FixerId,
					ClientId = q.ClientId,
					Description = q.Description,
					Amount = q.Amount,
					CreatedAt = q.CreatedAt,
					Items = q.Items.Select(i => new QuoteItemDto
					{
						Id = i.Id,
						QuoteId = i.QuoteId,
						Name = i.Name,
						Quantity = i.Quantity,
						UnitPrice = i.UnitPrice
					}).ToList(),
					SupportingImage = q.SupportingImage != null ? new SupportingFileDto
					{
						Id = q.SupportingImage.Id,
						FileName = q.SupportingImage.FileName,
						FileType = q.SupportingImage.FileType,
						FileUrl = q.SupportingImage.FileUrl
					} : null,
					SupportingDocument = q.SupportingDocument != null ? new SupportingFileDto
					{
						Id = q.SupportingDocument.Id,
						FileName = q.SupportingDocument.FileName,
						FileType = q.SupportingDocument.FileType,
						FileUrl = q.SupportingDocument.FileUrl
					} : null,
					SupportingFiles = q.SupportingFiles
				})
				.ToListAsync();
		}

		public async Task<QuoteDto?> GetQuoteByIdAsync(int id)
		{
			var quote = await _context.Quotes
				.Include(q => q.Items) // Include quote items
				.FirstOrDefaultAsync(q => q.Id == id);

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
				CreatedAt = quote.CreatedAt,
				Items = quote.Items.Select(i => new QuoteItemDto
				{
					Id = i.Id,
					QuoteId = i.QuoteId,
					Name = i.Name,
					Quantity = i.Quantity,
					UnitPrice = i.UnitPrice
				}).ToList(),
				SupportingImage = quote.SupportingImage != null ? new SupportingFileDto
				{
					Id = quote.SupportingImage.Id,
					FileName = quote.SupportingImage.FileName,
					FileType = quote.SupportingImage.FileType,
					FileUrl = quote.SupportingImage.FileUrl
				} : null,
				SupportingDocument = quote.SupportingDocument != null ? new SupportingFileDto
				{
					Id = quote.SupportingDocument.Id,
					FileName = quote.SupportingDocument.FileName,
					FileType = quote.SupportingDocument.FileType,
					FileUrl = quote.SupportingDocument.FileUrl
				} : null,
				SupportingFiles = quote.SupportingFiles
			};
		}
	}
}