namespace Cards.Contracts.Cards.CreateCard;

public record CreateCardRequestData(
	Guid userId,
	string name,
	string description,
	string color);