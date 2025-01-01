// File: Controllers/BookingController.cs
using Microsoft.AspNetCore.Mvc;
using QuickProFixer.DTOs;
using QuickProFixer.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuickProFixer.Controllers
{
	/// <summary>
	/// Controller for managing bookings.
	/// </summary>
	[ApiController]
	[Route("api/[controller]")]
	public class BookingController : ControllerBase
	{
		private readonly IBookingService _bookingService;

		/// <summary>
		/// Initializes a new instance of the <see cref="BookingController"/> class.
		/// </summary>
		/// <param name="bookingService">The booking service.</param>
		public BookingController(IBookingService bookingService)
		{
			_bookingService = bookingService;
		}

		/// <summary>
		/// Creates a new booking.
		/// </summary>
		/// <param name="bookingDto">The booking data transfer object.</param>
		/// <returns>The created booking data transfer object.</returns>
		[HttpPost]
		public async Task<IActionResult> CreateBooking([FromBody] BookingDto bookingDto)
		{
			var result = await _bookingService.CreateBookingAsync(bookingDto);
			if (result == null)
			{
				return BadRequest("Invalid booking details.");
			}
			return Ok(result);
		}

		/// <summary>
		/// Gets all bookings for a client.
		/// </summary>
		/// <param name="clientId">The client ID.</param>
		/// <returns>A list of booking data transfer objects.</returns>
		[HttpGet]
		public async Task<IActionResult> GetBookingsForClient([FromQuery] string clientId)
		{
			var bookings = await _bookingService.GetBookingsForClientAsync(clientId);
			return Ok(bookings);
		}

		/// <summary>
		/// Gets the details of a specific booking.
		/// </summary>
		/// <param name="id">The booking ID.</param>
		/// <returns>The booking data transfer object.</returns>
		[HttpGet("{id}")]
		public async Task<IActionResult> GetBookingById(int id)
		{
			var booking = await _bookingService.GetBookingByIdAsync(id);
			if (booking == null)
			{
				return NotFound();
			}
			return Ok(booking);
		}

		/// <summary>
		/// Updates the status of a booking.
		/// </summary>
		/// <param name="id">The booking ID.</param>
		/// <param name="status">The new status.</param>
		/// <returns>An action result.</returns>
		[HttpPost("{id}/status")]
		public async Task<IActionResult> UpdateBookingStatus(int id, [FromQuery] string status)
		{
			var result = await _bookingService.UpdateBookingStatusAsync(id, status);
			if (!result)
			{
				return BadRequest("Unable to update booking status.");
			}
			return Ok("Booking status updated.");
		}


		/// <summary>
		/// Confirms the completion of a job.
		/// </summary>
		/// <param name="id">The booking ID.</param>
		/// <returns>An action result.</returns>
		[HttpPost("{id}/complete")]
		public async Task<IActionResult> ConfirmJobCompletion(int id)
		{
			var result = await _bookingService.ConfirmJobCompletionAsync(id);
			if (!result)
			{
				return BadRequest("Unable to confirm job completion.");
			}
			return Ok("Job completion confirmed.");
		}

		/// <summary>
		/// Sends booking notifications.
		/// </summary>
		/// <param name="bookingDto">The booking data transfer object.</param>
		/// <returns>An action result.</returns>
		[HttpPost("notifications/booking")]
		public async Task<IActionResult> SendBookingNotification([FromBody] BookingDto bookingDto)
		{
			// Implement notification logic here
			await Task.Run(() => { /* Simulate async work */ });
			return Ok();
		}
	}
}