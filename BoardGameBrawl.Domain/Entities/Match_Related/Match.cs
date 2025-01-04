using BoardGameBrawl.Domain.Common;

namespace BoardGameBrawl.Domain.Entities.Match_Related
{
    public class Match : BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public MatchProgress MatchProgress { get; set; }

        public DateTime MatchDate_Created { get; set; }

        public DateTime MatchDate_Started { get; set; }

        public DateTime MatchDate_Ended { get; set; }

        public int NumberOfPlayers { get; set; }

        public Dictionary<string, MatchUserRoles>? Participants { get; set; }

        public Guid? BoardgameId { get; set; }
    }
}