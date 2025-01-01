using Microsoft.AspNetCore.Mvc;
using QuickProFixer.DTOs;
using QuickProFixer.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuickProFixer.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class QuoteController : ControllerBase
	{
		private readonly IQuoteService _quoteService;

		public QuoteController(IQuoteService quoteService)
		{
			_quoteService = quoteService;
		}

		[HttpPost]
		public async Task<ActionResult<QuoteDto>> CreateQuote([FromBody] QuoteDto quoteDto)
		{
			var createdQuote = await _quoteService.CreateQuoteAsync(quoteDto);
			if (createdQuote == null)
			{
				return BadRequest("Unable to create quote.");
			}
			return CreatedAtAction(nameof(GetQuoteById), new { id = createdQuote.Id }, createdQuote);
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<QuoteDto>>> GetAllQuotes([FromQuery] string fixerId)
		{
			var quotes = await _quoteService.GetAllQuotesForFixerAsync(fixerId);
			if (quotes == null)
			{
				return NotFound("No quotes found for the specified fixer.");
			}
			return Ok(quotes);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<QuoteDto>> GetQuoteById(int id)
		{
			var quote = await _quoteService.GetQuoteByIdAsync(id);
			if (quote == null)
			{
				return NotFound("Quote not found.");
			}
			return Ok(quote);
		}
	}
}
