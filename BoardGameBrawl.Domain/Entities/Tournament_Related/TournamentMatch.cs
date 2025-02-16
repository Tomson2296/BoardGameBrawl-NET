using BoardGameBrawl.Domain.Common.BaseEntities;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using BoardGameBrawl.Domain.Entities.Match_Related;

namespace BoardGameBrawl.Domain.Entities.Tournament_Related
{
    public class TournamentMatch : BaseMatchEntity
    {
        public short MatchNumber { get; set; }

        public Guid TournamentId { get; set; }

        public Tournament? Tournament { get; set; }

        public ICollection<TournamentMatchParticipant>? TournamentMatchParticipants { get; set; }
    }
}