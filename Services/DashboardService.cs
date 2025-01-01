using QuickProFixer.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace QuickProFixer.Services
{
	public class DashboardService : IDashboardService
	{
		private readonly ApplicationDbContext _context;

		public DashboardService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<object> GetClientRequestsDashboardAsync(string clientId)
		{
			var requests = await _context.FixRequests
				.Where(r => r.ClientId == clientId)
				.ToListAsync();
			var quotes = await _context.Quotes
				.Where(q => q.ClientId == clientId)
				.ToListAsync();
			return new { Requests = requests, Quotes = quotes };
		}

		public async Task<object> GetClientBookingsDashboardAsync(string clientId)
		{
			var bookings = await _context.Bookings
				.Where(b => b.ClientId == clientId)
				.ToListAsync();
			return new { Bookings = bookings };
		}

		public async Task<object> GetFixerRequestsDashboardAsync(string fixerId)
		{
			var requests = await _context.FixRequests
				.Where(r => r.FixerIds.Contains(fixerId))
				.ToListAsync();
			var quotes = await _context.Quotes
				.Where(q => q.FixerId == fixerId)
				.ToListAsync();
			var bookings = await _context.Bookings
				.Where(b => b.FixerId == fixerId)
				.Include(b => b.Quote) // Include the Quote to access the Amount
				.ToListAsync();
			var earnings = bookings.Sum(b => b.Quote.Amount);
			var ratings = await _context.FixerRatings
				.Where(r => r.FixerId == fixerId)
				.ToListAsync();
			return new { Requests = requests, Quotes = quotes, Bookings = bookings, Earnings = earnings, Ratings = ratings };
		}
	}
}