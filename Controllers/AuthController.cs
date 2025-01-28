using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using quickprofixer.Services;
using QuickProFixer.DTOs;
using QuickProFixer.Models;
using QuickProFixer.Services;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace QuickProFixer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly IConfiguration _configuration;
		private readonly IAuthService _authService;
		private readonly ILogger<AuthController> _logger;

		public AuthController(UserManager<ApplicationUser> userManager,
							  SignInManager<ApplicationUser> signInManager,
							  IConfiguration configuration,
							  IAuthService authService,
							  ILogger<AuthController> logger)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_configuration = configuration;
			_authService = authService;
			_logger = logger;
		}

		/// <summary>
		/// Authenticate a user and provide an access token.
		/// </summary>
		/// <param name="loginDto">The login data transfer object.</param>
		/// <returns>The access token if authentication is successful.</returns>
		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginUserDto loginDto)
		{
			_logger.LogInformation("INSIDE LOGIN ENDPOINT");
			var user = await _userManager.FindByEmailAsync(loginDto.Email);
			if (user != null && await _userManager.CheckPasswordAsync(user, loginDto.Password))
			{
				var token = GenerateJwtToken(user);
				return Ok(new { Token = token });
			}

			return Unauthorized("Invalid email or password.");
		}

		/// <summary>
		/// Logout the user and invalidate the session.
		/// </summary>
		[HttpPost("logout")]
		[Authorize]
		public async Task<IActionResult> Logout()
		{
			_logger.LogInformation("INSIDE LOGOUT ENDPOINT");
			await _signInManager.SignOutAsync();
			return Ok(new { Message = "Logout successful." });
		}

		/// <summary>
		/// Get current user profile details.
		/// </summary>
		[HttpGet("me")]
		[Authorize]
		public async Task<IActionResult> Me()
		{
			_logger.LogInformation("INSIDE ME ENDPOINT");
			_logger.LogInformation($"PRINT CLAIM TYPE: {ClaimTypes.NameIdentifier}");

			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			_logger.LogInformation($"VALUE OF USER ID: {userId}");
			if (userId == null)
			{
				return Unauthorized("User ID not found.");
			}

			var user = await _authService.GetUserByIdAsync(userId);
			_logger.LogInformation($"VALUE OF USER: {user}");
			if (user == null)
			{
				return NotFound("User not found.");
			}

			return Ok(user);
		}

		private string GenerateJwtToken(ApplicationUser user)
		{
			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Sub, user.UserName ?? string.Empty),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(ClaimTypes.NameIdentifier, user.Id ?? string.Empty)
			};

			var keyString = _configuration["Jwt:Key"];
			if (string.IsNullOrEmpty(keyString))
			{
				throw new InvalidOperationException("Jwt:Key is not configured.");
			}

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				issuer: _configuration["Jwt:Issuer"] ?? string.Empty,
				audience: _configuration["Jwt:Audience"] ?? string.Empty,
				claims: claims,
				expires: DateTime.Now.AddMinutes(30),
				signingCredentials: creds);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}