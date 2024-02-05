using Cards.Application.Features.Cards.Commands.CreateCard;
using FluentValidation;

namespace Cards.Application.Features.Authentication.Commands
{
	public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
	{
		public RegisterCommandValidator()
		{
			RuleFor(p => p.email)
				.EmailAddress().WithMessage("{PropertyValue} is not a valid email");

			RuleFor(p => p.password)
				.NotNull().WithMessage("{PropertyName} is required")
				.MinimumLength(5).WithMessage("{PropertyName} must be at least {MinLength} characters long");

			RuleFor(p => p.role)
				.Must(IsAllowedRole).WithMessage("Role {PropertyValue} does not exist");
		}

		private bool IsAllowedRole(string role)
		{
			var allowedRoles = new HashSet<string>()
			{
				"Administrator",
				"Member"
			};

			return allowedRoles.Contains(role);
		}
	}
}
