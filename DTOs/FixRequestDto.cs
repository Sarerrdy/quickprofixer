using System;
using System.Collections.Generic;
using QuickProFixer.Models;

namespace QuickProFixer.DTOs
{
	public class FixRequestDto
	{
		public int Id { get; set; }
		public required string JobDescription { get; set; }

		// public required string RequiredSkills { get; set; }

		/// <summary>
		/// Gets or sets the skill category of the fixer.
		/// </summary>
		public int SpecializationId { get; set; }
		public ServiceDto? Specialization { get; set; } = null!; // Navigation property

		/// <summary>
		/// Gets or sets the address ID of the Fixer.
		/// </summary>
		public int AddressId { get; set; }
		public AddressDto? Address { get; set; } = null!; // Navigation property

		public required string Location { get; set; }
		public DateTime PreferredSchedule { get; set; }
		public required List<string> FixerIds { get; set; }
		public required string ClientId { get; set; }
		public required string Status { get; set; }
		public SupportingFileDto? SupportingImage { get; set; } // Single supporting image
		public SupportingFileDto? SupportingDocument { get; set; } // Single supporting document
		public List<string> SupportingFiles { get; set; } = new List<string>(); // List of supporting file links
	}
}
