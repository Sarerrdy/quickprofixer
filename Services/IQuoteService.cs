using QuickProFixer.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuickProFixer.Services
{
	public interface IQuoteService
	{
		Task<QuoteDto?> CreateQuoteAsync(QuoteDto quoteDto);
		Task<IEnumerable<QuoteDto>> GetAllQuotesForFixerAsync(string fixerId);
		Task<QuoteDto?> GetQuoteByIdAsync(int id);
	}
}
