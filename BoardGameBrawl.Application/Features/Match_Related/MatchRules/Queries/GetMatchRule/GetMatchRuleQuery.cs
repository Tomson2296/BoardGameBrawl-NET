using BoardGameBrawl.Application.DTOs.Entities.Match_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Match_Related.MatchRules.Queries.GetMatchRule
{
    public class GetMatchRuleQuery : IRequest<MatchRuleDTO>
    {
        public Guid Id { get; set; }
    }
}
