namespace QuickProFixer.DTOs
{
	public class AdminAnalyticsDto
	{
		public int TotalUsers { get; set; }
		public int TotalFixers { get; set; }
		public int TotalClients { get; set; }
		public int TotalBookings { get; set; }
		public decimal TotalPayments { get; set; }
	}
}