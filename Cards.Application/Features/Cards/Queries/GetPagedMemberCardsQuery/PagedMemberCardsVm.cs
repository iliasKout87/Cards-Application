using Cards.Application.Features.Cards.Queries.GetMemberCardQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Application.Features.Cards.Queries.GetPagedMemberCardsQuery
{
	public class PagedMemberCardsVm
	{
		public int Count { get; set; }
		public int Page { get; set; }
		public int Size { get; set; }
		public IEnumerable<MemberCardVm>? MemberCards { get; set; }
	}
}
