using AutoMapper;
using BoardGameBrawl.Application.DTOs.Common;
using BoardGameBrawl.Domain.Entities;

namespace BoardGameBrawl.Application.DTOs.Entities.Identity_Related
{
    [AutoMap(typeof(ApplicationUser))]
    public class ViewUserDTO : BaseEntityDTO
    {
        public DateOnly? UserCreatedDate { get; set; }

        public DateOnly? UserLastLogin { get; set; }

        public string? UserName { get; set; }

        public string? NormalizedUserName { get; set; }
        
        public bool IsPlayerCreated { get; set; }

        public string? Email { get; set; }

        public string? NormalizedEmail { get; set; }

        public bool EmailConfirmed { get; set; }

        public string? PasswordHash { get; set; }

        public string? SecurityStamp { get; set; }

        public string? ConcurrencyStamp { get; set; } 
    }
}