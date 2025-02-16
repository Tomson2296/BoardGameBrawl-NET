using BoardGameBrawl.Domain.Common.BaseEntities;
using BoardGameBrawl.Domain.Entities.Player_Related;
using BoardGameBrawl.Domain.Value_Objects;

namespace BoardGameBrawl.Domain.Entities.Match_Related
{
    public class MatchResult
    {
        public Guid Id { get; set; }

        public Guid MatchId { get; set; }

        public BaseMatchEntity? Match { get; set; }

        public Guid? WinnerId { get; set; }

        public Player? Winner { get; set; }

        public Guid? MatchRuleSetId { get; set; }

        public MatchRuleSet? MatchRuleSet { get; set; }

        // Store a JSON snapshot of the applied victory conditions
        public VictoryConditions? AppliedVictoryConditions { get; set; }

        public AdditionalMatchDetails? AppliedAdditionMatchDetails { get; set; }

        public List<PlayerResult>? PlayerScores { get; set; }

        public string? Summary { get; set; }
    }
}
