namespace QuickProFixer.DTOs
{
	/// <summary>
	/// Data Transfer Object for quotes.
	/// </summary>
	public class QuoteDto
	{
		public int Id { get; set; }
		public int FixRequestId { get; set; }
		public required string FixerId { get; set; }
		public required string ClientId { get; set; }
		public required string Description { get; set; }
		public decimal Amount { get; set; }
		public DateTime CreatedAt { get; set; }
		public List<QuoteItemDto> Items { get; set; } = new List<QuoteItemDto>();
		public SupportingFileDto? SupportingImage { get; set; } // Single supporting image
		public SupportingFileDto? SupportingDocument { get; set; } // Single supporting document
		public List<string> SupportingFiles { get; set; } = new List<string>(); // List of supporting file links
	}
}