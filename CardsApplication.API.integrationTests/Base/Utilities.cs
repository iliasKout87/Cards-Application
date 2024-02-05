using Cards.Domain.Entities;
using Cards.Persistence;

namespace CardsApplication.API.integrationTests.Base
{
	public class Utilities
	{
		public static void InitializeDbForTests(CardsDbContext context)
		{

			context.Cards.Add(new Card
			{
				CardId = Guid.Parse("{ffe76276-7521-46b8-9b94-29fe8ddd77c1}"),
				Name = "Clean the house",
				Color = "#ff5733"
			});
			context.Cards.Add(new Card
			{
				CardId = Guid.Parse("{02b83720-acca-4296-8eaa-3c00be9a39cf}"),
				Name = "Wash the bathroom",
				Color = "#ff5733"
			});

			context.SaveChanges();
		}
	}
}
