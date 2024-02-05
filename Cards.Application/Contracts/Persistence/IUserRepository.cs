using Cards.Domain.Entities;

namespace Cards.Application.Contracts.Persistence
{
	public interface IUserRepository : IAsyncRepository<User>
	{
		Task<User?> GetUserByEmail(string email);
	}
}
