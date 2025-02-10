using BoardGameBrawl.Application.DTOs.Entities.Match_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Match_Related.MatchRules.Queries.GetMatchRuleset
{
    public class GetMatchRulesetQuery : IRequest<IList<MatchRuleDTO>>
    {
        public Guid BoardgameId { get; set; }
    }
}
