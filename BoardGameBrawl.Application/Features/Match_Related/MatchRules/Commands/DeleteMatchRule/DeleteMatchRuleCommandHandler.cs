using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Exceptions;
using BoardGameBrawl.Application.Responses;
using BoardGameBrawl.Domain.Entities.Match_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Match_Related.MatchRules.Commands.DeleteMatchRule
{
    public class DeleteMatchRuleCommandHandler : IRequestHandler<DeleteMatchRuleCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteMatchRuleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(DeleteMatchRuleCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var response = new BaseCommandResponse();
            var matchRule = _mapper.Map<MatchRule>(request.MatchRuleDTO);

            var matchRuleInDB = await _unitOfWork.MatchRuleRepository.GetEntity(matchRule.RuleId);

            if (matchRuleInDB == null)
            {
                throw new NotFoundException(nameof(matchRuleInDB), matchRule.RuleId);
            }
            else
            {
                await _unitOfWork.MatchRuleRepository.DeleteEntity(matchRuleInDB);
                await _unitOfWork.CommitChangesAsync();

                response.Success = true;
                response.Message = "Match Rule removed successfully";
                response.Id = matchRule.RuleId;
            }

            return response;
        }
    }
}
