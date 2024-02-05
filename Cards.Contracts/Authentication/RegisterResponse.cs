namespace Cards.Contracts.Authentication;

public record RegisterResponse(
		Guid userId,
		string email,
		string role,
		string token);
