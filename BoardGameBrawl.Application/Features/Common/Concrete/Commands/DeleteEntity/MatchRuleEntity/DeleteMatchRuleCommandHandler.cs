using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Features.Common.Generic.Commands.DeleteEntity;
using BoardGameBrawl.Domain.Entities.Match_Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Common.Concrete.Commands.DeleteEntity.MatchRuleEntity
{
    public class DeleteMatchRuleCommandHandler : DeleteEntityCommandHandler<DeleteMatchRuleCommand, MatchRule>
    {
        public DeleteMatchRuleCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override Guid GetEntityId(DeleteMatchRuleCommand request)
        {
            return request.RuleId;
        }

        protected override IGenericRepository<MatchRule> GetRepository(IUnitOfWork unitOfWork)
        {
            return unitOfWork.MatchRuleRepository;
        }
    }
}
