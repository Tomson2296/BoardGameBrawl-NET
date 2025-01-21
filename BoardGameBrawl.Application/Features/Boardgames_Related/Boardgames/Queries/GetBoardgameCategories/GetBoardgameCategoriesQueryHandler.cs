using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;
using System.Collections;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.Boardgames.Queries.GetBoardgameCategories
{
    public class GetBoardgameCategoriesQueryHandler : IRequestHandler<GetBoardgameCategoriesQuery, ICollection<BoardgameCategoryDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBoardgameCategoriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ICollection<BoardgameCategoryDTO>> Handle(GetBoardgameCategoriesQuery request, 
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var entities = await _unitOfWork.BoardgameCategoryTagsRepository.GetBoardgameCategoriesByGameAsync(request.BoardgameId);
            return _mapper.Map<ICollection<BoardgameCategoryDTO>>(entities);
        }
    }
}
