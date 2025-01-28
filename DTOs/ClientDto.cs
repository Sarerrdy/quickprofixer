namespace QuickProFixer.DTOs
{
	/// <summary>
	/// Data Transfer Object for client registration.
	/// </summary>
	public class ClientDto
	{
		/// <summary> 
		/// Gets or sets the ID of the Client. 
		/// /// </summary> 
		public string Id { get; set; } = string.Empty;
		/// <summary>
		/// Gets or sets the first name of the Client.
		/// </summary>
		public string FirstName { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the middle name of the Client.
		/// </summary>
		public string? MiddleName { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the last name of the Client.
		/// </summary>
		public string LastName { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the email of the Client.
		/// </summary>
		public string Email { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the phone number of the Client.
		/// </summary>
		public string PhoneNumber { get; set; } = string.Empty;

		public string? ImgUrl { get; set; }
		/// <summary>
		/// Gets or sets the address ID of the Fixer.
		/// </summary>
		public int AddressId { get; set; }
		public AddressDto Address { get; set; } = null!; // Navigation property

		public string Location { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the verification document of the Client.
		/// </summary>
		public string VerificationDocument { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets a value indicating whether the Client is verified.
		/// </summary>
		public bool IsVerified { get; set; }
	}
}
