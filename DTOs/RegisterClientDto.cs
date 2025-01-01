namespace QuickProFixer.DTOs
{
	public class RegisterClientDto
	{

		public required string Password { get; set; }


		/// <summary>
		/// Gets or sets the first name of the Client.
		/// </summary>
		public required string FirstName { get; set; }
		/// <summary>
		/// Gets or sets the last name of the Client.
		/// </summary>
		public required string LastName { get; set; }

		/// <summary>
		/// Gets or sets the email of the Client.
		/// </summary>
		public required string Email { get; set; }

		/// <summary>
		/// Gets or sets the password of the Client.
		/// </summary>
		// public required string Password { get; set; }  // In a real implementation, hash the password

		/// <summary>
		/// Gets or sets the phone number of the Client.
		/// </summary>
		public required string PhoneNumber { get; set; }

		/// <summary>
		/// Gets or sets the password of the Client.
		/// </summary>
		// public required string Password { get; set; }  // In a real implementation, hash the password

		/// <summary>
		/// Gets or sets the address of the Client.
		/// </summary>
		public string Address { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the verification document of the Client.
		/// </summary>
		public string VerificationDocument { get; set; } = string.Empty;


	}
}
