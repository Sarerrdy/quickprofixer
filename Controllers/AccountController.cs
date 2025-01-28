using Microsoft.AspNetCore.Mvc;
using QuickProFixer.DTOs;
using QuickProFixer.Services;
using System.Threading.Tasks;

namespace QuickProFixer.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AccountController : ControllerBase
	{
		private readonly IAccountService _accountService;

		public AccountController(IAccountService accountService)
		{
			_accountService = accountService;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegisterUserDto registerUserDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			try
			{
				var user = await _accountService.RegisterUserAsync(registerUserDto, registerUserDto.Password);
				return Ok("User registered successfully");
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(string.Empty, ex.Message);
				return BadRequest(ModelState);
			}
		}

		/// <summary>
		/// Registers a new Fixer.
		/// </summary>
		/// <param name="fixerDto">The registration model containing Fixer details.</param>
		/// <param name="password">The password for the Fixer.</param>
		/// <returns>An IActionResult indicating the result of the registration process.</returns>
		[HttpPost("register/fixer")]
		public async Task<IActionResult> RegisterFixer([FromBody] FixerDto fixerDto, [FromQuery] string password)
		{
			if (!ModelState.IsValid)
			{
				// Return a bad request response if the model state is not valid
				return BadRequest(ModelState);
			}

			// Call the account service to register the Fixer
			var result = await _accountService.RegisterFixerAsync(fixerDto, password);

			// Return an OK response with the result
			return Ok(result);
		}

		/// <summary>
		/// Registers a new Client.
		/// </summary>
		/// <param name="clientDto">The registration model containing Client details.</param>
		/// <param name="password">The password for the Client.</param>
		/// <returns>An IActionResult indicating the result of the registration process.</returns>
		[HttpPost("register/client")]
		public async Task<IActionResult> RegisterClient([FromBody] ClientDto clientDto, [FromQuery] string password)
		{
			if (!ModelState.IsValid)
			{
				// Return a bad request response if the model state is not valid
				return BadRequest(ModelState);
			}

			// Call the account service to register the Client
			var result = await _accountService.RegisterClientAsync(clientDto, password);

			// Return an OK response with the result
			return Ok(result);
		}

		/// <summary>
		/// Uploads verification documents for a user.
		/// </summary>
		/// <param name="userId">The ID of the user.</param>
		/// <param name="documentPath">The path to the verification document.</param>
		/// <param name="isFixer">Indicates if the user is a Fixer.</param>
		/// <returns>An IActionResult indicating the result of the upload process.</returns>
		[HttpPost("upload-verification-document")]
		public async Task<IActionResult> UploadVerificationDocument(int userId, [FromBody] string documentPath, [FromQuery] bool isFixer)
		{
			var result = await _accountService.UploadVerificationDocumentAsync(userId, documentPath, isFixer);
			if (result)
			{
				return Ok();
			}

			return BadRequest("Failed to upload verification document.");
		}

		/// <summary>
		/// Checks the registration status of a user.
		/// </summary>
		/// <param name="userId">The ID of the user.</param>
		/// <param name="isFixer">Indicates if the user is a Fixer.</param>
		/// <returns>An IActionResult indicating the registration status of the user.</returns>
		[HttpGet("check-registration-status")]
		public async Task<IActionResult> CheckRegistrationStatus(int userId, [FromQuery] bool isFixer)
		{
			var result = await _accountService.CheckRegistrationStatusAsync(userId, isFixer);
			return Ok(result);
		}
	}
}