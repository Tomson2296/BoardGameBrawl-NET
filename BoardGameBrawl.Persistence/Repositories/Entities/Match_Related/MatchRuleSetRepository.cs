using BoardGameBrawl.Application.Contracts.Entities.Match_Related;
using BoardGameBrawl.Domain.Entities.Match_Related;
using BoardGameBrawl.Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Persistence.Repositories.Entities.Match_Related
{
    public class MatchRuleSetRepository : GenericRepository<MatchRuleSet>, IMatchRuleSetRepository
    {
        public MatchRuleSetRepository(MainAppDBContext context) : base(context)
        {
        }
    }
}
