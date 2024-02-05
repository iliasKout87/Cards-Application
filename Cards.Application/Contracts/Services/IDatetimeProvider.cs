namespace Cards.Application.Contracts.Services
{
	public interface IDatetimeProvider
	{
		DateTime UtcNow { get; }
	}
}
