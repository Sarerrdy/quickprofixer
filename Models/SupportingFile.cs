namespace QuickProFixer.Models
{
	/// <summary>
	/// Represents a supporting file for a quote or fix request.
	/// </summary>
	public class SupportingFile
	{
		public int Id { get; set; }
		public string FileName { get; set; } = string.Empty;
		public string FileType { get; set; } = string.Empty; // e.g., "image", "document", "link"
		public string FileUrl { get; set; } = string.Empty; // URL or path to the file
	}
}