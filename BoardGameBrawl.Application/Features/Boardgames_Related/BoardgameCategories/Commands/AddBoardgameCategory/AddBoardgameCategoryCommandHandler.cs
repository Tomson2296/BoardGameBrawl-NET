using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Responses;
using BoardGameBrawl.Application.Validators.Boardgames_Related.BoardgameCategories;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameCategories.Commands.AddBoardgameCategory
{
    public class AddBoardgameCategoryCommandHandler : IRequestHandler<AddBoardgameCategoryCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddBoardgameCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(AddBoardgameCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new AddBoardgameCategoryValidator(_unitOfWork.BoardgameCategoriesRepository);
            var validationResult = await validator.ValidateAsync(request.BoardgameCategoryDTO, cancellationToken);

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
                var boardgameCategory = _mapper.Map<BoardgameCategory>(request.BoardgameCategoryDTO);

                await _unitOfWork.BoardgameCategoriesRepository.AddEntity(boardgameCategory, cancellationToken);
                await _unitOfWork.CommitChangesAsync();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = boardgameCategory.Id;
            }

            return response;
        }
    }
}
