using System;
using System.Collections.Generic;

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
        public List<QuoteItem> Items { get; set; } = new List<QuoteItem>(); // List of quote items
        public SupportingFile? SupportingImage { get; set; } // Single supporting image
        public SupportingFile? SupportingDocument { get; set; } // Single supporting document
        public List<string> SupportingFiles { get; set; } = new List<string>(); // List of supporting file links
    }
}