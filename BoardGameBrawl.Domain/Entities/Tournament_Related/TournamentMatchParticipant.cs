using BoardGameBrawl.Domain.Common;
using BoardGameBrawl.Domain.Common.BaseEntities;
using BoardGameBrawl.Domain.Entities.Match_Related;
using BoardGameBrawl.Domain.Entities.Player_Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Domain.Entities.Tournament_Related
{
    public class TournamentMatchParticipant : BaseAuditableEntity
    {
        public Guid PlayerId { get; set; }

        public Player? Player { get; set; }

        public MatchPlayerRole MatchPlayerRole { get; set; }

        public Guid MatchId { get; set; }

        public TournamentMatch? Match { get; set; }
    }
}
