using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameCategoryTags.Queries.GetBoardgamesByCategory
{
    public class GetBoardgamesByCategoryQueryHandler : IRequestHandler<GetBoardgamesByCategoryQuery, IList<NavBoardgameDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBoardgamesByCategoryQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<NavBoardgameDTO>> Handle(GetBoardgamesByCategoryQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await _unitOfWork.BoardgameCategoryTagsRepository.GetBoardgamesByCategoryAsync(request.CategoryId, cancellationToken);
        }
    }
}
