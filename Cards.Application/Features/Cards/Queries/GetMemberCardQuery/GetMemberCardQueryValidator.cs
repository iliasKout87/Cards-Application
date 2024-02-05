using FluentValidation;

namespace Cards.Application.Features.Cards.Queries.GetMemberCardQuery
{
	public class GetMemberCardQueryValidator : AbstractValidator<GetMemberCardQuery>
	{
		public GetMemberCardQueryValidator()
		{
			RuleFor(p => p.memberId)
				.NotEmpty().WithMessage("{PropertyName} is required")
				.NotNull();

			RuleFor(p => p.cardId)
				.NotEmpty().WithMessage("{PropertyName} is required")
				.NotNull();
		}
	}
}
