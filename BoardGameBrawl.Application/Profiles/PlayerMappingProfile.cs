using AutoMapper;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Domain.Entities.Player_Related;

namespace BoardGameBrawl.Application.Profiles
{
    public class PlayerMappingProfile : Profile
    {
        public PlayerMappingProfile()
        {
            CreateMap<PlayerDTO, Player>()
               .ForMember(dest => dest.GroupParticipants, opt => opt.Ignore())
               .ForMember(dest => dest.PlayerRatings, opt => opt.Ignore())
               .ForMember(dest => dest.PlayerCollection, opt => opt.Ignore())
               .ForMember(dest => dest.PlayerFavouriteBGs, opt => opt.Ignore())
               .ForMember(dest => dest.Friendships, opt => opt.Ignore())
               .ForMember(dest => dest.FriendOfFriendships, opt => opt.Ignore())
               .ReverseMap();

            CreateMap<NavPlayerDTO, Player>()
               .ForMember(dest => dest.Email, opt => opt.Ignore())
               .ForMember(dest => dest.FirstName, opt => opt.Ignore())
               .ForMember(dest => dest.LastName, opt => opt.Ignore())
               .ForMember(dest => dest.BGGUsername, opt => opt.Ignore())
               .ForMember(dest => dest.UserDescription, opt => opt.Ignore())
               .ForMember(dest => dest.ApplicationUserId, opt => opt.Ignore())

               .ForMember(dest => dest.GroupParticipants, opt => opt.Ignore())
               .ForMember(dest => dest.PlayerRatings, opt => opt.Ignore())
               .ForMember(dest => dest.PlayerCollection, opt => opt.Ignore())
               .ForMember(dest => dest.PlayerFavouriteBGs, opt => opt.Ignore())
               .ForMember(dest => dest.Friendships, opt => opt.Ignore())
               .ForMember(dest => dest.FriendOfFriendships, opt => opt.Ignore())
               .ReverseMap();

            CreateMap<PlayerPreferenceDTO, PlayerRreference>()
               .ForMember(dest => dest.Player, opt => opt.Ignore())
               .ForMember(dest => dest.Boardgame, opt => opt.Ignore())
               .ReverseMap();

            CreateMap<PlayerCollectionDTO, PlayerCollection>()
               .ForMember(dest => dest.Player, opt => opt.Ignore())
               .ReverseMap();
        }
    }
}