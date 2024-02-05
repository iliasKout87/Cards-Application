using AutoMapper;
using Cards.API.Services;
using Cards.Application.Features.Cards.Queries.GetCardsListQuery;
using Cards.Application.Features.Cards.Queries.GetMemberCardsListQuery;
using Cards.Contracts.Cards.GetCard;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cards.API.Controllers
{
    [ApiController]
	[Authorize(Roles = "Administrator")]
	[Route("/admin")]
	public class AdministratorController : ControllerBase
	{
		private readonly ISender _mediator;
		private readonly IMapper _mapper;

		public AdministratorController(IMediator mediator, IMapper mapper)
		{
			_mediator = mediator;
			_mapper = mapper;
		}

		[HttpGet("cards")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult<GetCardsResponse>> GetCards()
		{
			var result = await _mediator.Send(new GetCardsListQuery());
			var response = _mapper.Map<GetCardsResponse>(result);

			return Ok(response);
		}
	}
}
