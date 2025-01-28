using QuickProFixer.DTOs;
using QuickProFixer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using quickprofixer.Services;

namespace QuickProFixer.Services
{

	public class AuthService : IAuthService
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly IConfiguration _configuration;

		public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_configuration = configuration;
		}

		public async Task<ApplicationUser?> GetUserByIdAsync(string userId)
		{
			return await _userManager.FindByIdAsync(userId);
		}


		public async Task<string> LoginUserAsync(LoginUserDto loginUserDto)
		{
			var user = await _userManager.FindByEmailAsync(loginUserDto.Email);
			if (user == null)
			{
				throw new Exception("Invalid login attempt.");
			}

			var result = await _signInManager.PasswordSignInAsync(user, loginUserDto.Password, false, false);
			if (!result.Succeeded)
			{
				throw new Exception("Invalid login attempt.");
			}

			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Sub, user.Email ?? string.Empty),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(ClaimTypes.NameIdentifier, user.Id ?? string.Empty)
			};

			var keyString = _configuration["Jwt:Key"] ?? throw new InvalidOperationException("Jwt:Key is not configured.");
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				issuer: _configuration["Jwt:Issuer"],
				audience: _configuration["Jwt:Issuer"],
				claims: claims,
				expires: DateTime.Now.AddMinutes(30),
				signingCredentials: creds);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}