using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameMechanics.Queries.CheckIfBoardgameMechanicExists
{
    public class CheckIfBoardgameMechanicExistsQueryHandler : IRequestHandler<CheckIfBoardgameMechanicExistsQuery, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CheckIfBoardgameMechanicExistsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CheckIfBoardgameMechanicExistsQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var boardgameMechanic = _mapper.Map<BoardgameMechanic>(request.BoardgameMechanicDTO);
            return await _unitOfWork.BoardgameMechanicsRepository.Exists(boardgameMechanic, cancellationToken);
        }
    }
}
