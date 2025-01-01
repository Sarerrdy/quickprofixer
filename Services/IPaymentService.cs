// File: Services/IPaymentService.cs
using QuickProFixer.DTOs;
using System.Threading.Tasks;

namespace QuickProFixer.Services
{
	public interface IPaymentService
	{
		Task<PaymentDto?> ProcessPaymentAsync(PaymentDto paymentDto);
		// Task<PaymentDto?> CompletePaymentAsync(int paymentId);
		Task<PaymentDto?> CompleteFixerPaymentAsync(int paymentId);
		Task<PaymentDto?> CompleteClientPaymentAsync(int paymentId);
		Task<PaymentDto?> RefundPaymentAsync(int paymentId);
		Task<InvoiceDto?> GenerateInvoiceAsync(int bookingId);
	}
}