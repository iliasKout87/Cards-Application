using Cards.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Application.Features.Cards.Commands.CreateCard
{
	public class CreateCardDto
	{
		public Guid CardId { get; set; }

		public string Name { get; set; } = string.Empty;

		public string? Description { get; set; }

		public string? Color { get; set; }

		public CardStatus Status { get; set; }
	}
}
