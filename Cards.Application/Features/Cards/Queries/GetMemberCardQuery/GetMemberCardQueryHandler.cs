using AutoMapper;
using Cards.Application.Contracts.Persistence;
using Cards.Application.Exceptions;
using Cards.Application.Features.Cards.Commands.CreateCard;
using Cards.Domain.Entities;
using MediatR;

namespace Cards.Application.Features.Cards.Queries.GetMemberCardQuery
{
	public class GetMemberCardQueryHandler : IRequestHandler<GetMemberCardQuery, GetMemberCardQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly ICardRepository _cardRepository;

		public GetMemberCardQueryHandler(
			IMapper mapper, ICardRepository cardRepository)
		{
			_mapper = mapper;
			_cardRepository = cardRepository;
		}

		public async Task<GetMemberCardQueryResponse> Handle(GetMemberCardQuery request, CancellationToken cancellationToken)
		{
			var validator = new GetMemberCardQueryValidator();
			var validationResult = await validator.ValidateAsync(request);

			if (validationResult.Errors.Count > 0)
				throw new ValidationException(validationResult);

			var card = await _cardRepository.GetMemberCardByIdAsync(request.memberId, request.cardId);

			if (card == null)
			{
				throw new NotFoundException(nameof(Card), request.cardId);
			}

			var cardVm = _mapper.Map<MemberCardVm>(card);

			return new GetMemberCardQueryResponse(cardVm);
		}
	}
}
