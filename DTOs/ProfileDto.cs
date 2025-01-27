namespace QuickProFixer.DTOs
{
	public class ProfileDto
	{
		public int Id { get; set; }
		public required string FirstName { get; set; }
		public required string LastName { get; set; }
		public required string Email { get; set; }
		public required string PhoneNumber { get; set; }
		public int AddressId { get; set; }
		public AddressDto Address { get; set; } = null!; // Navigation property
		public bool IsFixer { get; set; }
	}
}
