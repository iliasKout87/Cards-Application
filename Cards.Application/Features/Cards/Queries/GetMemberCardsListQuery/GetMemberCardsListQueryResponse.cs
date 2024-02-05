using Cards.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Application.Features.Cards.Queries.GetMemberCardsListQuery;

public record GetMemberCardsListQueryResponse(IEnumerable<MemberCardsListVm>? memberCards);
