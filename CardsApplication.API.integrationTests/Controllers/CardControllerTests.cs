using Cards.Application.Features.Cards.Queries.GetCardsListQuery;
using CardsApplication.API.integrationTests.Base;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Text.Json;

namespace CardsApplication.API.integrationTests.Controllers
{
	public class CardControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
	{
		private readonly CustomWebApplicationFactory<Program> _factory;

		public CardControllerTests(CustomWebApplicationFactory<Program> factory)
		{
			_factory = factory;
		}

		[Fact]
		public async Task ReturnsSuccessResult()
		{
			var client = _factory.GetAnonymousClient();

			var response = await client.GetAsync("/api/cards");

			response.EnsureSuccessStatusCode();

			var responseString = await response.Content.ReadAsStringAsync();

			var result = JsonSerializer.Deserialize<List<CardsListVm>>(responseString);

			Assert.IsType<List<CardsListVm>>(result);
			Assert.NotEmpty(result);
		}
	}
}
