using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using quickprofixer.DTOs;
using QuickProFixer.Models;
using QuickProFixer.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QuickProFixer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly IConfiguration _configuration;
		private readonly IUserService _userService;

		public AuthController(UserManager<ApplicationUser> userManager,
							  SignInManager<ApplicationUser> signInManager,
							  IConfiguration configuration,
							  IUserService userService)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_configuration = configuration;
			_userService = userService;
		}

		/// <summary>
		/// Authenticate a user and provide an access token.
		/// </summary>
		/// <param name="loginDto">The login data transfer object.</param>
		/// <returns>The access token if authentication is successful.</returns>
		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
		{
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
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			if (userId == null)
			{
				return Unauthorized("User ID not found.");
			}

			var user = await _userService.GetUserByIdAsync(userId);
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

		// [HttpPost("switch-role")]
		// [Authorize]
		// public async Task<IActionResult> SwitchRole([FromQuery] string newRole)
		// {
		// 	var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
		// 	if (userId == null)
		// 	{
		// 		return BadRequest("User ID is missing.");
		// 	}

		// 	var user = await _userManager.FindByIdAsync(userId);
		// 	if (user == null || (newRole != "Client" && newRole != "Fixer"))
		// 	{
		// 		return BadRequest("Invalid role or user not found.");
		// 	}

		// 	user.CurrentRole = newRole;
		// 	var result = await _userManager.UpdateAsync(user);

		// 	if (result.Succeeded)
		// 	{
		// 		return Ok(new { Message = $"Role switched to {newRole}." });
		// 	}

		// 	return BadRequest("Failed to switch role.");
		// }
	}
}