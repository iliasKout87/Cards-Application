using MediatR;

namespace Cards.Application.Features.Cards.Commands.DeleteMemberCard;

public record DeleteMemberCardCommand(Guid cardId, Guid userId) : IRequest;

