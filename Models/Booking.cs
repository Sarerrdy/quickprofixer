
using System;

namespace QuickProFixer.Models
{
	public class Booking
	{
		public int Id { get; set; }
		public required string ClientId { get; set; }
		public required Client Client { get; set; }
		public required string FixerId { get; set; }
		public required Fixer Fixer { get; set; }
		public required int QuoteId { get; set; }
		public required Quote Quote { get; set; }
		public DateTime BookingDate { get; set; }
		public string Status { get; set; } = "Pending"; // Status tracking (e.g., "Pending", "In Progress", "Completed")
		public bool IsCompleted { get; set; } = false; // Job completion confirmations
	}
}