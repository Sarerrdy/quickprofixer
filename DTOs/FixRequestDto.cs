using System;
using System.Collections.Generic;

namespace QuickProFixer.DTOs
{
	public class FixRequestDto
	{
		public int Id { get; set; }
		public required string JobDescription { get; set; }
		public required string RequiredSkills { get; set; }
		public required string Location { get; set; }
		public DateTime PreferredSchedule { get; set; }
		public required List<string> FixerIds { get; set; }
		public required string ClientId { get; set; }
		public required string Status { get; set; }
	}
}
