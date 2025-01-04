using BoardGameBrawl.Domain.Entities.Match_Related;

namespace BoardGameBrawl.Domain.Entities.Tournament_Related
{
    public class TournamentMatch
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public MatchProgress MatchProgress { get; set; }

        public DateTime MatchDate_Created { get; set; }

        public DateTime MatchDate_Started { get; set; }

        public DateTime MatchDate_Ended { get; set; }

        public int NumberOfPlayers { get; set; }

        public Dictionary<string, MatchUserRoles>? Participants { get; set; }

        public Guid? BoardgameId { get; set; }

        public Guid? TournamentId { get; set; }

        public short MatchNumber { get; set; }
    }
}