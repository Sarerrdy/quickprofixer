using QuickProFixer.DTOs;
using QuickProFixer.Data;
using QuickProFixer.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace QuickProFixer.Services
{
	public class ProfileService : IProfileService
	{
		private readonly ApplicationDbContext _context;

		public ProfileService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<FixerDto> CreateFixerProfileAsync(FixerDto fixerDto)
		{
			var fixer = new Fixer
			{
				FirstName = fixerDto.FirstName,
				LastName = fixerDto.LastName,
				MiddleName = fixerDto.MiddleName,
				Email = fixerDto.Email,
				PhoneNumber = fixerDto.PhoneNumber,
				Location = fixerDto.Location,
				ExperienceYears = fixerDto.ExperienceYears,
				Portfolio = fixerDto.Portfolio,
				Rating = fixerDto.Rating,
				IsAvailable = fixerDto.IsAvailable,
				Reviews = fixerDto.Reviews,
				ImgUrl = fixerDto.ImgUrl ?? string.Empty,
				RateType = fixerDto.RateType,
				Rate = fixerDto.Rate,
				AddressId = fixerDto.AddressId, // Updated
				SpecializationId = fixerDto.SpecializationId, // Updated
				Certifications = fixerDto.Certifications,
				VerificationDocument = fixerDto.VerificationDocument,
				IsVerified = false
			};

			_context.Fixers.Add(fixer);
			await _context.SaveChangesAsync();

			fixerDto.Id = fixer.Id;
			fixerDto.SpecializationName = (await _context.Services.FindAsync(fixer.SpecializationId))?.Name ?? string.Empty; // Added

			return fixerDto;
		}

		public async Task<FixerDto?> UpdateFixerProfileAsync(FixerDto fixerDto)
		{
			var fixer = await _context.Fixers.FindAsync(fixerDto.Id);
			if (fixer == null)
			{
				return null;
			}

			fixer.FirstName = fixerDto.FirstName;
			fixer.LastName = fixerDto.LastName;
			fixer.MiddleName = fixerDto.MiddleName;
			fixer.Email = fixerDto.Email;
			fixer.PhoneNumber = fixerDto.PhoneNumber;
			fixer.AddressId = fixerDto.AddressId; // Updated
			fixer.ImgUrl = fixerDto.ImgUrl ?? string.Empty;
			fixer.Location = fixerDto.Location;
			fixer.Rating = fixerDto.Rating;
			fixer.IsAvailable = fixerDto.IsAvailable;
			fixer.Reviews = fixerDto.Reviews;
			fixer.ExperienceYears = fixerDto.ExperienceYears;
			fixer.Portfolio = fixerDto.Portfolio;
			fixer.SpecializationId = fixerDto.SpecializationId; // Updated
			fixer.Certifications = fixerDto.Certifications;
			fixer.VerificationDocument = fixerDto.VerificationDocument;
			fixer.IsVerified = fixerDto.IsVerified;

			_context.Fixers.Update(fixer);
			await _context.SaveChangesAsync();

			fixerDto.SpecializationName = (await _context.Services.FindAsync(fixer.SpecializationId))?.Name ?? string.Empty; // Added

			return fixerDto;
		}

		public async Task<FixerDto?> GetFixerProfileAsync(string id)
		{
			var fixer = await _context.Fixers
				.Include(f => f.Specialization)
				.Include(f => f.Address)
				.FirstOrDefaultAsync(f => f.Id == id);
			if (fixer == null)
			{
				return null;
			}

			return new FixerDto
			{
				Id = fixer.Id,
				FirstName = fixer.FirstName,
				LastName = fixer.LastName,
				MiddleName = fixer.MiddleName ?? string.Empty,
				PhoneNumber = fixer.PhoneNumber ?? string.Empty,
				Email = fixer.Email ?? string.Empty,
				SpecializationId = fixer.SpecializationId, // Updated
				SpecializationName = fixer.Specialization.Name, // Added
				Certifications = fixer.Certifications,
				Rating = fixer.Rating,
				Location = fixer.Location,
				IsAvailable = fixer.IsAvailable,
				ImgUrl = fixer.ImgUrl,
				AddressId = fixer.AddressId, // Updated
				Address = new AddressDto
				{
					Id = fixer.Address.Id,
					AddressLine = fixer.Address.AddressLine,
					Landmark = fixer.Address.Landmark,
					Town = fixer.Address.Town,
					LGA = fixer.Address.LGA,
					State = fixer.Address.State,
					ZipCode = fixer.Address.ZipCode,
					Country = fixer.Address.Country
				},
				VerificationDocument = fixer.VerificationDocument,
				IsVerified = fixer.IsVerified,
				Reviews = fixer.Reviews,
				ExperienceYears = fixer.ExperienceYears,
				Portfolio = fixer.Portfolio,
				RateType = fixer.RateType,
				Rate = fixer.Rate
			};
		}

		public async Task<ClientDto> CreateClientProfileAsync(ClientDto clientDto)
		{
			var client = new Client
			{
				FirstName = clientDto.FirstName,
				LastName = clientDto.LastName,
				MiddleName = clientDto.MiddleName,
				ImgUrl = clientDto.ImgUrl ?? string.Empty,
				Email = clientDto.Email,
				PhoneNumber = clientDto.PhoneNumber,
				Location = clientDto.Location,
				AddressId = clientDto.AddressId, // Updated
				VerificationDocument = clientDto.VerificationDocument,
				IsVerified = false
			};

			_context.Clients.Add(client);
			await _context.SaveChangesAsync();

			clientDto.Id = client.Id; // Ensure the returned DTO contains the ID

			return clientDto;
		}

		public async Task<ClientDto?> UpdateClientProfileAsync(ClientDto clientDto)
		{
			var client = await _context.Clients.FindAsync(clientDto.Id);
			if (client == null)
			{
				return null;
			}

			client.FirstName = clientDto.FirstName;
			client.LastName = clientDto.LastName;
			client.MiddleName = clientDto.MiddleName;
			client.ImgUrl = clientDto.ImgUrl ?? string.Empty;
			client.Location = clientDto.Location;
			client.Email = clientDto.Email;
			client.PhoneNumber = clientDto.PhoneNumber;
			client.AddressId = clientDto.AddressId; // Updated
			client.VerificationDocument = clientDto.VerificationDocument;
			client.IsVerified = clientDto.IsVerified;

			_context.Clients.Update(client);
			await _context.SaveChangesAsync();

			return clientDto;
		}

		public async Task<ClientDto?> GetClientProfileAsync(string id)
		{
			var client = await _context.Clients
				.Include(c => c.Address)
				.FirstOrDefaultAsync(c => c.Id == id);
			if (client == null)
			{
				return null;
			}

			return new ClientDto
			{
				Id = client.Id,
				FirstName = client.FirstName,
				LastName = client.LastName,
				MiddleName = client.MiddleName ?? string.Empty,
				ImgUrl = client.ImgUrl ?? string.Empty,
				Email = client.Email ?? string.Empty,
				PhoneNumber = client.PhoneNumber ?? string.Empty,
				Location = client.Location,
				AddressId = client.AddressId, // Updated
				Address = new AddressDto
				{
					Id = client.Address.Id,
					AddressLine = client.Address.AddressLine,
					Landmark = client.Address.Landmark,
					Town = client.Address.Town,
					LGA = client.Address.LGA,
					State = client.Address.State,
					ZipCode = client.Address.ZipCode,
					Country = client.Address.Country
				},
				VerificationDocument = client.VerificationDocument,
				IsVerified = client.IsVerified
			};
		}
	}
}