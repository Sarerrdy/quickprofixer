namespace QuickProFixer.DTOs
{
	public class ProfileDto
	{
		public int Id { get; set; }
		public required string FirstName { get; set; }
		public required string LastName { get; set; }
		public required string Email { get; set; }
		public required string PhoneNumber { get; set; }
		public required string Address { get; set; }
		public bool IsFixer { get; set; }
	}
}
