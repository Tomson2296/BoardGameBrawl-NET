using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Responses;
using BoardGameBrawl.Application.Validators.Group_Related;
using BoardGameBrawl.Application.Validators.Match_Related;
using BoardGameBrawl.Domain.Entities.Match_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Match_Related.MatchRules.Commands.AddMatchRule
{
    public class AddMatchRuleCommandHandler : IRequestHandler<AddMatchRuleCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddMatchRuleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(AddMatchRuleCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var response = new BaseCommandResponse();
            var validator = new AddMatchRuleValidator();
            var validationResult = await validator.ValidateAsync(request.MatchRuleDTO);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var matchRule = _mapper.Map<MatchRule>(request.MatchRuleDTO);

                await _unitOfWork.MatchRuleRepository.AddEntity(matchRule, cancellationToken);
                await _unitOfWork.CommitChangesAsync();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = matchRule.RuleId;
            }

            return response;
        }
    }
}
