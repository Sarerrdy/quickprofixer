namespace QuickProFixer.Models
{
	/// <summary>
	/// Represents an item in a quote.
	/// </summary>
	public class QuoteItem
	{
		public int Id { get; set; }
		public int QuoteId { get; set; }
		public required Quote Quote { get; set; }
		public required string Name { get; set; }
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal Price => Quantity * UnitPrice;
	}
}