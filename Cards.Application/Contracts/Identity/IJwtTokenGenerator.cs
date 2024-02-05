using Cards.Domain.Entities;

namespace Cards.Application.Contracts.Identity
{
	public interface IJwtTokenGenerator
	{
		string GenerateToken(User user);
	}
}
