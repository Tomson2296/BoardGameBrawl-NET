using AutoMapper;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;

namespace BoardGameBrawl.Application.Profiles
{
    public class BoardgameMappingProfile : Profile
    {
        public BoardgameMappingProfile()
        {
            CreateMap<BoardgameDTO, Boardgame>()
               .ForMember(dest => dest.BoardgameDomainTags, opt => opt.Ignore())
               .ForMember(dest => dest.BoardgameCategoryTags, opt => opt.Ignore())
               .ForMember(dest => dest.BoardgameMechanicTags, opt => opt.Ignore())
               .ForMember(dest => dest.BoardgameRules, opt => opt.Ignore())
               .ForMember(dest => dest.UserRatings, opt => opt.Ignore())
               .ForMember(dest => dest.Matches, opt => opt.Ignore())
               .ForMember(dest => dest.Tournaments, opt => opt.Ignore())
               .ForMember(dest => dest.TournamentMatches, opt => opt.Ignore())
               .ForMember(dest => dest.PlayerFavouriteBGs, opt => opt.Ignore())
               .ReverseMap();


            CreateMap<BoardgameDomainDTO, BoardgameDomain>()
               .ForMember(dest => dest.BoardgameDomainTags, opt => opt.Ignore())
               .ReverseMap();

            CreateMap<BoardgameDomainTagDTO, BoardgameDomainTag>()
               .ForMember(dest => dest.Boardgame, opt => opt.Ignore())
               .ForMember(dest => dest.Domain, opt => opt.Ignore())
               .ReverseMap();



            CreateMap<BoardgameCategoryDTO, BoardgameCategory>()
               .ForMember(dest => dest.BoardgameCategoryTags, opt => opt.Ignore())
               .ReverseMap();

            CreateMap<BoardgameCategoryTagDTO, BoardgameCategoryTag>()
               .ForMember(dest => dest.Boardgame, opt => opt.Ignore())
               .ForMember(dest => dest.BoardgameCategory, opt => opt.Ignore())
               .ReverseMap();



            CreateMap<BoardgameMechanicDTO, BoardgameMechanic>()
               .ForMember(dest => dest.BoardgameMechanicTags, opt => opt.Ignore())
               .ReverseMap();

            CreateMap<BoardgameMechanicTagDTO, BoardgameMechanicTag>()
               .ForMember(dest => dest.Boardgame, opt => opt.Ignore())
               .ForMember(dest => dest.BoardgameMechanic, opt => opt.Ignore())
               .ReverseMap();
        }
    }
}
