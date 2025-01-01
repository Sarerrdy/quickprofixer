// File: Models/Invoice.cs
using System;

namespace QuickProFixer.Models
{
	public class Invoice
	{
		public int Id { get; set; }
		public required string ClientId { get; set; }
		public required Client Client { get; set; }
		public required string FixerId { get; set; }
		public required Fixer Fixer { get; set; }
		public required int BookingId { get; set; }
		public required Booking Booking { get; set; }
		public decimal Amount { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public string InvoiceNumber { get; set; } = Guid.NewGuid().ToString();
	}
}