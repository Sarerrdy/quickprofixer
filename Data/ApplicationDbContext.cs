using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using QuickProFixer.Models;
using System.Collections.Generic;

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
		public DbSet<Service> Services { get; set; } = null!;
		public DbSet<Address> Addresses { get; set; } = null!;

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

			// Configure Fixer to have a foreign key to Service
			modelBuilder.Entity<Fixer>()
				.HasOne(f => f.Specialization)
				.WithMany()
				.HasForeignKey(f => f.SpecializationId)
				.OnDelete(DeleteBehavior.Restrict);

			// Configure Fixer to have a foreign key to Address
			modelBuilder.Entity<Fixer>()
				.HasOne(f => f.Address)
				.WithMany()
				.HasForeignKey(f => f.AddressId)
				.OnDelete(DeleteBehavior.Restrict);

			// Configure Client to have a foreign key to Address
			modelBuilder.Entity<Client>()
				.HasOne(c => c.Address)
				.WithMany()
				.HasForeignKey(c => c.AddressId)
				.OnDelete(DeleteBehavior.Restrict);

			// Configure FixRequest to have a foreign key to Address
			modelBuilder.Entity<FixRequest>()
				.HasOne(fr => fr.Address)
				.WithMany()
				.HasForeignKey(fr => fr.AddressId)
				.OnDelete(DeleteBehavior.Restrict);

			// Configure FixRequest to have a foreign key to Service
			modelBuilder.Entity<FixRequest>()
				.HasOne(fr => fr.Specialization)
				.WithMany()
				.HasForeignKey(fr => fr.SpecializationId)
				.OnDelete(DeleteBehavior.Restrict);

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
				AddressId = 6,
				Location = "Eleme",
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
				AddressId = 7,
				Location = "Portharcourt",
				VerificationDocument = "doc2.pdf",
				IsVerified = true,
				CurrentRole = "Client"
			};
			client2.PasswordHash = passwordHasher.HashPassword(client2, samplePassword);

			var services = new List<Service>
			{
				new Service { Id = 1, Name = "Plumbing" },
				new Service { Id = 2, Name = "Electricals" },
				new Service { Id = 3, Name = "Masonry" },
				new Service { Id = 4, Name = "Tiling" },
				new Service { Id = 5, Name = "Screeding" },
				new Service { Id = 6, Name = "Painting" }
			};

			var addresses = new List<Address>
			{
				new Address { Id = 1, AddressLine = "123 Main St", Town = "Portharcourt", LGA = "Portharcourt", State = "Rivers", Country = "Nigeria" },
				new Address { Id = 2, AddressLine = "456 Elm St", Town = "Portharcourt", LGA = "Portharcourt", State = "Rivers", Country = "Nigeria" },
				new Address { Id = 3, AddressLine = "789 Pine St", Town = "Portharcourt", LGA = "Portharcourt", State = "Rivers", Country = "Nigeria" },
				new Address { Id = 4, AddressLine = "101 Maple St", Town = "Eleme", LGA = "Eleme", State = "Rivers", Country = "Nigeria" },
				new Address { Id = 5, AddressLine = "202 Oak St", Town = "Eleme", LGA = "Eleme", State = "Rivers", Country = "Nigeria" },
				new Address { Id = 6, AddressLine = "303 Birch St", Town = "Eleme", LGA = "Eleme", State = "Rivers", Country = "Nigeria" },
				new Address { Id = 7, AddressLine = "404 Cedar St", Town = "Portharcourt", LGA = "Portharcourt", State = "Rivers", Country = "Nigeria" }
			};


			// --- Fixers: Electricals (SpecializationId = 2) ---
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
				AddressId = 1,
				Location = "Portharcourt",
				VerificationDocument = "doc3.pdf",
				IsVerified = true,
				CurrentRole = "Fixer",
				SpecializationId = 2, // Electricals
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

			var fixer6 = new Fixer
			{
				Id = "fixer6",
				FirstName = "Frank",
				LastName = "Edwards",
				Email = "frank.edwards@example.com",
				UserName = "frank.edwards@example.com",
				NormalizedUserName = "FRANK.EDWARDS@EXAMPLE.COM",
				NormalizedEmail = "FRANK.EDWARDS@EXAMPLE.COM",
				EmailConfirmed = true,
				PhoneNumber = "6789012345",
				PhoneNumberConfirmed = true,
				AddressId = 2,
				Location = "Portharcourt",
				VerificationDocument = "doc8.pdf",
				IsVerified = true,
				CurrentRole = "Fixer",
				SpecializationId = 2, // Electricals
				Certifications = "Licensed Electrician",
				Rating = 4.85,
				IsAvailable = true,
				Reviews = "Very reliable and professional",
				ExperienceYears = 6,
				Portfolio = "portfolio6.pdf",
				RateType = "Per Hour",
				Rate = 43.0m
			};
			fixer6.PasswordHash = passwordHasher.HashPassword(fixer6, samplePassword);

			var fixer7 = new Fixer
			{
				Id = "fixer7",
				FirstName = "Grace",
				LastName = "Ike",
				Email = "grace.ike@example.com",
				UserName = "grace.ike@example.com",
				NormalizedUserName = "GRACE.IKE@EXAMPLE.COM",
				NormalizedEmail = "GRACE.IKE@EXAMPLE.COM",
				EmailConfirmed = true,
				PhoneNumber = "7890123456",
				PhoneNumberConfirmed = true,
				AddressId = 3,
				Location = "Portharcourt",
				VerificationDocument = "doc9.pdf",
				IsVerified = true,
				CurrentRole = "Fixer",
				SpecializationId = 2, // Electricals
				Certifications = "Electrical Engineer",
				Rating = 4.7,
				IsAvailable = true,
				Reviews = "Quick and efficient",
				ExperienceYears = 4,
				Portfolio = "portfolio7.pdf",
				RateType = "Per Hour",
				Rate = 38.0m
			};
			fixer7.PasswordHash = passwordHasher.HashPassword(fixer7, samplePassword);

			var fixer8 = new Fixer
			{
				Id = "fixer8",
				FirstName = "Henry",
				LastName = "Okoro",
				Email = "henry.okoro@example.com",
				UserName = "henry.okoro@example.com",
				NormalizedUserName = "HENRY.OKORO@EXAMPLE.COM",
				NormalizedEmail = "HENRY.OKORO@EXAMPLE.COM",
				EmailConfirmed = true,
				PhoneNumber = "8901234567",
				PhoneNumberConfirmed = true,
				AddressId = 4,
				Location = "Eleme",
				VerificationDocument = "doc10.pdf",
				IsVerified = true,
				CurrentRole = "Fixer",
				SpecializationId = 2, // Electricals
				Certifications = "Certified Electrician",
				Rating = 4.6,
				IsAvailable = true,
				Reviews = "Good communication",
				ExperienceYears = 7,
				Portfolio = "portfolio8.pdf",
				RateType = "Per Hour",
				Rate = 41.0m
			};
			fixer8.PasswordHash = passwordHasher.HashPassword(fixer8, samplePassword);

			// --- Fixers: Plumbing (SpecializationId = 1) ---
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
				AddressId = 2,
				Location = "Portharcourt",
				VerificationDocument = "doc4.pdf",
				IsVerified = true,
				CurrentRole = "Fixer",
				SpecializationId = 1, // Plumbing
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

			var fixer9 = new Fixer
			{
				Id = "fixer9",
				FirstName = "Ifeanyi",
				LastName = "Nwosu",
				Email = "ifeanyi.nwosu@example.com",
				UserName = "ifeanyi.nwosu@example.com",
				NormalizedUserName = "IFEANYI.NWOSU@EXAMPLE.COM",
				NormalizedEmail = "IFEANYI.NWOSU@EXAMPLE.COM",
				EmailConfirmed = true,
				PhoneNumber = "9012345678",
				PhoneNumberConfirmed = true,
				AddressId = 5,
				Location = "Eleme",
				VerificationDocument = "doc11.pdf",
				IsVerified = true,
				CurrentRole = "Fixer",
				SpecializationId = 1, // Plumbing
				Certifications = "Licensed Plumber",
				Rating = 4.4,
				IsAvailable = true,
				Reviews = "Very neat work",
				ExperienceYears = 8,
				Portfolio = "portfolio9.pdf",
				RateType = "Per Hour",
				Rate = 47.0m
			};
			fixer9.PasswordHash = passwordHasher.HashPassword(fixer9, samplePassword);

			var fixer10 = new Fixer
			{
				Id = "fixer10",
				FirstName = "Janet",
				LastName = "Opara",
				Email = "janet.opara@example.com",
				UserName = "janet.opara@example.com",
				NormalizedUserName = "JANET.OPARA@EXAMPLE.COM",
				NormalizedEmail = "JANET.OPARA@EXAMPLE.COM",
				EmailConfirmed = true,
				PhoneNumber = "9123456780",
				PhoneNumberConfirmed = true,
				AddressId = 6,
				Location = "Eleme",
				VerificationDocument = "doc12.pdf",
				IsVerified = true,
				CurrentRole = "Fixer",
				SpecializationId = 1, // Plumbing
				Certifications = "Certified Plumber",
				Rating = 4.3,
				IsAvailable = true,
				Reviews = "Prompt and polite",
				ExperienceYears = 6,
				Portfolio = "portfolio10.pdf",
				RateType = "Per Hour",
				Rate = 44.0m
			};
			fixer10.PasswordHash = passwordHasher.HashPassword(fixer10, samplePassword);

			var fixer11 = new Fixer
			{
				Id = "fixer11",
				FirstName = "Kingsley",
				LastName = "Eze",
				Email = "kingsley.eze@example.com",
				UserName = "kingsley.eze@example.com",
				NormalizedUserName = "KINGSLEY.EZE@EXAMPLE.COM",
				NormalizedEmail = "KINGSLEY.EZE@EXAMPLE.COM",
				EmailConfirmed = true,
				PhoneNumber = "9234567801",
				PhoneNumberConfirmed = true,
				AddressId = 7,
				Location = "Portharcourt",
				VerificationDocument = "doc13.pdf",
				IsVerified = true,
				CurrentRole = "Fixer",
				SpecializationId = 1, // Plumbing
				Certifications = "Master Plumber",
				Rating = 4.6,
				IsAvailable = true,
				Reviews = "Highly recommended",
				ExperienceYears = 12,
				Portfolio = "portfolio11.pdf",
				RateType = "Per Hour",
				Rate = 52.0m
			};
			fixer11.PasswordHash = passwordHasher.HashPassword(fixer11, samplePassword);

			// --- Fixers: Masonry (SpecializationId = 3) ---
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
				AddressId = 3,
				Location = "Portharcourt",
				VerificationDocument = "doc5.pdf",
				IsVerified = true,
				CurrentRole = "Fixer",
				SpecializationId = 3, // Masonry
				Certifications = "Certified Mason",
				Rating = 4.7,
				IsAvailable = true,
				Reviews = "Highly skilled",
				ExperienceYears = 8,
				Portfolio = "portfolio3.pdf",
				RateType = "Per Hour",
				Rate = 45.0m
			};
			fixer3.PasswordHash = passwordHasher.HashPassword(fixer3, samplePassword);

			var fixer12 = new Fixer
			{
				Id = "fixer12",
				FirstName = "Linda",
				LastName = "George",
				Email = "linda.george@example.com",
				UserName = "linda.george@example.com",
				NormalizedUserName = "LINDA.GEORGE@EXAMPLE.COM",
				NormalizedEmail = "LINDA.GEORGE@EXAMPLE.COM",
				EmailConfirmed = true,
				PhoneNumber = "9345678012",
				PhoneNumberConfirmed = true,
				AddressId = 1,
				Location = "Portharcourt",
				VerificationDocument = "doc14.pdf",
				IsVerified = true,
				CurrentRole = "Fixer",
				SpecializationId = 3, // Masonry
				Certifications = "Masonry Expert",
				Rating = 4.5,
				IsAvailable = true,
				Reviews = "Solid work",
				ExperienceYears = 9,
				Portfolio = "portfolio12.pdf",
				RateType = "Per Hour",
				Rate = 46.0m
			};
			fixer12.PasswordHash = passwordHasher.HashPassword(fixer12, samplePassword);

			var fixer13 = new Fixer
			{
				Id = "fixer13",
				FirstName = "Michael",
				LastName = "Ibrahim",
				Email = "michael.ibrahim@example.com",
				UserName = "michael.ibrahim@example.com",
				NormalizedUserName = "MICHAEL.IBRAHIM@EXAMPLE.COM",
				NormalizedEmail = "MICHAEL.IBRAHIM@EXAMPLE.COM",
				EmailConfirmed = true,
				PhoneNumber = "9456780123",
				PhoneNumberConfirmed = true,
				AddressId = 2,
				Location = "Portharcourt",
				VerificationDocument = "doc15.pdf",
				IsVerified = true,
				CurrentRole = "Fixer",
				SpecializationId = 3, // Masonry
				Certifications = "Certified Mason",
				Rating = 4.6,
				IsAvailable = true,
				Reviews = "Very creative",
				ExperienceYears = 7,
				Portfolio = "portfolio13.pdf",
				RateType = "Per Hour",
				Rate = 44.0m
			};
			fixer13.PasswordHash = passwordHasher.HashPassword(fixer13, samplePassword);

			var fixer14 = new Fixer
			{
				Id = "fixer14",
				FirstName = "Ngozi",
				LastName = "Okafor",
				Email = "ngozi.okafor@example.com",
				UserName = "ngozi.okafor@example.com",
				NormalizedUserName = "NGOZI.OKAFOR@EXAMPLE.COM",
				NormalizedEmail = "NGOZI.OKAFOR@EXAMPLE.COM",
				EmailConfirmed = true,
				PhoneNumber = "9567801234",
				PhoneNumberConfirmed = true,
				AddressId = 4,
				Location = "Eleme",
				VerificationDocument = "doc16.pdf",
				IsVerified = true,
				CurrentRole = "Fixer",
				SpecializationId = 3, // Masonry
				Certifications = "Masonry Specialist",
				Rating = 4.4,
				IsAvailable = true,
				Reviews = "Dependable",
				ExperienceYears = 6,
				Portfolio = "portfolio14.pdf",
				RateType = "Per Hour",
				Rate = 43.0m
			};
			fixer14.PasswordHash = passwordHasher.HashPassword(fixer14, samplePassword);

			// --- Fixers: Tiling (SpecializationId = 4) ---
			var fixer4 = new Fixer
			{
				Id = "fixer4",
				FirstName = "David",
				LastName = "Williams",
				Email = "david.williams@example.com",
				UserName = "david.williams@example.com",
				NormalizedUserName = "DAVID.WILLIAMS@EXAMPLE.COM",
				NormalizedEmail = "DAVID.WILLIAMS@EXAMPLE.COM",
				EmailConfirmed = true,
				PhoneNumber = "4567890123",
				PhoneNumberConfirmed = true,
				AddressId = 4,
				Location = "Eleme",
				VerificationDocument = "doc6.pdf",
				IsVerified = true,
				CurrentRole = "Fixer",
				SpecializationId = 4, // Tiling
				Certifications = "Certified Tiler",
				Rating = 4.6,
				IsAvailable = true,
				Reviews = "Excellent tiling",
				ExperienceYears = 6,
				Portfolio = "portfolio4.pdf",
				RateType = "Per Hour",
				Rate = 42.0m
			};
			fixer4.PasswordHash = passwordHasher.HashPassword(fixer4, samplePassword);

			var fixer15 = new Fixer
			{
				Id = "fixer15",
				FirstName = "Olu",
				LastName = "Adebayo",
				Email = "olu.adebayo@example.com",
				UserName = "olu.adebayo@example.com",
				NormalizedUserName = "OLU.ADEBAYO@EXAMPLE.COM",
				NormalizedEmail = "OLU.ADEBAYO@EXAMPLE.COM",
				EmailConfirmed = true,
				PhoneNumber = "9678012345",
				PhoneNumberConfirmed = true,
				AddressId = 5,
				Location = "Eleme",
				VerificationDocument = "doc17.pdf",
				IsVerified = true,
				CurrentRole = "Fixer",
				SpecializationId = 4, // Tiling
				Certifications = "Expert Tiler",
				Rating = 4.7,
				IsAvailable = true,
				Reviews = "Very neat finish",
				ExperienceYears = 8,
				Portfolio = "portfolio15.pdf",
				RateType = "Per Hour",
				Rate = 44.0m
			};
			fixer15.PasswordHash = passwordHasher.HashPassword(fixer15, samplePassword);

			var fixer16 = new Fixer
			{
				Id = "fixer16",
				FirstName = "Patience",
				LastName = "Uche",
				Email = "patience.uche@example.com",
				UserName = "patience.uche@example.com",
				NormalizedUserName = "PATIENCE.UCHE@EXAMPLE.COM",
				NormalizedEmail = "PATIENCE.UCHE@EXAMPLE.COM",
				EmailConfirmed = true,
				PhoneNumber = "9780123456",
				PhoneNumberConfirmed = true,
				AddressId = 6,
				Location = "Eleme",
				VerificationDocument = "doc18.pdf",
				IsVerified = true,
				CurrentRole = "Fixer",
				SpecializationId = 4, // Tiling
				Certifications = "Certified Tiler",
				Rating = 4.5,
				IsAvailable = true,
				Reviews = "Great attention to detail",
				ExperienceYears = 7,
				Portfolio = "portfolio16.pdf",
				RateType = "Per Hour",
				Rate = 43.0m
			};
			fixer16.PasswordHash = passwordHasher.HashPassword(fixer16, samplePassword);

			var fixer17 = new Fixer
			{
				Id = "fixer17",
				FirstName = "Samuel",
				LastName = "Iroegbu",
				Email = "samuel.iroegbu@example.com",
				UserName = "samuel.iroegbu@example.com",
				NormalizedUserName = "SAMUEL.IROEGBU@EXAMPLE.COM",
				NormalizedEmail = "SAMUEL.IROEGBU@EXAMPLE.COM",
				EmailConfirmed = true,
				PhoneNumber = "9891234567",
				PhoneNumberConfirmed = true,
				AddressId = 7,
				Location = "Portharcourt",
				VerificationDocument = "doc19.pdf",
				IsVerified = true,
				CurrentRole = "Fixer",
				SpecializationId = 4, // Tiling
				Certifications = "Tiling Specialist",
				Rating = 4.6,
				IsAvailable = true,
				Reviews = "Fast and reliable",
				ExperienceYears = 5,
				Portfolio = "portfolio17.pdf",
				RateType = "Per Hour",
				Rate = 41.0m
			};
			fixer17.PasswordHash = passwordHasher.HashPassword(fixer17, samplePassword);

			// --- Fixers: Screeding (SpecializationId = 5) ---
			var fixer5 = new Fixer
			{
				Id = "fixer5",
				FirstName = "Eve",
				LastName = "Davis",
				Email = "eve.davis@example.com",
				UserName = "eve.davis@example.com",
				NormalizedUserName = "EVE.DAVIS@EXAMPLE.COM",
				NormalizedEmail = "EVE.DAVIS@EXAMPLE.COM",
				EmailConfirmed = true,
				PhoneNumber = "5678901234",
				PhoneNumberConfirmed = true,
				AddressId = 5,
				Location = "Eleme",
				VerificationDocument = "doc7.pdf",
				IsVerified = true,
				CurrentRole = "Fixer",
				SpecializationId = 5, // Screeding
				Certifications = "Certified Screeder",
				Rating = 4.9,
				IsAvailable = true,
				Reviews = "Top-notch screeding",
				ExperienceYears = 7,
				Portfolio = "portfolio5.pdf",
				RateType = "Per Hour",
				Rate = 48.0m
			};
			fixer5.PasswordHash = passwordHasher.HashPassword(fixer5, samplePassword);

			var fixer18 = new Fixer
			{
				Id = "fixer18",
				FirstName = "Tunde",
				LastName = "Salami",
				Email = "tunde.salami@example.com",
				UserName = "tunde.salami@example.com",
				NormalizedUserName = "TUNDE.SALAMI@EXAMPLE.COM",
				NormalizedEmail = "TUNDE.SALAMI@EXAMPLE.COM",
				EmailConfirmed = true,
				PhoneNumber = "9901234567",
				PhoneNumberConfirmed = true,
				AddressId = 1,
				Location = "Portharcourt",
				VerificationDocument = "doc20.pdf",
				IsVerified = true,
				CurrentRole = "Fixer",
				SpecializationId = 5, // Screeding
				Certifications = "Expert Screeder",
				Rating = 4.8,
				IsAvailable = true,
				Reviews = "Smooth finish",
				ExperienceYears = 9,
				Portfolio = "portfolio18.pdf",
				RateType = "Per Hour",
				Rate = 47.0m
			};
			fixer18.PasswordHash = passwordHasher.HashPassword(fixer18, samplePassword);

			var fixer19 = new Fixer
			{
				Id = "fixer19",
				FirstName = "Uche",
				LastName = "Nwachukwu",
				Email = "uche.nwachukwu@example.com",
				UserName = "uche.nwachukwu@example.com",
				NormalizedUserName = "UCHE.NWACHUKWU@EXAMPLE.COM",
				NormalizedEmail = "UCHE.NWACHUKWU@EXAMPLE.COM",
				EmailConfirmed = true,
				PhoneNumber = "9012345671",
				PhoneNumberConfirmed = true,
				AddressId = 2,
				Location = "Portharcourt",
				VerificationDocument = "doc21.pdf",
				IsVerified = true,
				CurrentRole = "Fixer",
				SpecializationId = 5, // Screeding
				Certifications = "Certified Screeder",
				Rating = 4.7,
				IsAvailable = true,
				Reviews = "Very professional",
				ExperienceYears = 8,
				Portfolio = "portfolio19.pdf",
				RateType = "Per Hour",
				Rate = 46.0m
			};
			fixer19.PasswordHash = passwordHasher.HashPassword(fixer19, samplePassword);

			var fixer20 = new Fixer
			{
				Id = "fixer20",
				FirstName = "Victoria",
				LastName = "Okeke",
				Email = "victoria.okeke@example.com",
				UserName = "victoria.okeke@example.com",
				NormalizedUserName = "VICTORIA.OKEKE@EXAMPLE.COM",
				NormalizedEmail = "VICTORIA.OKEKE@EXAMPLE.COM",
				EmailConfirmed = true,
				PhoneNumber = "9123456712",
				PhoneNumberConfirmed = true,
				AddressId = 3,
				Location = "Portharcourt",
				VerificationDocument = "doc22.pdf",
				IsVerified = true,
				CurrentRole = "Fixer",
				SpecializationId = 5, // Screeding
				Certifications = "Screeding Specialist",
				Rating = 4.6,
				IsAvailable = true,
				Reviews = "Great attention to detail",
				ExperienceYears = 6,
				Portfolio = "portfolio20.pdf",
				RateType = "Per Hour",
				Rate = 45.0m
			};
			fixer20.PasswordHash = passwordHasher.HashPassword(fixer20, samplePassword);

			// --- Add all fixers to HasData ---
			modelBuilder.Entity<Fixer>().HasData(
				fixer1, fixer2, fixer3, fixer4, fixer5,
				fixer6, fixer7, fixer8, fixer9, fixer10,
				fixer11, fixer12, fixer13, fixer14, fixer15,
				fixer16, fixer17, fixer18, fixer19, fixer20
			);


			modelBuilder.Entity<Client>().HasData(client1, client2);

			// Add services and addresses to the model
			modelBuilder.Entity<Service>().HasData(services);
			modelBuilder.Entity<Address>().HasData(addresses);
		}
	}
}