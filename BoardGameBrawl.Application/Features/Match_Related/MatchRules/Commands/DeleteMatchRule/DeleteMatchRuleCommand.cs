#nullable disable
using BoardGameBrawl.Application.DTOs.Entities.Match_Related;
using BoardGameBrawl.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Match_Related.MatchRules.Commands.DeleteMatchRule
{
    public class DeleteMatchRuleCommand : IRequest<BaseCommandResponse>
    {
        public MatchRuleDTO MatchRuleDTO { get; set; }
    }
}
