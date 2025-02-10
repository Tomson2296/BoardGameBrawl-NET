using AutoMapper;
using BoardGameBrawl.Application.DTOs.Common;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;

namespace BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related
{
    [AutoMap(typeof(Boardgame))]
    public class BoardgameDTO
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public int BGGId { get; set; }

        public short YearPublished { get; set; }

        public byte MinPlayers { get; set; }

        public byte MaxPlayers { get; set; }

        public byte MinAge { get; set; }

        public short PlayingTime { get; set; }

        public short MinimumPlayingTime { get; set; }

        public short MaximumPlayingTime { get; set; }

        public int Rank { get; set; }

        public float AverageBGGWeight { get; set; }

        public float AverageRating { get; set; }

        public float BayesRating { get; set; }

        public int Owned { get; set; }

        public byte[]? Image { get; set; }

        public string? Description { get; set; }
    }
}
