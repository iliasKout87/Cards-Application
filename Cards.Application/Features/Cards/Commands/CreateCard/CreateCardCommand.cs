using Cards.Application.Features.Cards.Commands.CreateCard;
using MediatR;

namespace Cards.Application.Features.Cards.Commands.CreateCard;

public record CreateCardCommand(Guid userId, string name, string description, string color) : IRequest<CreateCardCommandResponse>;
