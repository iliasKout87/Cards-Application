using Cards.Application.Contracts.Services;

namespace Cards.API.Services
{
	public class DatetimeProvider : IDatetimeProvider
	{
		public DateTime UtcNow => DateTime.UtcNow;
	}
}
