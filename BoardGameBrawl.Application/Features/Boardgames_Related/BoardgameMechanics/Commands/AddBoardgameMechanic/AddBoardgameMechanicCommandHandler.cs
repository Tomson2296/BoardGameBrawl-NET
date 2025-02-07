using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Responses;
using BoardGameBrawl.Application.Validators.Boardgames_Related.BoardgameCategories;
using BoardGameBrawl.Application.Validators.Boardgames_Related.BoardgameMechanics;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameMechanics.Commands.AddBoardgameMechanic
{
    public class AddBoardgameMechanicCommandHandler : IRequestHandler<AddBoardgameMechanicCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddBoardgameMechanicCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(AddBoardgameMechanicCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new AddBoardgameMechanicValidator(_unitOfWork.BoardgameMechanicsRepository);
            var validationResult = await validator.ValidateAsync(request.BoardgameMechanicDTO, cancellationToken);

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
                var boardgameMechanic = _mapper.Map<BoardgameMechanic>(request.BoardgameMechanicDTO);

                await _unitOfWork.BoardgameMechanicsRepository.AddEntity(boardgameMechanic, cancellationToken);
                await _unitOfWork.CommitChangesAsync();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = boardgameMechanic.Id;
            }

            return response;
        }
    }
}
