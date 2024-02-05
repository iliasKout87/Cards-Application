using AutoMapper;
using Cards.Application.Features.Cards.Commands.CreateCard;
using Cards.Application.Features.Cards.Commands.UpdateMemberCard;
using Cards.Application.Features.Cards.Queries.GetMemberCardQuery;
using Cards.Application.Features.Cards.Queries.GetCardsListQuery;
using Cards.Application.Features.Cards.Queries.GetMemberCardsListQuery;
using Cards.Domain.Entities;

namespace Cards.Application.Profiles
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Card, CardsListVm>().ReverseMap();
			CreateMap<Card, CreateCardCommand>().ReverseMap();
			CreateMap<Card, UpdateMemberCardCommand>().ReverseMap();
			CreateMap<Card, CreateCardDto>().ReverseMap();
			CreateMap<Card, MemberCardsListVm>().ReverseMap();
			CreateMap<Card, MemberCardVm>().ReverseMap();
		}
	}
}
