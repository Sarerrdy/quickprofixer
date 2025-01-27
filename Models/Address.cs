namespace QuickProFixer.Models
{
	/// <summary>
	/// Represents an address in the QuickProFixer system.
	/// </summary>
	public class Address
	{
		public int Id { get; set; }
		public required string AddressLine { get; set; }
		public string? Landmark { get; set; }
		public required string Town { get; set; }
		public required string LGA { get; set; }
		public required string State { get; set; }
		public string? ZipCode { get; set; }
		public required string Country { get; set; }
	}
}