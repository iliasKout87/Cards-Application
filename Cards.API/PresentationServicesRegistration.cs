using Cards.API.Services;
using Cards.Application.Contracts.Services;

namespace Cards.API
{
	public static class PresentationServicesRegistration
	{
		public static IServiceCollection AddPresentationServices(this IServiceCollection services)
		{
			services.AddControllers();
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddSingleton<IDatetimeProvider, DatetimeProvider>();
			services.AddTransient<JwtService>();

			return services;
		}
	}
}
