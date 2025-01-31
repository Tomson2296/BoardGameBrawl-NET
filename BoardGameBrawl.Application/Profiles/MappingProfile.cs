using AutoMapper;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using BoardGameBrawl.Application.DTOs.Entities.Group_Related;
using BoardGameBrawl.Application.DTOs.Entities.Identity_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Domain.Entities;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using BoardGameBrawl.Domain.Entities.Group_Related;
using BoardGameBrawl.Domain.Entities.Player_Related;

namespace BoardGameBrawl.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
         CreateMap<PlayerDTO, Player>()
            .ForMember(dest => dest.GroupParticipants, opt => opt.Ignore())
            .ForMember(dest => dest.UserRatings, opt => opt.Ignore())
            .ReverseMap();

         CreateMap<PlayerPreferenceDTO, PlayerRreference>()
            .ForMember(dest => dest.Player, opt => opt.Ignore())
            .ForMember(dest => dest.Boardgame, opt => opt.Ignore())
            .ReverseMap();

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

         CreateMap<GroupDTO, Group>()
            .ForMember(dest => dest.GroupParticipants, opt => opt.Ignore())
            .ReverseMap();

         CreateMap<GroupParticipantDTO, GroupParticipant>()
            .ForMember(dest => dest.Group, opt => opt.Ignore())
            .ForMember(dest => dest.Player, opt => opt.Ignore())
            .ReverseMap();

         CreateMap<ViewUserDTO, ApplicationUser>()
            .ForMember(dest => dest.UserClaims, opt => opt.Ignore())
            .ForMember(dest => dest.UserLogins, opt => opt.Ignore())
            .ForMember(dest => dest.UserTokens, opt => opt.Ignore())
            .ForMember(dest => dest.UserRoles, opt => opt.Ignore())
         
            .ForMember(dest => dest.UserCreatedDate, opt => opt.Ignore())
            .ForMember(dest => dest.UserLastLogin, opt => opt.Ignore())
            .ForMember(dest => dest.BGGUsername, opt => opt.Ignore())
            .ForMember(dest => dest.NormalizedUserName, opt => opt.Ignore())
            .ForMember(dest => dest.NormalizedEmail, opt => opt.Ignore())
            .ForMember(dest => dest.EmailConfirmed, opt => opt.Ignore())
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
            .ForMember(dest => dest.SecurityStamp, opt => opt.Ignore())
            .ForMember(dest => dest.ConcurrencyStamp, opt => opt.Ignore())
            .ForMember(dest => dest.IsPlayerCreated, opt => opt.Ignore())

            .ForMember(dest => dest.PhoneNumber, opt => opt.Ignore())
            .ForMember(dest => dest.PhoneNumberConfirmed, opt => opt.Ignore())
            .ForMember(dest => dest.TwoFactorEnabled, opt => opt.Ignore())
            .ForMember(dest => dest.AccessFailedCount, opt => opt.Ignore())
            .ForMember(dest => dest.LockoutEnabled, opt => opt.Ignore())
            .ForMember(dest => dest.LockoutEnd, opt => opt.Ignore())

            .ReverseMap();
        }
    }
}