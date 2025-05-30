using System;
using System.Collections.Generic;

namespace QuickProFixer.Models
{
    public class FixRequest
    {
        public int Id { get; set; }
        public required string JobDescription { get; set; }
        // public required string RequiredSkills { get; set; }

        /// <summary>
		/// Gets or sets the skill category of the fixer.
		/// </summary>
		public int SpecializationId { get; set; }
        public Service Specialization { get; set; } = null!; // Navigation property

        /// <summary>
        /// Gets or sets the address ID of the fixer.
        /// </summary>
        public int AddressId { get; set; }
        public Address Address { get; set; } = null!; // Navigation property

        public required string Location { get; set; }
        // public required string Address { get; set; }
        public DateTime PreferredSchedule { get; set; }
        public required List<string> FixerIds { get; set; } // List of Fixer IDs
        public required string ClientId { get; set; }
        public Fixer? Fixer { get; set; }
        public required string Status { get; set; } // Status tracking (e.g., "Pending", "Accepted", "Rejected")
        public SupportingFile? SupportingImage { get; set; } // Single supporting image
        public SupportingFile? SupportingDocument { get; set; } // Single supporting document
        public List<string> SupportingFiles { get; set; } = new List<string>(); // List of supporting file links
    }
}
