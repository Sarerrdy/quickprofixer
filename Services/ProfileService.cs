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
				Email = fixerDto.Email,
				PhoneNumber = fixerDto.PhoneNumber,
				Location = fixerDto.Location,
				RateType = fixerDto.RateType,
				Rate = fixerDto.Rate,
				Address = fixerDto.Address,
				Specializations = fixerDto.Specializations,
				Certifications = fixerDto.Certifications,
				VerificationDocument = fixerDto.VerificationDocument,
				IsVerified = false
			};

			_context.Fixers.Add(fixer);
			await _context.SaveChangesAsync();

			fixerDto.Id = int.Parse(fixer.Id); // Ensure the returned DTO contains the ID

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
			fixer.Email = fixerDto.Email;
			fixer.PhoneNumber = fixerDto.PhoneNumber;
			fixer.Address = fixerDto.Address;
			fixer.Specializations = fixerDto.Specializations;
			fixer.Certifications = fixerDto.Certifications;
			fixer.VerificationDocument = fixerDto.VerificationDocument;
			fixer.IsVerified = fixerDto.IsVerified;

			_context.Fixers.Update(fixer);
			await _context.SaveChangesAsync();

			return fixerDto;
		}

		public async Task<FixerDto?> GetFixerProfileAsync(int id)
		{
			var fixer = await _context.Fixers.FindAsync(id);
			if (fixer == null)
			{
				return null;
			}

			return new FixerDto
			{
				Id = int.Parse(fixer.Id),
				FirstName = fixer.FirstName,
				LastName = fixer.LastName,
				PhoneNumber = fixer.PhoneNumber ?? string.Empty,
				Email = fixer.Email ?? string.Empty,
				Specializations = fixer.Specializations,
				Certifications = fixer.Certifications,
				Rating = fixer.Rating,
				Location = fixer.Location,
				IsAvailable = fixer.IsAvailable,
				Address = fixer.Address,
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
				Email = clientDto.Email,
				PhoneNumber = clientDto.PhoneNumber,
				Location = clientDto.Location,
				Address = clientDto.Address,
				VerificationDocument = clientDto.VerificationDocument,
				IsVerified = false
			};

			_context.Clients.Add(client);
			await _context.SaveChangesAsync();

			clientDto.Id = int.Parse(client.Id); // Ensure the returned DTO contains the ID

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
			client.Email = clientDto.Email;
			client.PhoneNumber = clientDto.PhoneNumber;
			client.Address = clientDto.Address;
			client.VerificationDocument = clientDto.VerificationDocument;
			client.IsVerified = clientDto.IsVerified;

			_context.Clients.Update(client);
			await _context.SaveChangesAsync();

			return clientDto;
		}

		public async Task<ClientDto?> GetClientProfileAsync(int id)
		{
			var client = await _context.Clients.FindAsync(id);
			if (client == null)
			{
				return null;
			}

			return new ClientDto
			{
				Id = int.Parse(client.Id),
				FirstName = client.FirstName,
				LastName = client.LastName,
				Email = client.Email ?? string.Empty,
				PhoneNumber = client.PhoneNumber ?? string.Empty,
				Location = client.Location,
				Address = client.Address,
				VerificationDocument = client.VerificationDocument,
				IsVerified = client.IsVerified
			};
		}
	}
}