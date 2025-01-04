namespace BoardGameBrawl.Domain.Entities.Boardgame_Related
{
    public class BoardgameMechanicTag 
    {
        public Guid? BoardgameId { get; set; }

        public Boardgame? Boardgame { get; set; }

        public Guid? MechanicId { get; set; }

        public BoardgameMechanic? BoardgameMechanic { get; set; }
    }
}