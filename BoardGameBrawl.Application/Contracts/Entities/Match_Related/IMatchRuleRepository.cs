using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Match_Related;
using BoardGameBrawl.Domain.Entities.Match_Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Contracts.Entities.Match_Related
{
    public interface IMatchRuleRepository : IGenericRepository<MatchRule>, IAuditableRepository<MatchRule>
    {
        // getter methods //

        Task<IList<MatchRuleDTO>> GetMatchrulesetForBoardgame(Guid boardgameId, CancellationToken cancellationToken = default);

    }
}
