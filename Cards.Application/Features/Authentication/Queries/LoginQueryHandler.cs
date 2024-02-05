using Cards.Application.Contracts.Identity;
using Cards.Application.Contracts.Persistence;
using Cards.Application.Exceptions;
using Cards.Domain.Entities;
using MediatR;

namespace Cards.Application.Features.Authentication.Queries
{
	public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginQueryResponse>
	{
		private readonly IJwtTokenGenerator _jwtTokenGenerator;
		private readonly IUserRepository _userRepository;

		public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
		{
			_userRepository = userRepository;
			_jwtTokenGenerator = jwtTokenGenerator;
		}

		public async Task<LoginQueryResponse> Handle(LoginQuery query, CancellationToken cancellationToken)
		{
			if (await _userRepository.GetUserByEmail(query.Email) is not User user)
			{
				throw new InvalidUserException();
			}


			if (user.Password != query.Password)
			{
				throw new InvalidPasswordException();
			}

			var token = _jwtTokenGenerator.GenerateToken(user);

			return new LoginQueryResponse(user, token);
		}
	}
}
