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

            CreateMap<PlayerPreferenceDTO, PlayerRreference>()
               .ForMember(dest => dest.Player, opt => opt.Ignore())
               .ForMember(dest => dest.Boardgame, opt => opt.Ignore())
               .ReverseMap();
        }
    }
}
