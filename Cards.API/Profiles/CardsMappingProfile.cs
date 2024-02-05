using AutoMapper;
using Cards.Application.Features.Cards.Commands.CreateCard;
using Cards.Application.Features.Cards.Queries.GetMemberCardQuery;
using Cards.Application.Features.Cards.Queries.GetCardsListQuery;
using Cards.Application.Features.Cards.Queries.GetMemberCardsListQuery;
using Cards.Contracts.Authentication;
using Cards.Contracts.Cards.CreateCard;
using Cards.Contracts.Cards.GetCard;
using Cards.Contracts.Cards.UpdateCard;
using Cards.Application.Features.Cards.Commands.UpdateMemberCard;
using Cards.Contracts.Cards.GetFilteredMemberCards;
using Cards.Application.Features.Cards.Queries.GetPagedMemberCardsQuery;

namespace Cards.API.Profiles
{
	public class CardsMappingProfile : Profile
	{
		public CardsMappingProfile()
		{
			CreateMap<GetMemberCardsListQueryResponse, GetCardsResponse>()
			   .ForCtorParam(nameof(GetCardsResponse.Cards), options => options.MapFrom(source => source.memberCards))
			   .ForAllMembers(options => options.Ignore());
			CreateMap<MemberCardsListVm, CardsListResponse>()
				.ForCtorParam(nameof(CardsListResponse.cardId), options => options.MapFrom(source => source.CardId))
				.ForCtorParam(nameof(CardsListResponse.name), options => options.MapFrom(source => source.Name))
				.ForCtorParam(nameof(CardsListResponse.color), options => options.MapFrom(source => source.Color))
				.ForCtorParam(nameof(CardsListResponse.description), options => options.MapFrom(source => source.Description))
				.ForCtorParam(nameof(CardsListResponse.status), options => options.MapFrom(source => source.Status))
				.ForAllMembers(options => options.Ignore());
			CreateMap<GetMemberCardQueryResponse, GetCardResponse>()
				.ForCtorParam(nameof(GetCardResponse.cardId), options => options.MapFrom(source => source.card.CardId))
				.ForCtorParam(nameof(GetCardResponse.name), options => options.MapFrom(source => source.card.Name))
				.ForCtorParam(nameof(GetCardResponse.color), options => options.MapFrom(source => source.card.Color))
				.ForCtorParam(nameof(GetCardResponse.description), options => options.MapFrom(source => source.card.Description))
				.ForCtorParam(nameof(GetCardResponse.status), options => options.MapFrom(source => source.card.Status))
				.ForAllMembers(options => options.Ignore());
			CreateMap<GetCardsListQueryResponse, GetCardsResponse>()
			   .ForCtorParam(nameof(GetCardsResponse.Cards), options => options.MapFrom(source => source.cards))
			   .ForAllMembers(options => options.Ignore());
			CreateMap<CardsListVm, CardsListResponse>()
				.ForCtorParam(nameof(CardsListResponse.cardId), options => options.MapFrom(source => source.CardId))
				.ForCtorParam(nameof(CardsListResponse.name), options => options.MapFrom(source => source.Name))
				.ForCtorParam(nameof(CardsListResponse.color), options => options.MapFrom(source => source.Color))
				.ForCtorParam(nameof(CardsListResponse.description), options => options.MapFrom(source => source.Description))
				.ForCtorParam(nameof(CardsListResponse.status), options => options.MapFrom(source => source.Status))
				.ForAllMembers(options => options.Ignore());
			CreateMap<CreateCardRequestData, CreateCardCommand>();
			CreateMap<CreateCardCommandResponse, CreateCardResponse>()
				.ForCtorParam(nameof(CreateCardResponse.name), options => options.MapFrom(source => source.Card.Name))
				.ForCtorParam(nameof(CreateCardResponse.color), options => options.MapFrom(source => source.Card.Color))
				.ForCtorParam(nameof(CreateCardResponse.description), options => options.MapFrom(source => source.Card.Description))
				.ForCtorParam(nameof(CreateCardResponse.status), options => options.MapFrom(source => source.Card.Status))
				.ForAllMembers(options => options.Ignore());
			CreateMap<UpdateCardRequestData, UpdateMemberCardCommand>();
			CreateMap<GetFilteredMemberCardsRequestData, GetPagedMemberCardsQuery>();
			CreateMap<GetPagedMemberCardsQueryResponse, GetFilteredMemberCardsResponse>();

		}
	}
}
