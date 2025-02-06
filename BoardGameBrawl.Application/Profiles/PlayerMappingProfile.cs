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
               .ForMember(dest => dest.UserRatings, opt => opt.Ignore())
               .ReverseMap();

            CreateMap<NavPlayerDTO, Player>()
               .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
               .ForMember(dest => dest.LastModifiedDate, opt => opt.Ignore())
               .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
               .ForMember(dest => dest.Email, opt => opt.Ignore())
               .ForMember(dest => dest.FirstName, opt => opt.Ignore())
               .ForMember(dest => dest.LastName, opt => opt.Ignore())
               .ForMember(dest => dest.BGGUsername, opt => opt.Ignore())
               .ForMember(dest => dest.UserDescription, opt => opt.Ignore())
               .ForMember(dest => dest.UserAvatar, opt => opt.Ignore())
               .ForMember(dest => dest.ApplicationUserId, opt => opt.Ignore())

               .ForMember(dest => dest.GroupParticipants, opt => opt.Ignore())
               .ForMember(dest => dest.UserRatings, opt => opt.Ignore())
               .ReverseMap();

            CreateMap<PlayerPreferenceDTO, PlayerRreference>()
               .ForMember(dest => dest.Player, opt => opt.Ignore())
               .ForMember(dest => dest.Boardgame, opt => opt.Ignore())
               .ReverseMap();
        }
    }
}