using AutoMapper;
using BoardGameBrawl.Identity.DTOs;
using BoardGameBrawl.Identity.Entities;

namespace BoardGameBrawl.Identity.Profiles
{
    public class IdentityMappingProfile : Profile
    {
        public IdentityMappingProfile()
        {
            CreateMap<ViewUserDTO, ApplicationUser>()
                .ForMember(dest => dest.UserClaims, opt => opt.Ignore())
                .ForMember(dest => dest.UserLogins, opt => opt.Ignore())
                .ForMember(dest => dest.UserTokens, opt => opt.Ignore())
                .ForMember(dest => dest.UserRoles, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}