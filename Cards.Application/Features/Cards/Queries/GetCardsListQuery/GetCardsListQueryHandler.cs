using AutoMapper;
using Cards.Application.Contracts.Persistence;
using Cards.Domain.Entities;
using MediatR;

namespace Cards.Application.Features.Cards.Queries.GetCardsListQuery
{
	public class GetCardsListQueryHandler : IRequestHandler<GetCardsListQuery, GetCardsListQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IAsyncRepository<Card> _cardRepository;

		public GetCardsListQueryHandler(
			IMapper mapper, IAsyncRepository<Card> cardRepository)
		{
			_mapper = mapper;
			_cardRepository = cardRepository;
		}

		public async Task<GetCardsListQueryResponse> Handle(GetCardsListQuery request, CancellationToken cancellationToken)
		{
			var allCards = await _cardRepository.GetAllAsync();
			var cardVms = _mapper.Map<List<CardsListVm>>(allCards);

			return new GetCardsListQueryResponse(cardVms);
		}
	}
}
