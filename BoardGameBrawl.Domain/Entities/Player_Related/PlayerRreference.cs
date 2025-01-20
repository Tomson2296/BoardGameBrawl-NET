using BoardGameBrawl.Domain.Entities.Boardgame_Related;

namespace BoardGameBrawl.Domain.Entities.Player_Related
{
    public class PlayerRreference
    {
        public Guid PlayerId { get; set; }

        public Player? Player { get; set; }

        public Guid BoardgameId { get; set; }

        public Boardgame? Boardgame { get; set; }

        public byte Rating { get; set; }
    }
}
