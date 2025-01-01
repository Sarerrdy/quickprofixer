// File: Controllers/PaymentController.cs
using Microsoft.AspNetCore.Mvc;
using QuickProFixer.DTOs;
using QuickProFixer.Services;
using System.Threading.Tasks;

namespace QuickProFixer.Controllers
{
	/// <summary>
	/// Controller for managing payments.
	/// </summary>
	[ApiController]
	[Route("api/[controller]")]
	public class PaymentController : ControllerBase
	{
		private readonly IPaymentService _paymentService;

		/// <summary>
		/// Initializes a new instance of the <see cref="PaymentController"/> class.
		/// </summary>
		/// <param name="paymentService">The payment service.</param>
		public PaymentController(IPaymentService paymentService)
		{
			_paymentService = paymentService;
		}

		/// <summary>
		/// Processes a payment.
		/// </summary>
		/// <param name="paymentDto">The payment data transfer object.</param>
		/// <returns>The processed payment data transfer object.</returns>
		[HttpPost("process")]
		public async Task<IActionResult> ProcessPayment([FromBody] PaymentDto paymentDto)
		{
			var result = await _paymentService.ProcessPaymentAsync(paymentDto);
			if (result == null)
			{
				return BadRequest("Invalid payment details.");
			}
			return Ok(result);
		}

		/// <summary>
		/// Completes a client payment.
		/// </summary>
		/// <param name="paymentId">The payment ID.</param>
		/// <returns>The completed payment data transfer object.</returns>
		[HttpPost("complete/client/{paymentId}")]
		public async Task<IActionResult> CompleteClientPayment(int paymentId)
		{
			var result = await _paymentService.CompleteClientPaymentAsync(paymentId);
			if (result == null)
			{
				return NotFound("Payment not found.");
			}
			return Ok(result);
		}

		/// <summary>
		/// Completes a fixer payment.
		/// </summary>
		/// <param name="paymentId">The payment ID.</param>
		/// <returns>The completed payment data transfer object.</returns>
		[HttpPost("complete/fixer/{paymentId}")]
		public async Task<IActionResult> CompleteFixerPayment(int paymentId)
		{
			var result = await _paymentService.CompleteFixerPaymentAsync(paymentId);
			if (result == null)
			{
				return NotFound("Payment not found.");
			}
			return Ok(result);
		}

		/// <summary>
		/// Refunds a payment.
		/// </summary>
		/// <param name="paymentId">The payment ID.</param>
		/// <returns>The refunded payment data transfer object.</returns>
		[HttpPost("refund/{paymentId}")]
		public async Task<IActionResult> RefundPayment(int paymentId)
		{
			var result = await _paymentService.RefundPaymentAsync(paymentId);
			if (result == null)
			{
				return NotFound("Payment not found.");
			}
			return Ok(result);
		}

		/// <summary>
		/// Generates an invoice for a booking.
		/// </summary>
		/// <param name="bookingId">The booking ID.</param>
		/// <returns>The generated invoice data transfer object.</returns>
		[HttpPost("invoice/{bookingId}")]
		public async Task<IActionResult> GenerateInvoice(int bookingId)
		{
			var result = await _paymentService.GenerateInvoiceAsync(bookingId);
			if (result == null)
			{
				return NotFound("Booking not found.");
			}
			return Ok(result);
		}
	}
}