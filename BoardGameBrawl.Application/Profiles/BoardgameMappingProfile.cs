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
               .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
               .ForMember(dest => dest.LastModifiedDate, opt => opt.Ignore())
               .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())

               .ForMember(dest => dest.BoardgameDomainTags, opt => opt.Ignore())
               .ForMember(dest => dest.BoardgameCategoryTags, opt => opt.Ignore())
               .ForMember(dest => dest.BoardgameMechanicTags, opt => opt.Ignore())
               .ForMember(dest => dest.BoardgameRules, opt => opt.Ignore())
               .ForMember(dest => dest.PlayerPreferences, opt => opt.Ignore())
               .ForMember(dest => dest.Matches, opt => opt.Ignore())
               .ForMember(dest => dest.Tournaments, opt => opt.Ignore())
               .ForMember(dest => dest.TournamentMatches, opt => opt.Ignore())
               .ForMember(dest => dest.PlayerFavouriteBGs, opt => opt.Ignore())
               .ForMember(dest => dest.BoardgameModerators, opt => opt.Ignore())
               .ReverseMap();

            CreateMap<NavBoardgameDTO, Boardgame>()
              .ForMember(dest => dest.YearPublished, opt => opt.Ignore())
              .ForMember(dest => dest.MinAge, opt => opt.Ignore())
              .ForMember(dest => dest.MinPlayers, opt => opt.Ignore())
              .ForMember(dest => dest.MaxPlayers, opt => opt.Ignore())
              .ForMember(dest => dest.PlayingTime, opt => opt.Ignore())
              .ForMember(dest => dest.MinimumPlayingTime, opt => opt.Ignore())
              .ForMember(dest => dest.MaximumPlayingTime, opt => opt.Ignore())
              .ForMember(dest => dest.AverageBGGWeight, opt => opt.Ignore())
              .ForMember(dest => dest.PlayingTime, opt => opt.Ignore())
              .ForMember(dest => dest.AverageRating, opt => opt.Ignore())
              .ForMember(dest => dest.BayesRating, opt => opt.Ignore())
              .ForMember(dest => dest.Owned, opt => opt.Ignore())
              .ForMember(dest => dest.Description, opt => opt.Ignore())
              .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
              .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
              .ForMember(dest => dest.LastModifiedDate, opt => opt.Ignore())
              .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())

              .ForMember(dest => dest.BoardgameDomainTags, opt => opt.Ignore())
              .ForMember(dest => dest.BoardgameCategoryTags, opt => opt.Ignore())
              .ForMember(dest => dest.BoardgameMechanicTags, opt => opt.Ignore())
              .ForMember(dest => dest.BoardgameRules, opt => opt.Ignore())
              .ForMember(dest => dest.PlayerPreferences, opt => opt.Ignore())
              .ForMember(dest => dest.Matches, opt => opt.Ignore())
              .ForMember(dest => dest.Tournaments, opt => opt.Ignore())
              .ForMember(dest => dest.TournamentMatches, opt => opt.Ignore())
              .ForMember(dest => dest.PlayerFavouriteBGs, opt => opt.Ignore())
              .ForMember(dest => dest.BoardgameModerators, opt => opt.Ignore())
              .ReverseMap();

            CreateMap<BoardgameDomainDTO, BoardgameDomain>()
               .ForMember(dest => dest.BoardgameDomainTags, opt => opt.Ignore())

               .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
               .ForMember(dest => dest.LastModifiedDate, opt => opt.Ignore())
               .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
               .ReverseMap();

            CreateMap<BoardgameDomainTagDTO, BoardgameDomainTag>()
               .ForMember(dest => dest.Boardgame, opt => opt.Ignore())
               .ForMember(dest => dest.Domain, opt => opt.Ignore())
               .ReverseMap();

            CreateMap<BoardgameCategoryDTO, BoardgameCategory>()
               .ForMember(dest => dest.BoardgameCategoryTags, opt => opt.Ignore())

               .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
               .ForMember(dest => dest.LastModifiedDate, opt => opt.Ignore())
               .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
               .ReverseMap();

            CreateMap<BoardgameCategoryTagDTO, BoardgameCategoryTag>()
               .ForMember(dest => dest.Boardgame, opt => opt.Ignore())
               .ForMember(dest => dest.Category, opt => opt.Ignore())
               .ReverseMap();

            CreateMap<BoardgameMechanicDTO, BoardgameMechanic>()
               .ForMember(dest => dest.BoardgameMechanicTags, opt => opt.Ignore())

               .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
               .ForMember(dest => dest.LastModifiedDate, opt => opt.Ignore())
               .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
               .ReverseMap();

            CreateMap<BoardgameMechanicTagDTO, BoardgameMechanicTag>()
               .ForMember(dest => dest.Boardgame, opt => opt.Ignore())
               .ForMember(dest => dest.Mechanic, opt => opt.Ignore())
               .ReverseMap();

            CreateMap<BoardgameModeratorDTO, BoardgameModerator>()
               .ForMember(dest => dest.Boardgame, opt => opt.Ignore())
               .ForMember(dest => dest.Moderator, opt => opt.Ignore())

               .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
               .ForMember(dest => dest.LastModifiedDate, opt => opt.Ignore())
               .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
               .ReverseMap();
        }
    }
}
