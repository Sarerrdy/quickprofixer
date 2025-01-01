namespace QuickProFixer.DTOs
{
	/// <summary>
	/// Data Transfer Object for supporting files.
	/// </summary>
	public class SupportingFileDto
	{
		public int Id { get; set; }
		public string FileName { get; set; } = string.Empty;
		public string FileType { get; set; } = string.Empty; // e.g., "image", "document", "link"
		public string FileUrl { get; set; } = string.Empty; // URL or path to the file
	}
}