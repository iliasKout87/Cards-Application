using AutoMapper;
using Cards.API.Services;
using Cards.Application.Features.Cards.Commands.CreateCard;
using Cards.Application.Features.Cards.Commands.DeleteMemberCard;
using Cards.Application.Features.Cards.Commands.UpdateMemberCard;
using Cards.Application.Features.Cards.Queries.GetMemberCardQuery;
using Cards.Application.Features.Cards.Queries.GetMemberCardsListQuery;
using Cards.Application.Features.Cards.Queries.GetPagedMemberCardsQuery;
using Cards.Application.Models.Cards;
using Cards.Contracts.Cards.CreateCard;
using Cards.Contracts.Cards.GetCard;
using Cards.Contracts.Cards.GetFilteredMemberCards;
using Cards.Contracts.Cards.UpdateCard;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cards.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(Roles = "Member")]
	public class CardsController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly JwtService _jwtService;
		private readonly IMapper _mapper;

		public CardsController(IMediator mediator, JwtService jwtService, IMapper mapper)
		{
			_mediator = mediator;
			_jwtService = jwtService;
			_mapper = mapper;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult<GetCardsResponse>> Get()
		{
			Guid userId = _jwtService.ExtractUserId();
			var result = await _mediator.Send(new GetMemberCardsListQuery(userId));
			var response = _mapper.Map<GetCardsResponse>(result);

			return Ok(response);
		}

		[HttpGet("filtered")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult<GetCardsResponse>> Get(string? searchTerm, CardSortColumn? cardSortColumn, string? sortOrder, int? page, int? size)
		{
			Guid userId = _jwtService.ExtractUserId();
			var requestData = new GetFilteredMemberCardsRequestData(userId, searchTerm, cardSortColumn, sortOrder, page, size);
			var query = _mapper.Map<GetPagedMemberCardsQuery>(requestData);
			var result = await _mediator.Send(query);

			var response = _mapper.Map<GetFilteredMemberCardsResponse>(result);

			return Ok(response);
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult<GetCardResponse>> Get(Guid id)
		{
			Guid userId = _jwtService.ExtractUserId();
			var result = await _mediator.Send(new GetMemberCardQuery(userId, id));
			var response = _mapper.Map<GetCardResponse>(result);

			return Ok(response);
		}

		[HttpPost]
		public async Task<ActionResult<CreateCardCommandResponse>> Create(CreateCardRequest createCardRequest)
		{
			Guid userId = _jwtService.ExtractUserId();
			var requestData = new CreateCardRequestData(userId, createCardRequest.name, createCardRequest.description, createCardRequest.color);
			var command = _mapper.Map<CreateCardCommand>(requestData);
			var result = await _mediator.Send(command);

			var response = _mapper.Map<CreateCardResponse>(result);

			return Ok(response);
		}

		[HttpPut("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult> Update(Guid id, UpdateCardRequest updateCardRequest)
		{
			Guid userId = _jwtService.ExtractUserId();
			var requestData = new UpdateCardRequestData(userId, id, updateCardRequest.name, updateCardRequest.description,
				updateCardRequest.color, updateCardRequest.Status);
			var command = _mapper.Map<UpdateMemberCardCommand>(requestData);
			await _mediator.Send(command);
			return NoContent();
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult> Delete(Guid id)
		{
			Guid userId = _jwtService.ExtractUserId();
			var deleteCardCommand = new DeleteMemberCardCommand(id, userId);
			await _mediator.Send(deleteCardCommand);
			return NoContent();
		}
	}
}
