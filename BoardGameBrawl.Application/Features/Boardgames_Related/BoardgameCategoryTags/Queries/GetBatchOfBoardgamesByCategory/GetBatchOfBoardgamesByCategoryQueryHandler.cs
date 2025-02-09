using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameCategoryTags.Queries.GetBatchOfBoardgamesByCategory
{
    public class GetBatchOfBoardgamesByCategoryQueryHandler : IRequestHandler<GetBatchOfBoardgamesByCategoryQuery, IList<NavBoardgameDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBatchOfBoardgamesByCategoryQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<NavBoardgameDTO>> Handle(GetBatchOfBoardgamesByCategoryQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await _unitOfWork.BoardgameCategoryTagsRepository.GetBatchOfBoardgamesByCategoryAsync(request.CategoryId,
                request.Size, request.Skip, cancellationToken);
        }
    }
}
