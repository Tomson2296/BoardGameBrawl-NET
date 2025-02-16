using BoardGameBrawl.Domain.Common;
using BoardGameBrawl.Domain.Common.BaseEntities;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameBrawl.Domain.Entities.Tournament_Related
{
    public class Tournament : BaseAuditableEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string? TournamentName { get; set; }

        public string? Description { get; set; }

        public TournamentProgress TournnamentProgress { get; set; }

        public DateTimeOffset TournamentDate_Created { get; set; }

        public DateTimeOffset? TournamentDate_Started { get; set; }

        public DateTimeOffset? TournamentDate_Ended { get; set; }

        public short MaxNumberOfPlayers { get; set; }

        public Guid BoardgameId { get; set; }

        public Boardgame? Boardgame { get; set; }

        public ICollection<TournamentParticipant>? TournamentParticipants { get; set; }

        public ICollection<TournamentMatch>? TournamentMatches { get; set; }
    }
}
