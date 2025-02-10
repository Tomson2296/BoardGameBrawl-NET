using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Match_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Match_Related.MatchRules.Queries.GetMatchRuleset
{
    public class GetMatchRulesetQueryHandler : IRequestHandler<GetMatchRulesetQuery, IList<MatchRuleDTO>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetMatchRulesetQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IList<MatchRuleDTO>> Handle(GetMatchRulesetQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await unitOfWork.MatchRuleRepository.GetMatchrulesetForBoardgame(request.BoardgameId, cancellationToken);
        }
    }
}
