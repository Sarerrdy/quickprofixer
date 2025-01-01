// File: DTOs/PaymentDto.cs
using System;

namespace QuickProFixer.DTOs
{
	public class PaymentDto
	{
		public int Id { get; set; }
		public string? ClientId { get; set; }
		public string? FixerId { get; set; }
		public int BookingId { get; set; }
		public decimal Amount { get; set; }
		public string ClientPaymentStatus { get; set; } = "Pending"; // Pending, Completed
		public string FixerPaymentStatus { get; set; } = "Pending"; // Pending, Completed
		public DateTime CreatedAt { get; set; }
	}
}