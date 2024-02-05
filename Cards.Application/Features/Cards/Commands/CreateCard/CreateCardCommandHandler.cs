using AutoMapper;
using Cards.Application.Contracts.Infrastructure;
using Cards.Application.Contracts.Persistence;
using Cards.Application.Models.Mail;
using Cards.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cards.Application.Features.Cards.Commands.CreateCard
{
	public class CreateCardCommandHandler : IRequestHandler<CreateCardCommand, CreateCardCommandResponse>
	{
		private readonly IMapper _mapper;
		private readonly ICardRepository _cardRepository;
		private readonly IEmailService _emailService;
		private readonly ILogger<CreateCardCommandHandler> _logger;

		public CreateCardCommandHandler(
			IMapper mapper,
			ICardRepository cardRepository,
			IEmailService emailService,
			ILogger<CreateCardCommandHandler> logger)
		{
			_mapper = mapper;
			_cardRepository = cardRepository;
			_emailService = emailService;
			_logger = logger;
		}

		public async Task<CreateCardCommandResponse> Handle(CreateCardCommand request, CancellationToken cancellationToken)
		{
			var validator = new CreateCardCommandValidator();
			var validationResult = await validator.ValidateAsync(request);

			if (validationResult.Errors.Count > 0)
				throw new Exceptions.ValidationException(validationResult);

			var card = _mapper.Map<Card>(request);
			card = await _cardRepository.AddAsync(card);
			var cardDto = _mapper.Map<CreateCardDto>(card);

			var email = new Email()
			{
				To = "koutlasilias@gmail.com",
				Body = $"A new card was created: {request}",
				Subject = "A new card was created"
			};

			try
			{
				await _emailService.SendEmailAsync(email);
			}
			catch (Exception ex)
			{
				//this shouldn't stop the API so this can be logged
				_logger.LogError($"Mailing about card {card.CardId} failed due to an error with the mail service: {ex.Message}");
			}

			return new CreateCardCommandResponse(cardDto);
		}
	}
}
