using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameCategoryTags.Queries.GetBoardgameCategories
{
    public class GetBoardgameCategoriesQueryHandler : IRequestHandler<GetBoardgameCategoriesQuery, IList<BoardgameCategoryDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBoardgameCategoriesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<BoardgameCategoryDTO>> Handle(GetBoardgameCategoriesQuery request,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await _unitOfWork.BoardgameCategoryTagsRepository.GetBoardgameCategoriesByGameAsync(request.BoardgameId, cancellationToken);
        }
    }
}
