using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using BoardGameBrawl.Domain.Entities.Match_Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Domain.Common.BaseEntities
{
    public abstract class BaseMatchEntity : BaseAuditableEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid BoardgameId { get; set; }

        public Boardgame? Boardgame { get; set; }

        public MatchProgress MatchProgress { get; set; }

        public DateTimeOffset MatchDate_Created { get; set; }

        public DateTimeOffset? MatchDate_Started { get; set; }

        public DateTimeOffset? MatchDate_Ended { get; set; }

        public int NumberOfPlayers { get; set; }

        public MatchResult? MatchResult { get; set; }

        public string? Discriminator { get; set; } // "Match" or "TournamentMatch"
    }
}
