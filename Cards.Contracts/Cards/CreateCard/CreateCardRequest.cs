namespace Cards.Contracts.Cards.CreateCard;

public record CreateCardRequest(
	string name,
	string description,
	string color);
