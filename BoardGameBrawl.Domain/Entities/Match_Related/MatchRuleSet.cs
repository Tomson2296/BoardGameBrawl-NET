using BoardGameBrawl.Domain.Common;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using BoardGameBrawl.Domain.Value_Objects;

namespace BoardGameBrawl.Domain.Entities.Match_Related
{
    public class MatchRuleSet : BaseAuditableEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        
        public Guid BoardgameId { get; set; }
        
        public Boardgame? Boardgame { get; set; }

        // Store structured victory conditions as JSON
        public VictoryConditions? VictoryConditions { get; set; }

        public AdditionalMatchDetails? AdditionalMatchDetails { get; set; }

        public ICollection<MatchResult>? MatchesWithRuleSetUsed { get; set; } 
    }
}
