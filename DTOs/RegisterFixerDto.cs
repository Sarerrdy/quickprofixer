namespace QuickProFixer.DTOs
{
	public class RegisterFixerDto
	{
		/// <summary>
		/// Gets or sets the first name of the Fixer.
		/// </summary>
		public required string FirstName { get; set; }
		/// <summary>
		/// Gets or sets the last name of the Fixer.
		/// </summary>
		public required string LastName { get; set; }

		/// <summary>
		/// Gets or sets the email of the Fixer.
		/// </summary>
		public required string Email { get; set; }

		/// <summary>
		/// Gets or sets the phone number of the Fixer.
		/// </summary>
		public required string PhoneNumber { get; set; }

		/// <summary>
		/// Gets or sets the password of the Fixer.
		/// </summary>
		public required string Password { get; set; } // In a real implementation, hash the password

		/// <summary>
		/// Gets or sets the address of the Fixer.
		/// </summary>
		public string Address { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the skill category of the Fixer.
		/// </summary>
		public required string SkillCategory { get; set; }

		/// <summary>
		/// Gets or sets the certifications of the Fixer.
		/// </summary>
		public string Certifications { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the verification document of the Fixer.
		/// </summary>
		public string VerificationDocument { get; set; } = string.Empty;

	}
}
