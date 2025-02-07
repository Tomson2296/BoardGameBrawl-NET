using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using MediatR;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameCategories.Queries.CheckIfBoardgameCategoryExists
{
    public class CheckIfBoardgameCategoryExistsQueryHandler : IRequestHandler<CheckIfBoardgameCategoryExistsQuery, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CheckIfBoardgameCategoryExistsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CheckIfBoardgameCategoryExistsQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var boardgame = _mapper.Map<BoardgameCategory>(request.BoardgameCategoryDTO);
            return await _unitOfWork.BoardgameCategoriesRepository.Exists(boardgame, cancellationToken);
        }
    }
}
