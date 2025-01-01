// File: Models/FixerRating.cs
using System;

namespace QuickProFixer.Models
{
	public class FixerRating
	{
		public int Id { get; set; }
		public required string ClientId { get; set; }
		public required Client Client { get; set; }
		public required string FixerId { get; set; }
		public required Fixer Fixer { get; set; }
		public int Rating { get; set; } // 1-5 stars
		public string? Review { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	}
}