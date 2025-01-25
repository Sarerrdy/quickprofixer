namespace QuickProFixer.DTOs
{
	/// <summary>
	/// Data Transfer Object for registering a Fixer.
	/// </summary>
	public class FixerDto
	{
		/// <summary> 
		/// Gets or sets the ID of the Fixer. 
		/// /// </summary> 
		public string Id { get; set; } = string.Empty;
		/// <summary>
		/// Gets or sets the first name of the Fixer.
		/// </summary>
		public required string FirstName { get; set; }

		/// <summary>
		/// Gets or sets the middle name of the Client.
		/// </summary>
		public string MiddleName { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the last name of the Fixer.
		/// </summary>
		/// 
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
		/// Gets or sets the address of the Fixer.
		/// </summary>
		public string Address { get; set; } = string.Empty;

		public string? ImgUrl { get; set; }

		/// <summary>
		/// Gets or sets the skill category of the Fixer.
		/// </summary>
		public required string Specializations { get; set; }

		/// <summary>
		/// Gets or sets the certifications of the Fixer.
		/// </summary>
		public string? Certifications { get; set; }

		/// <summary>
		/// Gets or sets the verification document of the Fixer.
		/// </summary>
		public string VerificationDocument { get; set; } = string.Empty;
		/// <summary>
		/// Gets or sets a value indicating whether the Fixer is verified.
		/// </summary>
		public bool IsVerified { get; set; } = false;

		/// <summary>
		/// Gets or sets the rating of the Fixer.
		/// </summary>
		public double Rating { get; set; }

		/// <summary>
		/// Gets or sets the location of the Fixer.
		/// </summary>
		public required string Location { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the Fixer is available.
		/// </summary>
		public bool IsAvailable { get; set; }

		/// <summary>
		/// Gets or sets the reviews of the Fixer.
		/// </summary>
		public string Reviews { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the years of experience of the Fixer.
		/// </summary>
		public int ExperienceYears { get; set; }

		/// <summary>
		/// Gets or sets the portfolio of the Fixer.
		/// </summary>
		public string Portfolio { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the rate type of the Fixer (e.g., per hour, per day, per square meter).
		/// </summary>
		public required string RateType { get; set; }

		/// <summary>
		/// Gets or sets the rate of the Fixer (cost per hour, sqm, etc.).
		/// </summary>
		public decimal Rate { get; set; }
	}
}