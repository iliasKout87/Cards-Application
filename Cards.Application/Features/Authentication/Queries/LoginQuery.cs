using MediatR;

namespace Cards.Application.Features.Authentication.Queries;

public record LoginQuery(
	string Email,
	string Password) : IRequest<LoginQueryResponse>;
