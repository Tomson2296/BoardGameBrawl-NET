using BoardGameBrawl.Domain.Common;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;

namespace BoardGameBrawl.Domain.Entities.Match_Related
{
    public class MatchRule : BaseEntity
    {
        public Guid RuleId { get; set; } = Guid.NewGuid();

        public string? RuleDescription { get; set; }

        public bool RuleDecider { get; set; }

        public RuleType RuleType { get; set; }

        public Boardgame? Boardgame { get; set; }

        public Guid BoardgameId { get; set; }
    }
}
