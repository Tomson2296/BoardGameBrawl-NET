namespace BoardGameBrawl.Domain.Entities.Boardgame_Related
{
    public class BoardgameCategoryTag 
    {
        public Guid BoardgameId { get; set; }

        public Boardgame? Boardgame { get; set; }

        public required string BoardgameName { get; set; }

        public Guid CategoryId { get; set; }

        public BoardgameCategory? Category { get; set; }

        public required string CategoryName { get; set; }
    }
}
