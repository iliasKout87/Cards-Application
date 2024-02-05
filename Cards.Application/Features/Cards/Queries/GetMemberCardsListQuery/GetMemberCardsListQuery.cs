using Cards.Application.Features.Cards.Queries.GetMemberCardsListQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Application.Features.Cards.Queries.GetMemberCardsListQuery;

public record GetMemberCardsListQuery(Guid UserId) : IRequest<GetMemberCardsListQueryResponse>;
