using BoardGameBrawl.Domain.Common;

namespace BoardGameBrawl.Domain.Entities.Tournament_Related
{
    public class Tournament : BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string? TournamentName { get; set; }

        public TournnamentProgress TournnamentProgress { get; set; }

        public DateTime TournamentDate_Created { get; set; }

        public DateTime TournamentDate_Started { get; set; }

        public DateTime TournamentDate_Ended { get; set; }

        public string? Description { get; set; }

        public short MaxNumberOfPlayers { get; set; }

        public Guid BoardgameId { get; set; }

        public Dictionary<string, TournamentUserRoles>? TournamentParticipants { get; set; }

        public ICollection<TournamentMatch>? TournamentMatches { get; set; }
    }
}
