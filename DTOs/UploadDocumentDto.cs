namespace QuickProFixer.DTOs
{
	public class UploadDocumentDto
	{
		public int UserId { get; set; }
		public required string DocumentPath { get; set; }
		public bool IsFixer { get; set; }
	}
}
