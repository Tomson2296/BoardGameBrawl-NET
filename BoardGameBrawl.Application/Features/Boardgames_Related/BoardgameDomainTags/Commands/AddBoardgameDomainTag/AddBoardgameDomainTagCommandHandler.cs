using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Responses;
using BoardGameBrawl.Application.Validators.Boardgames_Related.BoardgameDomainTags;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameDomainTags.Commands.AddBoardgameDomainTag
{
    public class AddBoardgameDomainTagCommandHandler : IRequestHandler<AddBoardgameDomainTagCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddBoardgameDomainTagCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(AddBoardgameDomainTagCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new AddBoardgameDomainTagsValidator();
            var validationResult = await validator.ValidateAsync(request.BoardgameDomainTagDTO, cancellationToken);

            if (!validationResult.IsValid)
            {
                return new BaseCommandResponse
                {
                    Success = false,
                    Message = "Creation Failed",
                    Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList()
                };
            }
            else
            {
                var boardgameDomainTag = _mapper.Map<BoardgameDomainTag>(request.BoardgameDomainTagDTO);

                await _unitOfWork.BoardgameDomainTagsRepository.AddEntity(boardgameDomainTag, cancellationToken);
                await _unitOfWork.CommitChangesAsync();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = Guid.NewGuid();
            }
            return response;
        }
    }
}
