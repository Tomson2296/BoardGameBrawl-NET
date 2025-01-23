using AutoMapper;
using BoardGameBrawl.Identity.Entities;

namespace BoardGameBrawl.Identity.DTOs
{
    [AutoMap(typeof(ApplicationUser))]
    public class ViewUserDTO : BaseEntityDTO
    {
        public string? UserName { get; set; }

        public string? Email { get; set; }
        
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? UserDescription { get; set; }

        public byte[]? UserAvatar { get; set; }
    }
}
