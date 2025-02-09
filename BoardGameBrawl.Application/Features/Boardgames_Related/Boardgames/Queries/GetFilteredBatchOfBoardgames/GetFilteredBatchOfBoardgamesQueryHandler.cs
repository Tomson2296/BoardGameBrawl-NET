using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.Boardgames.Queries.GetFilteredBatchOfBoardgames
{
    public class GetFilteredBatchOfBoardgamesQueryHandler : IRequestHandler<GetFilteredBatchOfBoardgamesQuery, IList<NavBoardgameDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetFilteredBatchOfBoardgamesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<NavBoardgameDTO>> Handle(GetFilteredBatchOfBoardgamesQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await _unitOfWork.BoardgameRepository.GetFilteredBatchOfBoardgamesAsync(request.Filter, 
                request.Size, request.Skip, cancellationToken);
        }
    }
}
