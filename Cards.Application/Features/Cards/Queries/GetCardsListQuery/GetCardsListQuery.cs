using MediatR;

namespace Cards.Application.Features.Cards.Queries.GetCardsListQuery;

public record GetCardsListQuery() : IRequest<GetCardsListQueryResponse>;

