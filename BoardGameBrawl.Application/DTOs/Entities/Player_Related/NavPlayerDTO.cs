using AutoMapper;
using BoardGameBrawl.Application.DTOs.Common;
using BoardGameBrawl.Domain.Entities.Player_Related;

namespace BoardGameBrawl.Application.DTOs.Entities.Player_Related
{
    [AutoMap(typeof(Player))]
    public class NavPlayerDTO : BaseAuditableEntityDTO
    {
        public string? PlayerName { get; set; }

        public byte[]? UserAvatar { get; set; }
    }
}
