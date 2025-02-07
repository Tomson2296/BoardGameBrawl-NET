using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Responses;
using BoardGameBrawl.Application.Validators.Boardgames_Related.BoardgameCategoryTags;
using BoardGameBrawl.Application.Validators.Boardgames_Related.BoardgameMechanicTags;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameMechanicTags.Commands.AddBoardgameMechanicTag
{
    public class AddBoardgameMechanicTagCommandHandler : IRequestHandler<AddBoardgameMechanicTagCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddBoardgameMechanicTagCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(AddBoardgameMechanicTagCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new AddBoardgameMechanicTagsValidator();
            var validationResult = await validator.ValidateAsync(request.BoardgameMechanicTagDTO, cancellationToken);

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
                var boardgameMechanicTag = _mapper.Map<BoardgameMechanicTag>(request.BoardgameMechanicTagDTO);

                await _unitOfWork.BoardgameMechanicsTagsRepository.AddEntity(boardgameMechanicTag, cancellationToken);
                await _unitOfWork.CommitChangesAsync();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = Guid.NewGuid();
            }
            return response;
        }
    }
}
