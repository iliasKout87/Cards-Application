using AutoMapper;
using Cards.Application.Contracts.Persistence;
using Cards.Application.Exceptions;
using Cards.Application.Features.Cards.Commands.UpdateMemberCard;
using Cards.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Application.Features.Cards.Commands.DeleteMemberCard
{
	public class DeleteMemberCardCommandHandler : IRequestHandler<DeleteMemberCardCommand>
	{
		private readonly IMapper _mapper;
		private readonly ICardRepository _cardRepository;

		public DeleteMemberCardCommandHandler(
			IMapper mapper,
			ICardRepository cardRepository
			)
		{
			_mapper = mapper;
			_cardRepository = cardRepository;
		}

		public async Task Handle(DeleteMemberCardCommand request, CancellationToken cancellationToken)
		{
			var validator = new DeleteMemberCardCommandValidator();
			var validationResult = await validator.ValidateAsync(request);

			if (validationResult.Errors.Count > 0)
				throw new ValidationException(validationResult);

			var cardToDelete = await _cardRepository.GetMemberCardByIdAsync(request.userId, request.cardId);

			if (cardToDelete == null)
			{
				throw new NotFoundException(nameof(Card), request.cardId);
			}

			await _cardRepository.DeleteAsync(cardToDelete);
		}
	}
}
