using Cards.Application.Models.Cards;
using MediatR;

namespace Cards.Application.Features.Cards.Queries.GetPagedMemberCardsQuery;

public record GetPagedMemberCardsQuery(Guid userId, string? searchTerm, CardSortColumn sortBy, string? sortOrder, int? page, int? size) : IRequest<GetPagedMemberCardsQueryResponse>;

