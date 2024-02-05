using Cards.Application.Features.Cards.Queries.GetMemberCardQuery;

namespace Cards.Application.Features.Cards.Queries.GetPagedMemberCardsQuery;

public record GetPagedMemberCardsQueryResponse(int count, int? page, int? size, IEnumerable<MemberCardVm> cards);
