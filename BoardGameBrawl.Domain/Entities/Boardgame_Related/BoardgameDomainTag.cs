using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Domain.Entities.Boardgame_Related
{
    public class BoardgameDomainTag
    {
        public Guid BoardgameId { get; set; }

        [ForeignKey(nameof(BoardgameId))]
        public Boardgame? Boardgame { get; set; }

        public required string BoardgameName { get; set; }

        public Guid DomainId { get; set; }

        [ForeignKey(nameof(DomainId))]
        public BoardgameDomain? Domain { get; set; }

        public required string DomainName { get; set; }
    }
}
