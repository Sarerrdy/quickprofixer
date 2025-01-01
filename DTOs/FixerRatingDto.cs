// File: DTOs/FixerRatingDto.cs
using System;

namespace QuickProFixer.DTOs
{
	public class FixerRatingDto
	{
		public int Id { get; set; }
		public string? ClientId { get; set; }
		public string? FixerId { get; set; }
		public int Rating { get; set; } // 1-5 stars
		public string? Review { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}