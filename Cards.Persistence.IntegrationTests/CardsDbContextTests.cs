using Cards.Application.Contracts;
using Cards.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;

namespace Cards.Persistence.IntegrationTests
{
	public class CardsDbContextTests
	{
		private readonly CardsDbContext _cardsDbContext;
		private readonly Mock<ILoggedInUserService> _loggedInUserServiceMock;
		private readonly string _loggedInUserId;

		public CardsDbContextTests()
		{
			var dbContextOptions = new DbContextOptionsBuilder<CardsDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

			_loggedInUserId = "00000000-0000-0000-0000-000000000000";
			_loggedInUserServiceMock = new Mock<ILoggedInUserService>();
			_loggedInUserServiceMock.Setup(m => m.UserId).Returns(_loggedInUserId);

			//_cardsDbContext = new CardsDbContext(dbContextOptions, _loggedInUserServiceMock.Object);
		}

		[Fact]
		public async void Save_SetCreatedByProperty()
		{
			var card = new Card() { CardId = Guid.NewGuid(), Name = "Test card" };

			_cardsDbContext.Cards.Add(card);
			await _cardsDbContext.SaveChangesAsync();

			card.CreatedBy.ShouldBe(_loggedInUserId);
		}
	}
}
