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
	}
}