// File: Services/IEmailService.cs
using System.Threading.Tasks;

namespace QuickProFixer.Services
{
	public interface IEmailService
	{
		Task SendEmailAsync(string userId, string subject, string message);
	}
}

