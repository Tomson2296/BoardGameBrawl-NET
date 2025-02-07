using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.Boardgames.Queries.GetBatchOfBoardgames
{
    public class GetBatchOfBoardgamesQueryHandler : IRequestHandler<GetBatchOfBoardgamesQuery, ICollection<BoardgameDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBatchOfBoardgamesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ICollection<BoardgameDTO>> Handle(GetBatchOfBoardgamesQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var boardgames = await _unitOfWork.BoardgameRepository.GetBatchOfEntities(request.Size, request.Skip, cancellationToken);
            return _mapper.Map<ICollection<BoardgameDTO>>(boardgames);
        }
    }
}
