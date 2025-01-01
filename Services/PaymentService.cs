// File: Services/PaymentService.cs
using QuickProFixer.Data;
using QuickProFixer.DTOs;
using QuickProFixer.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace QuickProFixer.Services
{
	public class PaymentService : IPaymentService
	{
		private readonly ApplicationDbContext _context;
		private readonly HttpClient _httpClient;
		private readonly string _paystackSecretKey;

		public PaymentService(ApplicationDbContext context, HttpClient httpClient, IConfiguration configuration)
		{
			_context = context;
			_httpClient = httpClient;
			_paystackSecretKey = configuration["Paystack:SecretKey"] ?? throw new ArgumentNullException(nameof(configuration), "Paystack secret key is not configured.");
		}

		public async Task<PaymentDto?> ProcessPaymentAsync(PaymentDto paymentDto)
		{
			var client = await _context.Clients.FindAsync(paymentDto.ClientId);
			var fixer = await _context.Fixers.FindAsync(paymentDto.FixerId);
			var booking = await _context.Bookings.FindAsync(paymentDto.BookingId);

			if (client == null || fixer == null || booking == null)
			{
				return null; // Ensure client, fixer, and booking exist
			}

			// Initialize Paystack payment
			var paymentResponse = await InitializePaystackPayment(paymentDto.Amount, client.Email ?? throw new ArgumentNullException(nameof(client.Email), "Client email is null."));
			if (paymentResponse == null || !paymentResponse.Status)
			{
				return null; // Payment initialization failed
			}

			var payment = new Payment
			{
				ClientId = paymentDto.ClientId!,
				Client = client,
				FixerId = paymentDto.FixerId!,
				Fixer = fixer,
				BookingId = paymentDto.BookingId,
				Booking = booking,
				Amount = paymentDto.Amount,
				ClientPaymentStatus = "Pending", // Client payment status is set to 'Pending'
				FixerPaymentStatus = "Pending", // Fixer payment status is set to 'Pending'
				CreatedAt = paymentDto.CreatedAt
			};

			_context.Payments.Add(payment);
			await _context.SaveChangesAsync();

			paymentDto.Id = payment.Id;
			paymentDto.ClientPaymentStatus = payment.ClientPaymentStatus;
			paymentDto.FixerPaymentStatus = payment.FixerPaymentStatus;
			paymentDto.CreatedAt = payment.CreatedAt;

			return paymentDto;
		}

		public async Task<PaymentDto?> CompleteClientPaymentAsync(int paymentId)
		{
			var payment = await _context.Payments.FindAsync(paymentId);
			if (payment == null)
			{
				return null; // Ensure payment exists
			}

			payment.ClientPaymentStatus = "Completed"; // Client payment status is set to 'Completed'
			await _context.SaveChangesAsync();

			return new PaymentDto
			{
				Id = payment.Id,
				ClientId = payment.ClientId,
				FixerId = payment.FixerId,
				BookingId = payment.BookingId,
				Amount = payment.Amount,
				ClientPaymentStatus = payment.ClientPaymentStatus,
				FixerPaymentStatus = payment.FixerPaymentStatus,
				CreatedAt = payment.CreatedAt
			};
		}

		public async Task<PaymentDto?> CompleteFixerPaymentAsync(int bookingId)
		{
			var payment = await _context.Payments.FirstOrDefaultAsync(p => p.BookingId == bookingId);
			if (payment == null)
			{
				return null;
			}

			payment.FixerPaymentStatus = "Completed";
			_context.Payments.Update(payment);
			await _context.SaveChangesAsync();

			return new PaymentDto
			{
				Id = payment.Id,
				ClientId = payment.ClientId,
				FixerId = payment.FixerId,
				BookingId = payment.BookingId,
				Amount = payment.Amount,
				ClientPaymentStatus = payment.ClientPaymentStatus,
				FixerPaymentStatus = payment.FixerPaymentStatus,
				CreatedAt = payment.CreatedAt
			};
		}

		public async Task<PaymentDto?> RefundPaymentAsync(int paymentId)
		{
			var payment = await _context.Payments.FindAsync(paymentId);
			if (payment == null)
			{
				return null; // Ensure payment exists
			}

			payment.ClientPaymentStatus = "Refunded"; // Client payment status is set to 'Refunded'
			await _context.SaveChangesAsync();

			return new PaymentDto
			{
				Id = payment.Id,
				ClientId = payment.ClientId,
				FixerId = payment.FixerId,
				BookingId = payment.BookingId,
				Amount = payment.Amount,
				ClientPaymentStatus = payment.ClientPaymentStatus,
				FixerPaymentStatus = payment.FixerPaymentStatus,
				CreatedAt = payment.CreatedAt
			};
		}

		public async Task<InvoiceDto?> GenerateInvoiceAsync(int bookingId)
		{
			var booking = await _context.Bookings.FindAsync(bookingId);
			if (booking == null)
			{
				return null; // Ensure booking exists
			}

			var invoice = new Invoice
			{
				ClientId = booking.ClientId,
				Client = booking.Client,
				FixerId = booking.FixerId,
				Fixer = booking.Fixer,
				BookingId = booking.Id,
				Booking = booking,
				Amount = booking.Quote.Amount,
				CreatedAt = DateTime.UtcNow,
				InvoiceNumber = Guid.NewGuid().ToString()
			};

			_context.Invoices.Add(invoice);
			await _context.SaveChangesAsync();

			return new InvoiceDto
			{
				Id = invoice.Id,
				ClientId = invoice.ClientId,
				FixerId = invoice.FixerId,
				BookingId = invoice.BookingId,
				Amount = invoice.Amount,
				CreatedAt = invoice.CreatedAt,
				InvoiceNumber = invoice.InvoiceNumber
			};
		}

		private async Task<PaystackPaymentResponse?> InitializePaystackPayment(decimal amount, string email)
		{
			var requestContent = new StringContent(JsonSerializer.Serialize(new
			{
				email,
				amount = amount * 100 // Paystack expects amount in kobo
			}), System.Text.Encoding.UTF8, "application/json");

			var request = new HttpRequestMessage(HttpMethod.Post, "https://api.paystack.co/transaction/initialize")
			{
				Headers = { { "Authorization", $"Bearer {_paystackSecretKey}" } },
				Content = requestContent
			};

			var response = await _httpClient.SendAsync(request);
			if (!response.IsSuccessStatusCode)
			{
				return null;
			}

			var responseContent = await response.Content.ReadAsStringAsync();
			return JsonSerializer.Deserialize<PaystackPaymentResponse>(responseContent);
		}
	}

	public class PaystackPaymentResponse
	{
		public bool Status { get; set; }
		public required string Message { get; set; }
		public required PaystackPaymentData Data { get; set; }
	}

	public class PaystackPaymentData
	{
		public required string AuthorizationUrl { get; set; }
		public required string AccessCode { get; set; }
		public required string Reference { get; set; }
	}
}