using Cards.Application.Responses;
using Cards.Domain.Entities;

namespace Cards.Application.Features.Authentication.Commands;

public record RegisterCommandResponse(User user, string token);


