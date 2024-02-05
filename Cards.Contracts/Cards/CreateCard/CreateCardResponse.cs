using Cards.Domain.Enums;

namespace Cards.Contracts.Cards.CreateCard;

public record CreateCardResponse(string name, string description, string color, CardStatus status);
