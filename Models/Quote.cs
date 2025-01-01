using System;

namespace QuickProFixer.Models
{
	/// <summary>
	/// Represents a quote for a fix request.
	/// </summary>
	public class Quote
	{
		public int Id { get; set; }
		public int FixRequestId { get; set; }
		public required FixRequest FixRequest { get; set; }
		public required string FixerId { get; set; }
		public required Fixer Fixer { get; set; }
		public required string ClientId { get; set; }
		public required Client Client { get; set; }
		public required string Description { get; set; }
		public decimal Amount { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	}
}