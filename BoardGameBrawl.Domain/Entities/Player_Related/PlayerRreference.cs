using BoardGameBrawl.Domain.Common;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using System.Runtime.CompilerServices;

namespace BoardGameBrawl.Domain.Entities.Player_Related
{
    public class PlayerRreference : BaseEntity
    {
        public Guid PlayerId { get; set; }

        public Player? Player { get; set; }

        public required string PlayerName { get; set; }

        public Guid BoardgameId { get; set; }

        public Boardgame? Boardgame { get; set; }

        public required string BoardgameName { get; set; }

        public byte Rating { get; set; }
    }
}
