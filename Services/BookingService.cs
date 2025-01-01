// File: Services/BookingService.cs
using Microsoft.AspNetCore.SignalR;
using QuickProFixer.Data;
using QuickProFixer.DTOs;
using QuickProFixer.Hubs;
using QuickProFixer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace QuickProFixer.Services
{
	/// <summary>
	/// Service for managing bookings.
	/// </summary>
	public class BookingService : IBookingService
	{
		private readonly ApplicationDbContext _context;
		private readonly IHubContext<NotificationHub> _hubContext;
		private readonly IEmailService _emailService;

		/// <summary>
		/// Initializes a new instance of the <see cref="BookingService"/> class.
		/// </summary>
		/// <param name="context">The application database context.</param>
		/// <param name="hubContext">The SignalR hub context.</param>
		/// <param name="emailService">The email service.</param>
		public BookingService(ApplicationDbContext context, IHubContext<NotificationHub> hubContext, IEmailService emailService)
		{
			_context = context;
			_hubContext = hubContext;
			_emailService = emailService;
		}

		/// <summary>
		/// Creates a new booking.
		/// </summary>
		/// <param name="bookingDto">The booking data transfer object.</param>
		/// <returns>The created booking data transfer object.</returns>
		public async Task<BookingDto?> CreateBookingAsync(BookingDto bookingDto)
		{
			if (bookingDto.QuoteId == null || bookingDto.ClientId == null || bookingDto.FixerId == null)
			{
				return null; // Ensure required fields are not null
			}

			var quote = await _context.Quotes.FindAsync(bookingDto.QuoteId);
			if (quote == null)
			{
				return null; // Ensure quote exists
			}

			var client = await _context.Clients.FindAsync(bookingDto.ClientId);
			var fixer = await _context.Fixers.FindAsync(bookingDto.FixerId);

			if (client == null || fixer == null)
			{
				return null; // Ensure client and fixer exist
			}

			var booking = new Booking
			{
				ClientId = bookingDto.ClientId,
				Client = client,
				FixerId = bookingDto.FixerId,
				Fixer = fixer,
				QuoteId = bookingDto.QuoteId.Value,
				Quote = quote,
				BookingDate = bookingDto.BookingDate,
				Status = bookingDto.Status ?? "Pending",
			};

			_context.Bookings.Add(booking);
			await _context.SaveChangesAsync();

			bookingDto.Id = booking.Id;

			// Send real-time notification
			await _hubContext.Clients.User(bookingDto.ClientId).SendAsync("ReceiveNotification", "Your booking has been confirmed.");

			// Send email notification
			await _emailService.SendEmailAsync(bookingDto.ClientId, "Booking Confirmed", "Your booking has been confirmed.");

			return bookingDto;
		}

		/// <summary>
		/// Gets all bookings for a client.
		/// </summary>
		/// <param name="clientId">The client ID.</param>
		/// <returns>A list of booking data transfer objects.</returns>
		public async Task<IEnumerable<BookingDto>> GetBookingsForClientAsync(string clientId)
		{
			var bookings = await _context.Bookings
				.Where(b => b.ClientId == clientId)
				.Select(b => new BookingDto
				{
					Id = b.Id,
					ClientId = b.ClientId,
					FixerId = b.FixerId,
					QuoteId = b.QuoteId,
					BookingDate = b.BookingDate,
					Status = b.Status
				})
				.ToListAsync();

			return bookings;
		}

		/// <summary>
		/// Gets the details of a specific booking.
		/// </summary>
		/// <param name="id">The booking ID.</param>
		/// <returns>The booking data transfer object.</returns>
		public async Task<BookingDto?> GetBookingByIdAsync(int id)
		{
			var booking = await _context.Bookings
				.Where(b => b.Id == id)
				.Select(b => new BookingDto
				{
					Id = b.Id,
					ClientId = b.ClientId,
					FixerId = b.FixerId,
					QuoteId = b.QuoteId,
					BookingDate = b.BookingDate,
					Status = b.Status
				})
				.FirstOrDefaultAsync();

			return booking;
		}

		/// <summary>
		/// Gets the fixer by ID.
		/// </summary>
		/// <param name="fixerId">The fixer ID.</param>
		/// <returns>The fixer.</returns>
		public async Task<Fixer?> GetFixerByIdAsync(string fixerId)
		{
			return await _context.Fixers.FindAsync(fixerId);
		}
	}
}