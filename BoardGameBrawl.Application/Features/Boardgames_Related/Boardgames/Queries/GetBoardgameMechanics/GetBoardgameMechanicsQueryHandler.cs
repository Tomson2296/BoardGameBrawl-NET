using AutoMapper;
using BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.Boardgames.Queries.GetBoardgameMechanics
{
    public class GetBoardgameMechanicsQueryHandler : IRequestHandler<GetBoardgameMechanicsQuery, ICollection<BoardgameMechanicDTO>>
    {
        private readonly IBoardgameMechanicTagsRepository _boardgameMechanicTagsRepository;
        private readonly IMapper _mapper;

        public GetBoardgameMechanicsQueryHandler(IBoardgameMechanicTagsRepository boardgameMechanicTagsRepository, 
            IMapper mapper)
        {
            _boardgameMechanicTagsRepository = boardgameMechanicTagsRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<BoardgameMechanicDTO>> Handle(GetBoardgameMechanicsQuery request, 
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var entities = await _boardgameMechanicTagsRepository.GetBoardgameMechanicsByGameAsync(request.BoardgameId);
            return _mapper.Map<ICollection<BoardgameMechanicDTO>>(entities);
        }
    }
}
