using Microsoft.AspNetCore.Identity;

namespace QuickProFixer.Models
{
	public class ApplicationUser : IdentityUser
	{
		public required string FirstName { get; set; }
		public required string LastName { get; set; }

		public string? MiddleName { get; set; } = "";

	}
}
