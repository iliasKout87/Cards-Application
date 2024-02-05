using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Application.Features.Cards.Queries.GetCardsListQuery;

public record GetCardsListQueryResponse(IEnumerable<CardsListVm>? cards);