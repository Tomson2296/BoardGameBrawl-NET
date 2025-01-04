using BoardGameBrawl.Domain.Common;

namespace BoardGameBrawl.Domain.Entities.Boardgame_Related
{
    public class BoardgameMechanic : BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid(); 

        public string? Mechanic { get; set; }

        public ICollection<BoardgameMechanicTag>? BoardgameMechanicTags { get; set; }
    }
}
