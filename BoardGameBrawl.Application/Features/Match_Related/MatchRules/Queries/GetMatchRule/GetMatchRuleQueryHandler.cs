using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Match_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Match_Related.MatchRules.Queries.GetMatchRule
{
    public class GetMatchRuleQueryHandler : IRequestHandler<GetMatchRuleQuery, MatchRuleDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetMatchRuleQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<MatchRuleDTO> Handle(GetMatchRuleQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var matchRule = await _unitOfWork.MatchRuleRepository.GetEntity(request.Id, cancellationToken);
            return _mapper.Map<MatchRuleDTO>(matchRule);
        }
    }
}
