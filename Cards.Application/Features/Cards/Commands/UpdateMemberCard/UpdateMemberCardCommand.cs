using Cards.Domain.Enums;
using MediatR;

namespace Cards.Application.Features.Cards.Commands.UpdateMemberCard;

public record UpdateMemberCardCommand(Guid userId, Guid cardId, string name, string description, string color, CardStatus status) : IRequest;

