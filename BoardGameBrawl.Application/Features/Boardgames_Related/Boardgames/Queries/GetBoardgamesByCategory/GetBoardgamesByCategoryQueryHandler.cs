using AutoMapper;
using BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.Boardgames.Queries.GetBoardgamesByCategory
{
    public class GetBoardgamesByCategoryQueryHandler : IRequestHandler<GetBoardgamesByCategoryQuery, ICollection<BoardgameDTO>>
    {
        private readonly IBoardgameCategoryTagsRepository _boardgameCategoryTagsRepository;
        private readonly IMapper _mapper;

        public GetBoardgamesByCategoryQueryHandler(IBoardgameCategoryTagsRepository boardgameCategoryTagsRepository, IMapper mapper)
        {
            _boardgameCategoryTagsRepository = boardgameCategoryTagsRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<BoardgameDTO>> Handle(GetBoardgamesByCategoryQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var boardgames = await _boardgameCategoryTagsRepository.GetBoardgamesByCategoryAsync(request.CategoryId);
            return _mapper.Map<ICollection<BoardgameDTO>>(boardgames);
        }
    }
}
