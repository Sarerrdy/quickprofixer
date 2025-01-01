using QuickProFixer.DTOs;
using QuickProFixer.Models;
using QuickProFixer.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace QuickProFixer.Services
{
	/// <summary>
	/// Implementation of account-related operations.
	/// </summary>
	public class AccountService : IAccountService
	{
		private readonly ApplicationDbContext _context;

		/// <summary>
		/// Initializes a new instance of the <see cref="AccountService"/> class.
		/// </summary>
		/// <param name="context">The application database context.</param>
		public AccountService(ApplicationDbContext context)
		{
			_context = context;
		}

		/// <inheritdoc />
		public async Task<Fixer> RegisterFixerAsync(FixerDto fixerDto)
		{
			var fixer = new Fixer
			{
				FirstName = fixerDto.FirstName,
				LastName = fixerDto.LastName,
				Email = fixerDto.Email,
				PhoneNumber = fixerDto.PhoneNumber,
				Location = fixerDto.Location,
				// Password = fixerDto.Password, // In a real implementation, hash the password
				Address = fixerDto.Address,
				SkillCategory = fixerDto.SkillCategory,
				Certifications = fixerDto.Certifications,
				VerificationDocument = fixerDto.VerificationDocument,
				IsVerified = false
			};

			_context.Fixers.Add(fixer);
			await _context.SaveChangesAsync();

			return fixer;
		}

		/// <inheritdoc />
		public async Task<Client> RegisterClientAsync(ClientDto clientDto)
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

			return client;
		}

		/// <inheritdoc />
		public async Task<bool> UploadVerificationDocumentAsync(int userId, string documentPath, bool isFixer)
		{
			if (isFixer)
			{
				var fixer = await _context.Fixers.FindAsync(userId);
				if (fixer != null)
				{
					fixer.VerificationDocument = documentPath;
					_context.Fixers.Update(fixer);
					await _context.SaveChangesAsync();
					return true;
				}
			}
			else
			{
				var client = await _context.Clients.FindAsync(userId);
				if (client != null)
				{
					client.VerificationDocument = documentPath;
					_context.Clients.Update(client);
					await _context.SaveChangesAsync();
					return true;
				}
			}

			return false;
		}

		/// <inheritdoc />
		public async Task<bool> CheckRegistrationStatusAsync(int userId, bool isFixer)
		{
			if (isFixer)
			{
				var fixer = await _context.Fixers.FindAsync(userId);
				return fixer?.IsVerified ?? false;
			}
			else
			{
				var client = await _context.Clients.FindAsync(userId);
				return client?.IsVerified ?? false;
			}
		}
	}
}
