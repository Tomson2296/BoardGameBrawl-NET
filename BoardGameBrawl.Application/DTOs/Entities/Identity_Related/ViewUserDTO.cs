using AutoMapper;
using BoardGameBrawl.Application.DTOs.Common;
using BoardGameBrawl.Domain.Entities;

namespace BoardGameBrawl.Application.DTOs.Entities.Identity_Related
{
    [AutoMap(typeof(ApplicationUser))]
    public class ViewUserDTO : BaseAuditableEntityDTO
    {
        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? UserDescription { get; set; }

        public byte[]? UserAvatar { get; set; }
    }
}
