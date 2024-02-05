using Cards.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Application.Features.Cards.Queries.GetMemberCardsListQuery
{
	public class MemberCardsListVm
	{
		public Guid CardId { get; set; }

		public string Name { get; set; } = string.Empty;

		public string Color { get; set; } = string.Empty;

		public string? Description { get; set; }

		public CardStatus Status { get; set; }
	}
}
