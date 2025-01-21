using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.Boardgames.Queries.GetBoardgame
{
    public class GetBoardgameQueryHandler : IRequestHandler<GetBoardgameQuery, BoardgameDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBoardgameQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BoardgameDTO> Handle(GetBoardgameQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var boardgame = await _unitOfWork.BoardgameRepository.GetEntity(request.Id);
            return _mapper.Map<BoardgameDTO>(boardgame);
        }
    }
}
