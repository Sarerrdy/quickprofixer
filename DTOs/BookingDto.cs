// File: DTOs/BookingDto.cs
using System;

namespace QuickProFixer.DTOs
{
	/// <summary>
	/// Data Transfer Object for bookings.
	/// </summary>
	public class BookingDto
	{
		/// <summary>
		/// Gets or sets the booking ID.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the client ID.
		/// </summary>
		public string? ClientId { get; set; }

		/// <summary>
		/// Gets or sets the fixer ID.
		/// </summary>
		public string? FixerId { get; set; }

		/// <summary>
		/// Gets or sets the quote ID.
		/// </summary>
		public int? QuoteId { get; set; }

		/// <summary>
		/// Gets or sets the booking date.
		/// </summary>
		public DateTime BookingDate { get; set; }

		/// <summary>
		/// Gets or sets the booking status.
		/// </summary>
		public string? Status { get; set; }
	}
}