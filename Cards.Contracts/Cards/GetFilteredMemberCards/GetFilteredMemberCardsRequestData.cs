using Cards.Application.Models.Cards;

namespace Cards.Contracts.Cards.GetFilteredMemberCards;

public record GetFilteredMemberCardsRequestData(Guid userId, string? searchTerm, CardSortColumn? sortBy, string? sortOrder, int? page, int? size);
