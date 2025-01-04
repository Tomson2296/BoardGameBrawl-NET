using BoardGameBrawl.Domain.Common;

namespace BoardGameBrawl.Domain.Entities.Boardgame_Related
{
    public class BoardgameCategory : BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid(); 

        public string? Category { get; set; }

        public ICollection<BoardgameCategoryTag>? BoardgameCategoryTags { get; set; }
    }
}
