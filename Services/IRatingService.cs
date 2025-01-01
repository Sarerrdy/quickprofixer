// File: Services/IRatingService.cs
using QuickProFixer.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuickProFixer.Services
{
	public interface IRatingService
	{
		Task<FixerRatingDto?> SubmitFixerRatingAsync(FixerRatingDto fixerRatingDto);
		Task<ClientRatingDto?> SubmitClientRatingAsync(ClientRatingDto clientRatingDto);
		Task<IEnumerable<FixerRatingDto>> GetFixerRatingsAsync(string fixerId);
		Task<IEnumerable<ClientRatingDto>> GetClientRatingsAsync(string clientId);
	}
}