using Cards.Domain.Enums;

namespace Cards.Contracts.Cards.UpdateCard;
public record UpdateCardRequest(
	string name,
	string description,
	string color,
	CardStatus Status);

