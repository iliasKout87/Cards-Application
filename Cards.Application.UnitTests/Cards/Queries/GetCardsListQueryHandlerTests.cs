using AutoMapper;
using Cards.Application.Contracts.Persistence;
using Cards.Application.Features.Cards.Queries.GetCardsListQuery;
using Cards.Application.Profiles;
using Cards.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace Cards.Application.UnitTests.Cards.Queries
{
	public class GetCardsListQueryHandlerTests
	{
		private readonly IMapper _mapper;
		private readonly Mock<ICardRepository> _mockCardRepository;

		public GetCardsListQueryHandlerTests()
		{
			_mockCardRepository = RepositoryMocks.GetCardRepository();
			var configurationProvider = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<MappingProfile>();
			});

			_mapper = configurationProvider.CreateMapper();
		}

		[Fact]
		public async Task GetCardsListTest()
		{
			var handler = new GetCardsListQueryHandler(_mapper, _mockCardRepository.Object);

			var result = await handler.Handle(new GetCardsListQuery(), CancellationToken.None);

			result.ShouldBeOfType<List<CardsListVm>>();

			result.Count.ShouldBe(2);
		}
	}
}
