using Microsoft.EntityFrameworkCore;
using QuickProFixer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace QuickProFixer.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public required DbSet<Fixer> Fixers { get; set; }
		public required DbSet<Client> Clients { get; set; }
		public required DbSet<FixRequest> FixRequests { get; set; }
		public required DbSet<Quote> Quotes { get; set; }
		public required DbSet<Booking> Bookings { get; set; }
		public required DbSet<FixerRating> FixerRatings { get; set; }
		public required DbSet<ClientRating> ClientRatings { get; set; }
		public required DbSet<Payment> Payments { get; set; }
		public required DbSet<Invoice> Invoices { get; set; }
	}
}