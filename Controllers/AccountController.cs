using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using QuickProFixer.DTOs;
using QuickProFixer.Services;

namespace QuickProFixer.Controllers
{
	/// <summary>
	/// Controller for account-related operations such as registration and verification.
	/// </summary>

	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly IAccountService _accountService;

		/// <summary>
		/// Initializes a new instance of the <see cref="AccountController"/> class.
		/// </summary>
		/// <param name="accountService">The account service

		public AccountController(IAccountService accountService)
		{
			_accountService = accountService;
		}

		/// <summary>
		/// Registers a new Fixer.
		/// </summary>
		/// <param name="fixerDto">The registration model containing Fixer details.</param>
		/// <returns>An IActionResult indicating the result of the registration process.</returns>
		[HttpPost("register/fixer")]
		public async Task<IActionResult> RegisterFixer([FromBody] FixerDto fixerDto)
		{
			if (!ModelState.IsValid)
			{
				// Return a bad request response if the model state is not valid
				return BadRequest(ModelState);
			}

			// Call the account service to register the Fixer
			var result = await _accountService.RegisterFixerAsync(fixerDto);

			// Return an OK response with the result
			return Ok(result);
		}

		/// <summary>
		/// Registers a new Client.
		/// </summary>
		/// <param name="clientDto">The registration model containing Client details.</param>
		/// <returns>An IActionResult indicating the result of the registration process.</returns>
		[HttpPost("register/client")]
		public async Task<IActionResult> RegisterClient([FromBody] ClientDto clientDto)
		{
			if (!ModelState.IsValid)
			{
				// Return a bad request response if the model state is not valid
				return BadRequest(ModelState);
			}

			// Call the account service to register the Client
			var result = await _accountService.RegisterClientAsync(clientDto);

			// Return an OK response with the result
			return Ok(result);
		}

		/// <summary>
		/// Uploads verification documents for a user.
		/// </summary>
		/// <param name="userId">The ID of the user.</param>
		/// <param name="documentPath">The path of the verification document.</param>
		/// <param name="isFixer">A flag indicating if the user is a Fixer.</param>
		/// <returns>An IActionResult indicating the result of the upload process.</returns>
		[HttpPost("upload/verification-documents")]
		public async Task<IActionResult> UploadVerificationDocuments([FromBody] UploadDocumentDto dto)
		{
			var result = await _accountService.UploadVerificationDocumentAsync(dto.UserId, dto.DocumentPath, dto.IsFixer);

			if (result)
			{
				return Ok(new { Message = "Verification document uploaded successfully." });
			}

			return BadRequest(new { Message = "Failed to upload verification document." });
		}

		/// <summary>
		/// Checks the registration and approval status of a user.
		/// </summary>
		/// <param name="userId">The ID of the user.</param>
		/// <param name="isFixer">A flag indicating if the user is a Fixer.</param>
		/// <returns>An IActionResult indicating the registration status.</returns>
		[HttpGet("verify/registration-status")]
		public async Task<IActionResult> CheckRegistrationStatus(int userId, bool isFixer)
		{
			var isVerified = await _accountService.CheckRegistrationStatusAsync(userId, isFixer);

			return Ok(new { IsVerified = isVerified });
		}
	}
}

