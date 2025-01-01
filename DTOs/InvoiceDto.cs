// File: DTOs/InvoiceDto.cs
using System;

namespace QuickProFixer.DTOs
{
	public class InvoiceDto
	{
		public int Id { get; set; }
		public string? ClientId { get; set; }
		public string? FixerId { get; set; }
		public int BookingId { get; set; }
		public decimal Amount { get; set; }
		public DateTime CreatedAt { get; set; }
		public required string InvoiceNumber { get; set; }
	}
}