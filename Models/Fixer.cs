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
		public required string SkillCategory { get; set; }

		/// <summary>
		/// Gets or sets the certifications of the fixer.
		/// </summary>
		public string Certifications { get; set; } = string.Empty;

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
	}
}
