using MediatR;

namespace Cards.Application.Features.Cards.Queries.GetMemberCardQuery;

public record GetMemberCardQuery(Guid memberId, Guid cardId) : IRequest<GetMemberCardQueryResponse>;

