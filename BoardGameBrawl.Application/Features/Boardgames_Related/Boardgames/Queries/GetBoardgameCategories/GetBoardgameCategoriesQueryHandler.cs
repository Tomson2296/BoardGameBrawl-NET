using AutoMapper;
using BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;
using System.Collections;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.Boardgames.Queries.GetBoardgameCategories
{
    public class GetBoardgameCategoriesQueryHandler : IRequestHandler<GetBoardgameCategoriesQuery, ICollection<BoardgameCategoryDTO>>
    {
        private readonly IBoardgameCategoryTagsRepository _boardgameCategoryTagsRepository;
        private readonly IMapper _mapper;

        public GetBoardgameCategoriesQueryHandler(IBoardgameCategoryTagsRepository boardgameCategoryTagsRepository,
            IMapper mapper)
        {
            _boardgameCategoryTagsRepository = boardgameCategoryTagsRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<BoardgameCategoryDTO>> Handle(GetBoardgameCategoriesQuery request, 
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var entities = await _boardgameCategoryTagsRepository.GetBoardgameCategoriesByGameAsync(request.BoardgameId);
            return _mapper.Map<ICollection<BoardgameCategoryDTO>>(entities);
        }
    }
}
