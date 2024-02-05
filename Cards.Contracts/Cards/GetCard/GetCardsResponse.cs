using Cards.Domain.Enums;

namespace Cards.Contracts.Cards.GetCard;

public record GetCardsResponse(
	List<CardsListResponse> Cards);

public record CardsListResponse(
	Guid cardId,
	string name,
	string color,
	string? description,
	CardStatus status);
