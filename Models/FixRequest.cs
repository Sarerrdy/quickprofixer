using System;
using System.Collections.Generic;

namespace QuickProFixer.Models
{
    public class FixRequest
    {
        public int Id { get; set; }
        public required string JobDescription { get; set; }
        public required string RequiredSkills { get; set; }
        public required string Location { get; set; }
        public DateTime PreferredSchedule { get; set; }
        public required List<string> FixerIds { get; set; } // List of Fixer IDs
        public required string ClientId { get; set; }
        public Fixer? Fixer { get; set; }
        public required string Status { get; set; } // Status tracking (e.g., "Pending", "Accepted", "Rejected")
    }
}
