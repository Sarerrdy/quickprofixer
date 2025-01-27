namespace QuickProFixer.DTOs
{
	/// <summary>
	/// Data Transfer Object for Address.
	/// </summary>
	public class AddressDto
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