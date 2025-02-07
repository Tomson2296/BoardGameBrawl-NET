using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Responses;
using BoardGameBrawl.Application.Validators.Boardgames_Related.BoardgameCategories;
using BoardGameBrawl.Application.Validators.Boardgames_Related.BoardgameCategoryTags;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameCategoryTags.Commands.AddBoardgameCategoryTag
{
    public class AddBoardgameCategoryTagCommandHandler : IRequestHandler<AddBoardgameCategoryTagCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddBoardgameCategoryTagCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(AddBoardgameCategoryTagCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new AddBoardgameCategoryTagsValidator(_unitOfWork.BoardgameCategoryTagsRepository);
            var validationResult = await validator.ValidateAsync(request.BoardgameCategoryTagDTO, cancellationToken);

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
                var boardgameCategoryTag = _mapper.Map<BoardgameCategoryTag>(request.BoardgameCategoryTagDTO);

                await _unitOfWork.BoardgameCategoryTagsRepository.AddEntity(boardgameCategoryTag, cancellationToken);
                await _unitOfWork.CommitChangesAsync();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = Guid.NewGuid();
            }
            return response;
        }
    }
}
