using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.Boardgames.Queries.GetBoardgamesByCategory
{
    public class GetBoardgamesByCategoryQueryHandler : IRequestHandler<GetBoardgamesByCategoryQuery, ICollection<BoardgameDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBoardgamesByCategoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ICollection<BoardgameDTO>> Handle(GetBoardgamesByCategoryQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var boardgames = await _unitOfWork.BoardgameCategoryTagsRepository.GetBoardgamesByCategoryAsync(request.CategoryId, cancellationToken);
            return _mapper.Map<ICollection<BoardgameDTO>>(boardgames);
        }
    }
}
