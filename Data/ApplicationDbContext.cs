using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuickProFixer.Models;

namespace QuickProFixer.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<Fixer> Fixers { get; set; } = null!;
		public DbSet<Client> Clients { get; set; } = null!;
		public DbSet<FixRequest> FixRequests { get; set; } = null!;
		public DbSet<Quote> Quotes { get; set; } = null!;
		public DbSet<QuoteItem> QuoteItems { get; set; } = null!;
		public DbSet<SupportingFile> SupportingFiles { get; set; } = null!;
		public DbSet<Booking> Bookings { get; set; } = null!;
		public DbSet<FixerRating> FixerRatings { get; set; } = null!;
		public DbSet<ClientRating> ClientRatings { get; set; } = null!;
		public DbSet<Payment> Payments { get; set; } = null!;
		public DbSet<Invoice> Invoices { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Configure foreign key constraints to avoid cycles or multiple cascade paths
			modelBuilder.Entity<ClientRating>()
				.HasOne(cr => cr.Fixer)
				.WithMany(f => f.ClientRatings)
				.HasForeignKey(cr => cr.FixerId)
				.OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<FixerRating>()
				.HasOne(fr => fr.Client)
				.WithMany(c => c.FixerRatings)
				.HasForeignKey(fr => fr.ClientId)
				.OnDelete(DeleteBehavior.NoAction);

			// Add similar configurations for other entities as needed
		}
	}
}