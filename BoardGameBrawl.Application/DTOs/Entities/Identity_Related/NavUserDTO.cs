using AutoMapper;
using BoardGameBrawl.Application.DTOs.Common;
using BoardGameBrawl.Domain.Entities;

namespace BoardGameBrawl.Application.DTOs.Entities.Identity_Related
{
    [AutoMap(typeof(ApplicationUser))]
    public class NavUserDTO : BaseEntityDTO
    {
        public string? Username { get; set; }
    }
}
