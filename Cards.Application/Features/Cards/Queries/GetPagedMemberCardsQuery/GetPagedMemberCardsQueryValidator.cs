using FluentValidation;

namespace Cards.Application.Features.Cards.Queries.GetPagedMemberCardsQuery
{
	public class GetPagedMemberCardsQueryValidator : AbstractValidator<GetPagedMemberCardsQuery>
	{
		public GetPagedMemberCardsQueryValidator()
		{
			RuleFor(p => p.userId)
				.NotEmpty().WithMessage("{PropertyName} is required")
				.NotNull();
		}
	}
}
