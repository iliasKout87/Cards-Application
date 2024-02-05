using Cards.Domain.Enums;

namespace Cards.Contracts.Cards.UpdateCard;

public record UpdateCardRequestData(
	Guid userId,
	Guid cardId,
	string name,
	string description,
	string color,
	CardStatus status);
