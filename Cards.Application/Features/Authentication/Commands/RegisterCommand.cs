using MediatR;

namespace Cards.Application.Features.Authentication.Commands;

public record RegisterCommand(
	string email,
	string password,
	string role) : IRequest<RegisterCommandResponse>;
