using Microsoft.AspNetCore.Identity;

namespace QuickProFixer.Models
{
	/// <summary>
	/// Represents a fixer (artisan) in the QuickProFixer system.
	/// Inherits from ApplicationUser, which includes standard identity properties.
	/// </summary>
	public class Fixer : ApplicationUser
	{
		/// <summary>
		/// Gets or sets the skill category of the fixer.
		/// </summary>
		public required string Specializations { get; set; }

		/// <summary>
		/// Gets or sets the certifications of the fixer.
		/// </summary>
		public string? Certifications { get; set; }

		/// <summary>
		/// Gets or sets the verification document of the fixer.
		/// </summary>
		public string VerificationDocument { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets a value indicating whether the fixer is verified.
		/// </summary>
		public bool IsVerified { get; set; } = false;

		/// <summary>
		/// Gets or sets the rating of the fixer.
		/// </summary>
		public double Rating { get; set; }

		/// <summary>
		/// Gets or sets the address of the client.
		/// </summary>
		public required string Address { get; set; }

		/// <summary>
		/// Gets or sets the location of the fixer.
		/// </summary>
		public required string Location { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the fixer is available.
		/// </summary>
		public bool IsAvailable { get; set; }

		/// <summary>
		/// Gets or sets the reviews of the fixer.
		/// </summary>
		public string Reviews { get; set; } = string.Empty;


		/// <summary>
		/// Gets or sets the years of experience of the fixer.
		/// </summary>
		public int ExperienceYears { get; set; }

		/// <summary>
		/// Gets or sets the portfolio of the fixer.
		/// </summary>
		public string Portfolio { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the rate type of the fixer (e.g., per hour, per day, per square meter).
		/// </summary>
		public required string RateType { get; set; }

		/// <summary>
		/// Gets or sets the rate of the fixer (cost per hour, sqm, etc.).
		/// </summary>
		public decimal Rate { get; set; }
		public ICollection<ClientRating> ClientRatings { get; set; } = new List<ClientRating>(); // Navigation property
	}
}
