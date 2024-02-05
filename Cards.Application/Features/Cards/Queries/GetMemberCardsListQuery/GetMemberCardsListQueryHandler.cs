using AutoMapper;
using Cards.Application.Contracts.Persistence;
using Cards.Application.Exceptions;
using Cards.Application.Features.Authentication.Commands;
using Cards.Application.Features.Cards.Commands.CreateCard;
using MediatR;

namespace Cards.Application.Features.Cards.Queries.GetMemberCardsListQuery
{
	public class GetMemberCardsListQueryHandler : IRequestHandler<GetMemberCardsListQuery, GetMemberCardsListQueryResponse>
	{
		private readonly ICardRepository _cardRepository;
		private readonly IMapper _mapper;

		public GetMemberCardsListQueryHandler(ICardRepository cardRepository, IMapper mapper)
		{
			_cardRepository = cardRepository;
			_mapper = mapper;
		}

		public async Task<GetMemberCardsListQueryResponse> Handle(GetMemberCardsListQuery request, CancellationToken cancellationToken)
		{
			var validator = new GetMemberCardsListQueryValidator();
			var validationResult = await validator.ValidateAsync(request);

			if (validationResult.Errors.Count > 0)
				throw new ValidationException(validationResult);

			var memberCards = await _cardRepository.GetMemberCardsAsync(request.UserId);
			var memberCardsVms = _mapper.Map<List<MemberCardsListVm>>(memberCards);

			return new GetMemberCardsListQueryResponse(memberCardsVms);
		}
	}
}
