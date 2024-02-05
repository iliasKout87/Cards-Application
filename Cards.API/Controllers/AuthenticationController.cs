using AutoMapper;
using Cards.API.Services;
using Cards.Application.Features.Authentication.Commands;
using Cards.Application.Features.Authentication.Queries;
using Cards.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cards.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class AuthenticationController : ControllerBase
	{
		private readonly ISender _mediator;
		private readonly IMapper _mapper;

		public AuthenticationController(ISender mediator, IMapper mapper)
		{
			_mediator = mediator;
			_mapper = mapper;
		}

		[HttpPost("register")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status409Conflict)]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> Register(RegisterRequest request)
		{
			var command = _mapper.Map<RegisterCommand>(request);
			var registerResult = await _mediator.Send(command);

			var response = _mapper.Map<RegisterResponse>(registerResult);

			return Ok(response);
		}

		[HttpPost("login")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[AllowAnonymous]
		public async Task<IActionResult> Login(LoginRequest request)
		{
			var query = _mapper.Map<LoginQuery>(request);
			var loginResult = await _mediator.Send(query);

			var response = _mapper.Map<LoginResponse>(loginResult);

			return Ok(response);
		}
	}
}
