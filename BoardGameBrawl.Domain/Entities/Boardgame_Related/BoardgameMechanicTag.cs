namespace BoardGameBrawl.Domain.Entities.Boardgame_Related
{
    public class BoardgameMechanicTag 
    {
        public Guid BoardgameId { get; set; }

        public Boardgame? Boardgame { get; set; }

        public required string BoardgameName { get; set; }

        public Guid MechanicId { get; set; }

        public BoardgameMechanic? Mechanic { get; set; }

        public required string MechanicName { get; set; }
    }
}