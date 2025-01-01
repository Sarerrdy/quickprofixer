using System.Threading.Tasks;

namespace QuickProFixer.Services
{
	public class EmailService : IEmailService
	{
		public async Task SendEmailAsync(string userId, string subject, string message)
		{
			// Implement email sending logic here
			// Implement email sending logic here
			await Task.CompletedTask; // Placeholder for actual email sending logic
		}
	}
}