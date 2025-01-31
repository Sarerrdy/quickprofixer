using QuickProFixer.DTOs;
using QuickProFixer.Models;
using QuickProFixer.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QuickProFixer.Services
{
	/// <summary>
	/// Implementation of account-related operations.
	/// </summary>
	public class AccountService : IAccountService
	{
		private readonly ApplicationDbContext _context;
		private readonly UserManager<ApplicationUser> _userManager;

		/// <summary>
		/// Initializes a new instance of the <see cref="AccountService"/> class.
		/// </summary>
		/// <param name="context">The application database context.</param>
		/// <param name="userManager">The user manager for handling user-related operations.</param>
		public AccountService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}



		/// <inheritdoc />

		public async Task<ApplicationUser> RegisterUserAsync(RegisterUserDto registerUserDto, string password)
		{
			var user = new ApplicationUser
			{
				UserName = registerUserDto.Email,
				Email = registerUserDto.Email,
				PhoneNumber = registerUserDto.PhoneNumber,
				FirstName = registerUserDto.FirstName,
				LastName = registerUserDto.LastName,
				MiddleName = registerUserDto.MiddleName
			};

			var result = await _userManager.CreateAsync(user, password);
			if (result.Succeeded)
			{
				return user;
			}

			throw new Exception("Failed to register user.");
		}

		public async Task<Fixer> RegisterFixerAsync(FixerDto fixerDto, string password)
		{
			var fixer = new Fixer
			{
				UserName = fixerDto.Email,
				Email = fixerDto.Email,
				FirstName = fixerDto.FirstName,
				LastName = fixerDto.LastName,
				MiddleName = fixerDto.MiddleName,
				PhoneNumber = fixerDto.PhoneNumber,
				ImgUrl = fixerDto.ImgUrl ?? string.Empty,
				SpecializationId = fixerDto.SpecializationId, // Updated
				Certifications = fixerDto.Certifications,
				VerificationDocument = fixerDto.VerificationDocument,
				IsVerified = false,
				Rating = fixerDto.Rating,
				Location = fixerDto.Location,
				IsAvailable = fixerDto.IsAvailable,
				AddressId = fixerDto.AddressId, // Updated
				Reviews = fixerDto.Reviews,
				ExperienceYears = fixerDto.ExperienceYears,
				Portfolio = fixerDto.Portfolio,
				RateType = fixerDto.RateType,
				Rate = fixerDto.Rate
			};

			var result = await _userManager.CreateAsync(fixer, password);
			if (result.Succeeded)
			{
				return fixer;
			}

			throw new Exception("Failed to register fixer.");
		}

		/// <inheritdoc />
		public async Task<Client> RegisterClientAsync(ClientDto clientDto, string password)
		{
			var client = new Client
			{
				UserName = clientDto.Email,
				Email = clientDto.Email,
				FirstName = clientDto.FirstName,
				LastName = clientDto.LastName,
				MiddleName = clientDto.MiddleName,
				PhoneNumber = clientDto.PhoneNumber,
				AddressId = clientDto.AddressId, // Updated
				Location = clientDto.Location,
				ImgUrl = clientDto.ImgUrl ?? string.Empty,
				VerificationDocument = clientDto.VerificationDocument,
				IsVerified = clientDto.IsVerified
			};

			var result = await _userManager.CreateAsync(client, password);
			if (result.Succeeded)
			{
				return client;
			}

			throw new Exception("Failed to register client.");
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