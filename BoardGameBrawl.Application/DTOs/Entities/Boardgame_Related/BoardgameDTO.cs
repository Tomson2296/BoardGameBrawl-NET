using AutoMapper;
using BoardGameBrawl.Application.DTOs.Common;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;

namespace BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related
{
    [AutoMap(typeof(Boardgame))]
    public class BoardgameDTO : BaseAuditableEntityDTO
    {
        public string? Name { get; set; }

        public int BGGId { get; set; }

        public short YearPublished { get; set; }

        public byte MinPlayers { get; set; }

        public byte MaxPlayers { get; set; }

        public short PlayingTime { get; set; }

        public short MinimumPlayingTime { get; set; }

        public short MaximumPlayingTime { get; set; }

        public float BGGWeight { get; set; }

        public byte[]? Image { get; set; }

        public string? Description { get; set; }
    }
}
