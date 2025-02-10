using BoardGameBrawl.Application.Features.Common.Generic.Commands.DeleteEntity;
using BoardGameBrawl.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Common.Concrete.Commands.DeleteEntity.MatchRuleEntity
{
    public class DeleteMatchRuleCommand : IRequest<BaseCommandResponse>
    {
        public Guid RuleId { get; set; }
    }
}
