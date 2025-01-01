namespace QuickProFixer.DTOs
{
	/// <summary>
	/// Data Transfer Object for quote items.
	/// </summary>
	public class QuoteItemDto
	{
		public int Id { get; set; }
		public int QuoteId { get; set; }
		public required string Name { get; set; }
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal Price => Quantity * UnitPrice;
	}
}