using FluentValidation;

namespace Cards.Application.Features.Cards.Commands.CreateCard
{
	public class CreateCardCommandValidator : AbstractValidator<CreateCardCommand>
	{
		private readonly string _hexColorRegex = "^#([A-Fa-f0-9]{6})$";

		public CreateCardCommandValidator()
		{
			RuleFor(p => p.name)
				.NotEmpty().WithMessage("{PropertyName} is required")
				.NotNull();

			When(p => !string.IsNullOrEmpty(p.color), () =>
			{
				RuleFor(p => p.color)
					.Matches(_hexColorRegex)
					.WithMessage("{PropertyName} should have a 6 alphanumeric characters prefixed with a # format");
			});
		}
	}
}
