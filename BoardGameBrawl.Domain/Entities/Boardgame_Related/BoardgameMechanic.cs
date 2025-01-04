using BoardGameBrawl.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameBrawl.Domain.Entities.Boardgame_Related
{
    public class BoardgameMechanic : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Mechanic { get; set; }

        public ICollection<BoardgameMechanicTag>? BoardgameMechanicTags { get; set; }
    }
}
