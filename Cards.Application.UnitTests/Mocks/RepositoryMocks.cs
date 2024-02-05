using Cards.Application.Contracts.Persistence;
using Cards.Application.Features.Cards.Queries.GetCardsQuery;
using Cards.Domain.Entities;
using EmptyFiles;
using Moq;
using System.Drawing;
using System.Xml.Linq;

namespace Cards.Application.UnitTests.Mocks
{
	public static class RepositoryMocks
	{
		public static Mock<ICardRepository> GetCardRepository()
		{
			var cards = new List<Card>
			{
				new Card {
					CardId = Guid.Parse("{ffe76276-7521-46b8-9b94-29fe8ddd77c1}"),
					Name = "Clean the house",
					Color = "#ff5733"
				},
				new Card {
					CardId = Guid.Parse("{02b83720-acca-4296-8eaa-3c00be9a39cf}"),
					Name = "Wash the bathroom",
					Color = "#ff5733"
				}
			};

			var mockCardRepository = new Mock<ICardRepository>();
			mockCardRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(cards);

			mockCardRepository.Setup(repo => repo.AddAsync(It.IsAny<Card>())).ReturnsAsync(
				(Card card) =>
				{
					cards.Add(card);
					return card;
				});

			return mockCardRepository;
		}
	}
}
