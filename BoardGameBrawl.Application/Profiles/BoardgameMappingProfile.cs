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
               .ForMember(dest => dest.BoardgameCategoryTags, opt => opt.Ignore())
               .ForMember(dest => dest.BoardgameMechanicTags, opt => opt.Ignore())
               .ForMember(dest => dest.BoardgameRules, opt => opt.Ignore())
               .ForMember(dest => dest.UserRatings, opt => opt.Ignore())
               .ForMember(dest => dest.Matches, opt => opt.Ignore())
               .ForMember(dest => dest.Tournaments, opt => opt.Ignore())
               .ForMember(dest => dest.TournamentMatches, opt => opt.Ignore())
               .ReverseMap();

            CreateMap<BoardgameCategoryDTO, BoardgameCategory>()
               .ForMember(dest => dest.BoardgameCategoryTags, opt => opt.Ignore())
               .ReverseMap();

            CreateMap<BoardgameMechanicDTO, BoardgameMechanic>()
               .ForMember(dest => dest.BoardgameMechanicTags, opt => opt.Ignore())
               .ReverseMap();
        }
    }
}
