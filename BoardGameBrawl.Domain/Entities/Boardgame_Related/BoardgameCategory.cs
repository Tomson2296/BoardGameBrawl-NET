using BoardGameBrawl.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameBrawl.Domain.Entities.Boardgame_Related
{
    public class BoardgameCategory : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Category { get; set; }

        public ICollection<BoardgameCategoryTag>? BoardgameCategoryTags { get; set; }
    }
}
