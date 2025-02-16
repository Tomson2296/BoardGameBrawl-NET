using AutoMapper;
using BoardGameBrawl.Application.DTOs.Entities.Match_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Domain.Entities.Match_Related;
using BoardGameBrawl.Domain.Entities.Player_Related;
using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Profiles
{
    public class MatchMappingProfile : Profile
    {
        public MatchMappingProfile()
        {
            CreateMap<MatchRuleSetDTO, MatchRuleSet>()
              .ForMember(dest => dest.Boardgame, opt => opt.Ignore())
              .ForMember(dest => dest.MatchesWithRuleSetUsed, opt => opt.Ignore())

              .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
              .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
              .ForMember(dest => dest.LastModifiedDate, opt => opt.Ignore())
              .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
              .ReverseMap();
        }
    }
}
