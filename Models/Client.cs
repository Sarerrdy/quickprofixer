using Microsoft.AspNetCore.Identity;

namespace QuickProFixer.Models
{
	/// <summary>
	/// Represents a client in the QuickProFixer system.
	/// Inherits from ApplicationUser, which includes standard identity properties.
	/// </summary>
	public class Client : ApplicationUser
	{
		/// <summary>
		/// Gets or sets the address of the client.
		/// </summary>
		public required string Address { get; set; }

		/// <summary>
		/// Gets or sets the location of the fixer.
		/// </summary>
		public required string Location { get; set; }

		/// <summary>
		/// Gets or sets the document used for client verification.
		/// </summary>
		public string VerificationDocument { get; set; } = string.Empty;

		/// <summary>
		/// Indicates whether the client is verified.
		/// </summary>
		public bool IsVerified { get; set; } = false;

		public ICollection<FixerRating> FixerRatings { get; set; } = new List<FixerRating>(); // Navigation property
	}
}