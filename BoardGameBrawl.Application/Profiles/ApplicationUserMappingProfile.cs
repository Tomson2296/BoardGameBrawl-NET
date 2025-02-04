using AutoMapper;
using BoardGameBrawl.Application.DTOs.Entities.Identity_Related;
using BoardGameBrawl.Domain.Entities;

namespace BoardGameBrawl.Application.Profiles
{
    public class ApplicationUserMappingProfile : Profile
    {
        public ApplicationUserMappingProfile()
        {
            CreateMap<ViewUserDTO, ApplicationUser>()
               .ForMember(dest => dest.UserClaims, opt => opt.Ignore())
               .ForMember(dest => dest.UserLogins, opt => opt.Ignore())
               .ForMember(dest => dest.UserTokens, opt => opt.Ignore())
               .ForMember(dest => dest.UserRoles, opt => opt.Ignore())

               .ForMember(dest => dest.PhoneNumber, opt => opt.Ignore())
               .ForMember(dest => dest.PhoneNumberConfirmed, opt => opt.Ignore())
               .ForMember(dest => dest.TwoFactorEnabled, opt => opt.Ignore())
               .ForMember(dest => dest.AccessFailedCount, opt => opt.Ignore())
               .ForMember(dest => dest.LockoutEnabled, opt => opt.Ignore())
               .ForMember(dest => dest.LockoutEnd, opt => opt.Ignore())

               .ReverseMap();

            CreateMap<NavUserDTO, ApplicationUser>()
                .ForMember(dest => dest.UserCreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.UserLastLogin, opt => opt.Ignore())
                .ForMember(dest => dest.IsPlayerCreated, opt => opt.Ignore())
                .ForMember(dest => dest.NormalizedUserName, opt => opt.Ignore())
                .ForMember(dest => dest.Email, opt => opt.Ignore())
                .ForMember(dest => dest.NormalizedEmail, opt => opt.Ignore())
                .ForMember(dest => dest.EmailConfirmed, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.SecurityStamp, opt => opt.Ignore())
                .ForMember(dest => dest.ConcurrencyStamp, opt => opt.Ignore())

                .ForMember(dest => dest.UserClaims, opt => opt.Ignore())
                .ForMember(dest => dest.UserLogins, opt => opt.Ignore())
                .ForMember(dest => dest.UserTokens, opt => opt.Ignore())
                .ForMember(dest => dest.UserRoles, opt => opt.Ignore())

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