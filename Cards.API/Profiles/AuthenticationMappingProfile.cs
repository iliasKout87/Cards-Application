using AutoMapper;
using Cards.Application.Features.Authentication.Commands;
using Cards.Application.Features.Authentication.Queries;
using Cards.Contracts.Authentication;

namespace Cards.API.Profiles
{
	public class AuthenticationMappingProfile : Profile
	{
		public AuthenticationMappingProfile()
		{
			CreateMap<LoginRequest, LoginQuery>();
			CreateMap<RegisterRequest, RegisterCommand>();
			CreateMap<LoginQueryResponse, LoginResponse>()
				.ForCtorParam(nameof(LoginResponse.userId), options => options.MapFrom(source => source.user.UserId))
				.ForCtorParam(nameof(LoginResponse.email), options => options.MapFrom(source => source.user.Email))
				.ForCtorParam(nameof(LoginResponse.role), options => options.MapFrom(source => source.user.Role))
				.ForCtorParam(nameof(LoginResponse.token), options => options.MapFrom(source => source.token))
				.ForAllMembers(options => options.Ignore());
			CreateMap<RegisterCommandResponse, RegisterResponse>()
				.ForCtorParam(nameof(RegisterResponse.userId), options => options.MapFrom(source => source.user.UserId))
				.ForCtorParam(nameof(RegisterResponse.email), options => options.MapFrom(source => source.user.Email))
				.ForCtorParam(nameof(RegisterResponse.role), options => options.MapFrom(source => source.user.Role))
				.ForCtorParam(nameof(RegisterResponse.token), options => options.MapFrom(source => source.token))
				.ForAllMembers(options => options.Ignore());
		}
	}
}
