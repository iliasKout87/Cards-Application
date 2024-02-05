using Cards.Domain.Common;
using Cards.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Domain.Entities
{
	public class Card : AuditableEntity
	{
		public Guid CardId { get; set; }

		public string Name { get; set; } = string.Empty;

		public string? Description { get; set; }

		public string? Color { get; set; }

		public CardStatus Status { get; set; } = CardStatus.ToDo;

		public Guid UserId { get; set; }

		public User User { get; set; } = default!;
	}
}
