using Cards.Application.Features.Cards.Commands.CreateCard;
using FluentValidation;

namespace Cards.Application.Features.Cards.Queries.GetMemberCardsListQuery
{
	public class GetMemberCardsListQueryValidator : AbstractValidator<GetMemberCardsListQuery>
	{
		public GetMemberCardsListQueryValidator()
		{
			RuleFor(p => p.UserId)
				.NotEmpty().WithMessage("{PropertyName} is required")
				.NotNull();
		}
	}
}
