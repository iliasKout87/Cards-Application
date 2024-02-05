using FluentValidation;

namespace Cards.Application.Features.Cards.Commands.UpdateMemberCard
{
	public class UpdateMemberCardCommandValidator : AbstractValidator<UpdateMemberCardCommand>
	{
		private readonly string _hexColorRegex = "^#([A-Fa-f0-9]{6})$";

		public UpdateMemberCardCommandValidator()
		{
			RuleFor(p => p.cardId)
				.NotEmpty().WithMessage("{PropertyName} is required")
				.NotNull();

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
