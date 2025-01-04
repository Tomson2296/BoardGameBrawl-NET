namespace BoardGameBrawl.Domain.Entities.Boardgame_Related
{
    public class BoardgameCategoryTag 
    {
        public Guid? BoardgameId { get; set; }

        public Boardgame? Boardgame { get; set; }

        public int? CategoryId { get; set; }

        public BoardgameCategory? BoardgameCategory { get; set; }
    }
}
