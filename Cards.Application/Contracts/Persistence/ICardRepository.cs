using Cards.Application.Models.Cards;
using Cards.Domain.Entities;

namespace Cards.Application.Contracts.Persistence
{
	public interface ICardRepository : IAsyncRepository<Card>
	{
		Task<IEnumerable<Card>> GetMemberCardsAsync(Guid memberId);

		Task<Card?> GetMemberCardByIdAsync(Guid userId, Guid cardId);

		Task<Card?> GetCardByIdAsync(Guid cardId);

		Task<IEnumerable<Card>> GetPagedMemberCardsAsync(Guid userId, string? searchTerm, CardSortColumn sortBy, string? sortOrder, int? page, int? size);

		Task<int> GetTotalCountOfFilteredMemberCardsAsync(Guid userId, string? searchTerm);
	}
}
