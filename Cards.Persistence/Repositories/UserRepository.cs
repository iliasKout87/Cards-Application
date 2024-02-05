using Cards.Application.Contracts.Persistence;
using Cards.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cards.Persistence.Repositories
{
	public class UserRepository : BaseRepository<User>, IUserRepository
	{
		public UserRepository(CardsDbContext dbContext) : base(dbContext)
		{
		}

		public async Task<User?> GetUserByEmail(string email)
		{
			return await _dbContext.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
		}
	}
}
