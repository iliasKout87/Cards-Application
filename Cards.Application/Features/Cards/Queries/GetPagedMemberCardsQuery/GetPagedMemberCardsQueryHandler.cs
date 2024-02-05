using AutoMapper;
using Cards.Application.Contracts.Persistence;
using Cards.Application.Exceptions;
using Cards.Application.Features.Cards.Queries.GetMemberCardQuery;
using Cards.Application.Features.Cards.Queries.GetMemberCardsListQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Application.Features.Cards.Queries.GetPagedMemberCardsQuery
{
	public class GetPagedMemberCardsQueryHandler : IRequestHandler<GetPagedMemberCardsQuery, GetPagedMemberCardsQueryResponse>
	{
		private readonly ICardRepository _cardRepository;
		private readonly IMapper _mapper;

		public GetPagedMemberCardsQueryHandler(ICardRepository cardRepository, IMapper mapper)
		{
			_cardRepository = cardRepository;
			_mapper = mapper;
		}

		public async Task<GetPagedMemberCardsQueryResponse> Handle(GetPagedMemberCardsQuery request, CancellationToken cancellationToken)
		{
			var validator = new GetPagedMemberCardsQueryValidator();
			var validationResult = await validator.ValidateAsync(request);

			if (validationResult.Errors.Count > 0)
				throw new ValidationException(validationResult);

			var memberCards = await _cardRepository.GetPagedMemberCardsAsync(request.userId, request.searchTerm, request.sortBy, request.sortOrder, request.page, request.size);
			var memberCardsVms = _mapper.Map<List<MemberCardVm>>(memberCards);

			var count = await _cardRepository.GetTotalCountOfFilteredMemberCardsAsync(request.userId, request.searchTerm);
			return new GetPagedMemberCardsQueryResponse(count, request.page, request.size, memberCardsVms);
		}
	}
}
