namespace Cards.Contracts.Authentication;

public record LoginResponse(
		Guid userId,
		string email,
		string role,
		string token);
