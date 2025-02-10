using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Match_Related;
using BoardGameBrawl.Application.Features.Common.Commands.AddEntity;
using BoardGameBrawl.Application.Validators.Match_Related;
using BoardGameBrawl.Domain.Entities.Match_Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Common.Concrete.Commands.AddEntity.MatchRuleEntity
{
    public class AddMatchRuleCommandHandler : AddEntityCommandHandler<AddMatchRuleCommand, MatchRuleDTO, MatchRule, AddMatchRuleValidator>
    {
        public AddMatchRuleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        protected override MatchRuleDTO GetEntityDTOFromRequest(AddMatchRuleCommand request)
        {
            return request.EntityDTO;
        }

        protected override Guid GetEntityId(MatchRule entity)
        {
            return entity.RuleId;
        }

        protected override AddMatchRuleValidator GetEntityValidator()
        {
            return new AddMatchRuleValidator();
        }

        protected override IGenericRepository<MatchRule> GetRepository(IUnitOfWork unitOfWork)
        {
            return unitOfWork.MatchRuleRepository;
        }

        protected override AddMatchRuleValidator GetValidatorRequiringRepo(IGenericRepository<MatchRule> repository)
        {
            throw new NotImplementedException();
        }
    }
}
