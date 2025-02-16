using BoardGameBrawl.Domain.Common;
using BoardGameBrawl.Domain.Common.BaseEntities;
using BoardGameBrawl.Domain.Entities.Player_Related;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BoardGameBrawl.Domain.Entities.Match_Related
{
    public class MatchParticipant : BaseAuditableEntity
    {
        public Guid MatchId { get; set; }

        public Match? Match { get; set; }

        public Guid PlayerId { get; set; }

        public Player? Player { get; set; }

        public MatchPlayerRole MatchPlayerRole { get; set; }
    }
}
