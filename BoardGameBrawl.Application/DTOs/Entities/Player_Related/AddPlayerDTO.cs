using BoardGameBrawl.Application.DTOs.Common;

namespace BoardGameBrawl.Application.DTOs.Entities.Player_Related
{
    public class AddPlayerDTO : BaseEntityDTO
    {
        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? BGGUsername { get; set; }

        public string? UserDescription { get; set; }

        public byte[]? UserAvatar { get; set; }
    }
}
