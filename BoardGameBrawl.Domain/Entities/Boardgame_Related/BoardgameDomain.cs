using BoardGameBrawl.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Domain.Entities.Boardgame_Related
{
    public class BoardgameDomain : BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string? Domain { get; set; }

        public ICollection<BoardgameDomainTag>? BoardgameDomainTags { get; set; }
    }
}
