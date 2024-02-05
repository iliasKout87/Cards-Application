using Cards.Persistence;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CardsApplication.API.integrationTests.Base
{
	public class CustomWebApplicationFactory<TProgram>
			: WebApplicationFactory<TProgram> where TProgram : class
	{
		protected override void ConfigureWebHost(IWebHostBuilder builder)
		{
			builder.ConfigureServices(services =>
			{

				services.AddDbContext<CardsDbContext>(options =>
				{
					options.UseInMemoryDatabase("CardsDbContextInMemoryTest");
				});

				var sp = services.BuildServiceProvider();

				using (var scope = sp.CreateScope())
				{
					var scopedServices = scope.ServiceProvider;
					var context = scopedServices.GetRequiredService<CardsDbContext>();
					var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TProgram>>>();

					context.Database.EnsureCreated();

					try
					{
						Utilities.InitializeDbForTests(context);
					}
					catch (Exception ex)
					{
						logger.LogError(ex, $"An error occurred seeding the database with test messages. Error: {ex.Message}");
					}
				};
			});
		}

		public HttpClient GetAnonymousClient()
		{
			return CreateClient();
		}
	}
}
