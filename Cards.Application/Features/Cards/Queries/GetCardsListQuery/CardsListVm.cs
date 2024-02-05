using Cards.Domain.Enums;

namespace Cards.Application.Features.Cards.Queries.GetCardsListQuery
{
	public class CardsListVm
	{
		public Guid CardId { get; set; }

		public string Name { get; set; } = string.Empty;

		public string? Description { get; set; }

		public string? Color { get; set; }

		public CardStatus Status { get; set; }
	}
}