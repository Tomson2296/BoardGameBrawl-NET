using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Domain.Entities.Match_Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Contracts.Entities.Match_Related
{
    public interface IMatchRuleSetRepository : IGenericRepository<MatchRuleSet>, IAuditableRepository<MatchRuleSet>
    {
    }
}
