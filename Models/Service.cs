namespace QuickProFixer.Models
{
	/// <summary>
	/// Represents a service provided by fixers.
	/// </summary>
	public class Service
	{
		public int Id { get; set; }
		public required string Name { get; set; } // e.g., "Plumbing", "Electricals", etc.
	}
}