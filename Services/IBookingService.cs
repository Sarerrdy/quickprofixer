using QuickProFixer.DTOs;
using QuickProFixer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuickProFixer.Services
{
	/// <summary>
	/// Defines methods for managing bookings.
	/// </summary>
	public interface IBookingService
	{
		/// <summary>
		/// Creates a new booking.
		/// </summary>
		/// <param name="bookingDto">The booking data transfer object.</param>
		/// <returns>The created booking data transfer object.</returns>
		Task<BookingDto?> CreateBookingAsync(BookingDto bookingDto);

		/// <summary>
		/// Gets all bookings for a client.
		/// </summary>
		/// <param name="clientId">The client ID.</param>
		/// <returns>A list of booking data transfer objects.</returns>
		Task<IEnumerable<BookingDto>> GetBookingsForClientAsync(string clientId);

		/// <summary>
		/// Gets the details of a specific booking.
		/// </summary>
		/// <param name="id">The booking ID.</param>
		/// <returns>The booking data transfer object.</returns>
		Task<BookingDto?> GetBookingByIdAsync(int id);

		/// <summary>
		/// Gets the fixer by ID.
		/// </summary>
		/// <param name="fixerId">The fixer ID.</param>
		/// <returns>The fixer.</returns>
		Task<Fixer?> GetFixerByIdAsync(string fixerId);

		/// <summary>
		/// Updates the status of a booking.
		/// </summary>
		/// <param name="bookingId">The booking ID.</param>
		/// <param name="status">The new status.</param>
		/// <returns>A boolean indicating whether the update was successful.</returns>
		Task<bool> UpdateBookingStatusAsync(int bookingId, string status);

		/// <summary>
		/// Confirms the completion of a job.
		/// </summary>
		/// <param name="bookingId">The booking ID.</param>
		/// <returns>A boolean indicating whether the confirmation was successful.</returns>
		Task<bool> ConfirmJobCompletionAsync(int bookingId);
	}
}