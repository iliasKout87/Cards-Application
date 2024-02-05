using Cards.Application.Contracts.Identity;
using Cards.Application.Contracts.Persistence;
using Cards.Application.Exceptions;
using Cards.Application.Features.Cards.Commands.CreateCard;
using Cards.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Application.Features.Authentication.Commands
{
	public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterCommandResponse>
	{
		private readonly IJwtTokenGenerator _jwtTokenGenerator;
		private readonly IUserRepository _userRepository;

		public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
		{
			_userRepository = userRepository;
			_jwtTokenGenerator = jwtTokenGenerator;
		}

		public async Task<RegisterCommandResponse> Handle(RegisterCommand command, CancellationToken cancellationToken)
		{
			var validator = new RegisterCommandValidator();
			var validationResult = await validator.ValidateAsync(command);

			if (validationResult.Errors.Count > 0)
				throw new ValidationException(validationResult);

			//Check if user exists
			if (await _userRepository.GetUserByEmail(command.email) is not null)
			{
				throw new DuplicateEmailException(command.email);
			}

			var user = new User
			{
				Email = command.email,
				Password = command.password,
				Role = command.role
			};

			await _userRepository.AddAsync(user);

			var token = _jwtTokenGenerator.GenerateToken(user);

			return new RegisterCommandResponse(user, token);
		}
	}
}
