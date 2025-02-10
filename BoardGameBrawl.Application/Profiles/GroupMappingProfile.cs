﻿using AutoMapper;
using BoardGameBrawl.Application.DTOs.Entities.Group_Related;
using BoardGameBrawl.Domain.Entities.Group_Related;

namespace BoardGameBrawl.Application.Profiles
{
    public class GroupMappingProfile : Profile
    {
        public GroupMappingProfile()
        {
            CreateMap<GroupDTO, Group>()
               .ForMember(dest => dest.GroupParticipants, opt => opt.Ignore())

               .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
               .ForMember(dest => dest.LastModifiedDate, opt => opt.Ignore())
               .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
               .ReverseMap();

            CreateMap<NavGroupDTO, Group>()
               .ForMember(dest => dest.GroupDescription, opt => opt.Ignore())
               .ForMember(dest => dest.GroupParticipants, opt => opt.Ignore())

               .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
               .ForMember(dest => dest.LastModifiedDate, opt => opt.Ignore())
               .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
               .ReverseMap();

            CreateMap<GroupParticipantDTO, GroupParticipant>()
               .ForMember(dest => dest.Group, opt => opt.Ignore())
               .ForMember(dest => dest.Player, opt => opt.Ignore())
               .ReverseMap();
        }
    }
}
