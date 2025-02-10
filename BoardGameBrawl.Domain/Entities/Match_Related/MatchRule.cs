using BoardGameBrawl.Domain.Common;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameBrawl.Domain.Entities.Match_Related
{
    public class MatchRule : BaseEntity
    {
        public Guid RuleId { get; set; } = Guid.NewGuid();

        public string? RuleDescription { get; set; }

        public bool RuleDecider { get; set; }

        public RuleType RuleType { get; set; }


        public Guid BoardgameId { get; set; }

        [ForeignKey(nameof(BoardgameId))]
        public Boardgame? Boardgame { get; set; }
    }
}
