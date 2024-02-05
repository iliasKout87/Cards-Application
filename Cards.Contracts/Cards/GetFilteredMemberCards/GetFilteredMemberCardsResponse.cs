using Cards.Application.Features.Cards.Queries.GetMemberCardQuery;

namespace Cards.Contracts.Cards.GetFilteredMemberCards;

public record GetFilteredMemberCardsResponse(int count, int? page, int? size, IEnumerable<MemberCardVm> cards);
