using FluentValidation;

namespace Cards.Application.Features.Cards.Commands.DeleteMemberCard
{
	public class DeleteMemberCardCommandValidator : AbstractValidator<DeleteMemberCardCommand>
	{
		private readonly string _hexColorRegex = "^#([A-Fa-f0-9]{6})$";

		public DeleteMemberCardCommandValidator()
		{
			RuleFor(p => p.cardId)
				.NotEmpty().WithMessage("{PropertyName} is required")
				.NotNull();

			RuleFor(p => p.userId)
				.NotEmpty().WithMessage("{PropertyName} is required")
				.NotNull();
		}
	}
}
