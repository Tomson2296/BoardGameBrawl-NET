using BoardGameBrawl.Domain.Common;
using BoardGameBrawl.Domain.Entities.Match_Related;
using BoardGameBrawl.Domain.Entities.Player_Related;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Domain.Entities.Tournament_Related
{
    public class TournamentParticipant : BaseAuditableEntity
    {
        public Guid TournamentId { get; set; }

        public Tournament? Tournament { get; set; }

        public Guid PlayerId { get; set; }

        public Player? Player { get; set; }

        public TournamentPlayerRole TournamentUserRole { get; set; }
    }
}
