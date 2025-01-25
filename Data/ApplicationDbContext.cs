using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
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

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Configure foreign key constraints to avoid cycles or multiple cascade paths
			modelBuilder.Entity<Booking>()
				.HasOne(b => b.Client)
				.WithMany()
				.HasForeignKey(b => b.ClientId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Booking>()
				.HasOne(b => b.Fixer)
				.WithMany()
				.HasForeignKey(b => b.FixerId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Fixer>()
				.HasMany(f => f.ClientRatings)
				.WithOne(cr => cr.Fixer)
				.HasForeignKey(cr => cr.FixerId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Client>()
				.HasMany(c => c.FixerRatings)
				.WithOne(fr => fr.Client)
				.HasForeignKey(fr => fr.ClientId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Quote>()
				.HasOne(q => q.Fixer)
				.WithMany()
				.HasForeignKey(q => q.FixerId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Quote>()
				.HasOne(q => q.Client)
				.WithMany()
				.HasForeignKey(q => q.ClientId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Payment>()
				.HasOne(p => p.Client)
				.WithMany()
				.HasForeignKey(p => p.ClientId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Payment>()
				.HasOne(p => p.Fixer)
				.WithMany()
				.HasForeignKey(p => p.FixerId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Invoice>()
				.HasOne(i => i.Client)
				.WithMany()
				.HasForeignKey(i => i.ClientId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Invoice>()
				.HasOne(i => i.Fixer)
				.WithMany()
				.HasForeignKey(i => i.FixerId)
				.OnDelete(DeleteBehavior.Restrict);

			// Configure precision and scale for decimal properties
			modelBuilder.Entity<Fixer>()
				.Property(f => f.Rate)
				.HasColumnType("decimal(18,2)");

			modelBuilder.Entity<QuoteItem>()
				.Property(qi => qi.UnitPrice)
				.HasColumnType("decimal(18,2)");

			modelBuilder.Entity<Quote>()
				.Property(q => q.Amount)
				.HasColumnType("decimal(18,2)");

			modelBuilder.Entity<Payment>()
				.Property(p => p.Amount)
				.HasColumnType("decimal(18,2)");

			modelBuilder.Entity<Invoice>()
				.Property(i => i.Amount)
				.HasColumnType("decimal(18,2)");

			// Map Fixer and Client to their own tables
			modelBuilder.Entity<Fixer>().ToTable("Fixers");
			modelBuilder.Entity<Client>().ToTable("Clients");

			// Generate sample password
			var passwordHasher = new PasswordHasher<ApplicationUser>();
			var samplePassword = "SamplePassword123!";

			// Seed sample data
			var client1 = new Client
			{
				Id = "client1",
				FirstName = "John",
				LastName = "Doe",
				Email = "john.doe@example.com",
				UserName = "john.doe@example.com",
				NormalizedUserName = "JOHN.DOE@EXAMPLE.COM",
				NormalizedEmail = "JOHN.DOE@EXAMPLE.COM",
				EmailConfirmed = true,
				PhoneNumber = "1234567890",
				PhoneNumberConfirmed = true,
				Address = "123 Main St",
				Location = "Portharcourt",
				VerificationDocument = "doc1.pdf",
				IsVerified = true,
				CurrentRole = "Client"
			};
			client1.PasswordHash = passwordHasher.HashPassword(client1, samplePassword);

			var client2 = new Client
			{
				Id = "client2",
				FirstName = "Jane",
				LastName = "Doe",
				Email = "jane.doe@example.com",
				UserName = "jane.doe@example.com",
				NormalizedUserName = "JANE.DOE@EXAMPLE.COM",
				NormalizedEmail = "JANE.DOE@EXAMPLE.COM",
				EmailConfirmed = true,
				PhoneNumber = "0987654321",
				PhoneNumberConfirmed = true,
				Address = "456 Elm St",
				Location = "Portharcourt",
				VerificationDocument = "doc2.pdf",
				IsVerified = true,
				CurrentRole = "Client"
			};
			client2.PasswordHash = passwordHasher.HashPassword(client2, samplePassword);

			var fixer1 = new Fixer
			{
				Id = "fixer1",
				FirstName = "Alice",
				LastName = "Smith",
				Email = "alice.smith@example.com",
				UserName = "alice.smith@example.com",
				NormalizedUserName = "ALICE.SMITH@EXAMPLE.COM",
				NormalizedEmail = "ALICE.SMITH@EXAMPLE.COM",
				EmailConfirmed = true,
				PhoneNumber = "1234567890",
				PhoneNumberConfirmed = true,
				Address = "789 Pine St",
				Location = "Portharcourt",
				VerificationDocument = "doc3.pdf",
				IsVerified = true,
				CurrentRole = "Fixer",
				Specializations = "Electrical",
				Certifications = "Certified Electrician",
				Rating = 4.8,
				IsAvailable = true,
				Reviews = "Great work",
				ExperienceYears = 5,
				Portfolio = "portfolio1.pdf",
				RateType = "Per Hour",
				Rate = 40.0m
			};
			fixer1.PasswordHash = passwordHasher.HashPassword(fixer1, samplePassword);

			var fixer2 = new Fixer
			{
				Id = "fixer2",
				FirstName = "Bob",
				LastName = "Johnson",
				Email = "bob.johnson@example.com",
				UserName = "bob.johnson@example.com",
				NormalizedUserName = "BOB.JOHNSON@EXAMPLE.COM",
				NormalizedEmail = "BOB.JOHNSON@EXAMPLE.COM",
				EmailConfirmed = true,
				PhoneNumber = "2345678901",
				PhoneNumberConfirmed = true,
				Address = "101 Maple St",
				Location = "Portharcourt",
				VerificationDocument = "doc4.pdf",
				IsVerified = true,
				CurrentRole = "Fixer",
				Specializations = "Plumbing",
				Certifications = "Certified Plumber",
				Rating = 4.5,
				IsAvailable = true,
				Reviews = "Excellent service",
				ExperienceYears = 10,
				Portfolio = "portfolio2.pdf",
				RateType = "Per Hour",
				Rate = 50.0m
			};
			fixer2.PasswordHash = passwordHasher.HashPassword(fixer2, samplePassword);

			var fixer3 = new Fixer
			{
				Id = "fixer3",
				FirstName = "Charlie",
				LastName = "Brown",
				Email = "charlie.brown@example.com",
				UserName = "charlie.brown@example.com",
				NormalizedUserName = "CHARLIE.BROWN@EXAMPLE.COM",
				NormalizedEmail = "CHARLIE.BROWN@EXAMPLE.COM",
				EmailConfirmed = true,
				PhoneNumber = "3456789012",
				PhoneNumberConfirmed = true,
				Address = "202 Oak St",
				Location = "Eleme",
				VerificationDocument = "doc5.pdf",
				IsVerified = true,
				CurrentRole = "Fixer",
				Specializations = "Carpentry",
				Certifications = "Certified Carpenter",
				Rating = 4.7,
				IsAvailable = true,
				Reviews = "Highly skilled",
				ExperienceYears = 8,
				Portfolio = "portfolio3.pdf",
				RateType = "Per Hour",
				Rate = 45.0m
			};
			fixer3.PasswordHash = passwordHasher.HashPassword(fixer3, samplePassword);

			modelBuilder.Entity<Client>().HasData(client1, client2);
			modelBuilder.Entity<Fixer>().HasData(fixer1, fixer2, fixer3);
		}
	}
}