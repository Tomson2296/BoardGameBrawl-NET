using AutoMapper;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related.Preference_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related.Schedule_Related;
using BoardGameBrawl.Domain.Entities.Player_Related;
using BoardGameBrawl.Domain.Entities.Player_Related.Preference_Related;
using BoardGameBrawl.Domain.Entities.Player_Related.Schedule_Related;

namespace BoardGameBrawl.Application.Profiles
{
    public class PlayerMappingProfile : Profile
    {
        public PlayerMappingProfile()
        {
            CreateMap<PlayerDTO, Player>()
               .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
               .ForMember(dest => dest.LastModifiedDate, opt => opt.Ignore())
               .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())

               .ForMember(dest => dest.GroupParticipants, opt => opt.Ignore())
               .ForMember(dest => dest.PlayerRatings, opt => opt.Ignore())
               .ForMember(dest => dest.PlayerCollection, opt => opt.Ignore())
               .ForMember(dest => dest.PlayerSchedule, opt => opt.Ignore())
               .ForMember(dest => dest.PlayerFavouriteBGs, opt => opt.Ignore())
               .ForMember(dest => dest.Friendships, opt => opt.Ignore())
               .ForMember(dest => dest.FriendOfFriendships, opt => opt.Ignore())
               .ForMember(dest => dest.BoardgameModerators, opt => opt.Ignore())
               .ReverseMap();

            CreateMap<NavPlayerDTO, Player>()
               .ForMember(dest => dest.Email, opt => opt.Ignore())
               .ForMember(dest => dest.FirstName, opt => opt.Ignore())
               .ForMember(dest => dest.LastName, opt => opt.Ignore())
               .ForMember(dest => dest.BGGUsername, opt => opt.Ignore())
               .ForMember(dest => dest.UserDescription, opt => opt.Ignore())
               .ForMember(dest => dest.ApplicationUserId, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
               .ForMember(dest => dest.LastModifiedDate, opt => opt.Ignore())
               .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())

               .ForMember(dest => dest.GroupParticipants, opt => opt.Ignore())
               .ForMember(dest => dest.PlayerRatings, opt => opt.Ignore())
               .ForMember(dest => dest.PlayerCollection, opt => opt.Ignore())
               .ForMember(dest => dest.PlayerSchedule, opt => opt.Ignore())
               .ForMember(dest => dest.PlayerFavouriteBGs, opt => opt.Ignore())
               .ForMember(dest => dest.Friendships, opt => opt.Ignore())
               .ForMember(dest => dest.FriendOfFriendships, opt => opt.Ignore())
               .ForMember(dest => dest.BoardgameModerators, opt => opt.Ignore())
               .ReverseMap();

            CreateMap<PlayerFavouriteBGDTO, PlayerFavouriteBG>()
               .ForMember(dest => dest.Player, opt => opt.Ignore())
               .ForMember(dest => dest.Boardgame, opt => opt.Ignore())

               .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
               .ForMember(dest => dest.LastModifiedDate, opt => opt.Ignore())
               .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
               .ReverseMap();

            CreateMap<PlayerPreferenceDTO, PlayerPreference>()
               .ForMember(dest => dest.Player, opt => opt.Ignore())
               .ForMember(dest => dest.Boardgame, opt => opt.Ignore())

               .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
               .ForMember(dest => dest.LastModifiedDate, opt => opt.Ignore())
               .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
               .ReverseMap();

            CreateMap<PlayerCollectionDTO, PlayerCollection>()
               .ForMember(dest => dest.Player, opt => opt.Ignore())

               .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
               .ForMember(dest => dest.LastModifiedDate, opt => opt.Ignore())
               .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
               .ReverseMap();

            CreateMap<PlayerFriendDTO, PlayerFriend>()
               .ForMember(dest => dest.Requester, opt => opt.Ignore())
               .ForMember(dest => dest.Addressee, opt => opt.Ignore())

               .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
               .ForMember(dest => dest.LastModifiedDate, opt => opt.Ignore())
               .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
               .ReverseMap();


            // Related-to-Preferences DTO mappings

            CreateMap<CompositePlayerBoardgamePreferences, CompositePlayerBoardgamePreferencesDTO>()
                .ForMember(dest => dest.BGGId, opt => opt.MapFrom(src => src.Boardgame!.BGGId))
                .ForMember(dest => dest.Boardgame_Name, opt => opt.MapFrom(src => src.Boardgame!.Name))
                .ForMember(dest => dest.Boardgame_Image, opt => opt.MapFrom(src => src.Boardgame!.Image))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.PlayerPreference!.Rating));

            CreateMap<CompositeBoardgamePreferencesByPlayers, CompositeBoardgamePreferencesByPlayersDTO>()
                .ForMember(dest => dest.PlayerId, opt => opt.MapFrom(src => src.Player!.Id))
                .ForMember(dest => dest.PlayerName, opt => opt.MapFrom(src => src.Player!.PlayerName))
                .ForMember(dest => dest.UserAvatar, opt => opt.MapFrom(src => src.Player!.UserAvatar))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.PlayerPreference!.Rating));


            // Related-to-Schedule DTO mappings


            CreateMap<TimeSlotDTO, TimeSlot>()
               .ForMember(dest => dest.DailyAvailability, opt => opt.Ignore())
               .ReverseMap();

            CreateMap<DailyAvailabilityDTO, DailyAvailability>()
               .ForMember(dest => dest.PlayerSchedule, opt => opt.Ignore())
               .ReverseMap();

            CreateMap<PlayerScheduleDTO, PlayerSchedule>()
               .ForMember(dest => dest.Player, opt => opt.Ignore())

               .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
               .ForMember(dest => dest.LastModifiedDate, opt => opt.Ignore())
               .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
               .ReverseMap();

        }
    }
}