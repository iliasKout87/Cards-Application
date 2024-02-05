using AutoMapper;
using Cards.Application.Contracts.Persistence;
using Cards.Application.Exceptions;
using Cards.Domain.Entities;
using MediatR;

namespace Cards.Application.Features.Cards.Commands.UpdateMemberCard
{
	public class UpdateMemberCardCommandHandler : IRequestHandler<UpdateMemberCardCommand>
	{
		private readonly IMapper _mapper;
		private readonly ICardRepository _cardRepository;

		public UpdateMemberCardCommandHandler(
			IMapper mapper,
			ICardRepository cardRepository
			)
		{
			_mapper = mapper;
			_cardRepository = cardRepository;
		}

		public async Task Handle(UpdateMemberCardCommand request, CancellationToken cancellationToken)
		{
			var validator = new UpdateMemberCardCommandValidator();
			var validationResult = await validator.ValidateAsync(request);

			if (validationResult.Errors.Count > 0)
				throw new ValidationException(validationResult);

			var cardToUpdate = await _cardRepository.GetMemberCardByIdAsync(request.userId, request.cardId);

			if (cardToUpdate == null)
			{
				throw new NotFoundException(nameof(Card), request.cardId);
			}

			_mapper.Map(request, cardToUpdate, typeof(UpdateMemberCardCommand), typeof(Card));

			await _cardRepository.UpdateAsync(cardToUpdate);
		}
	}
}
