using Cards.Application.Contracts.Persistence;
using Cards.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cards.Persistence
{
	public static class PersistenceServiceRegistration
	{
		public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<CardsDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("CardsDbConnectionString")));

			services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
			services.AddScoped<ICardRepository, CardRepository>();
			services.AddScoped<IUserRepository, UserRepository>();

			return services;
		}
	}
}
