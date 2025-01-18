using AutoMapper;
using BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.Boardgames.Queries.GetBoardgamesByMechanic
{
    public class GetBoardgamesByMechanicQueryHandler : IRequestHandler<GetBoardgamesByMechanicQuery, ICollection<BoardgameDTO>>
    {
        private readonly IBoardgameMechanicTagsRepository _boardgameMechanicTagsRepository;
        private readonly IMapper _mapper;
        
        public GetBoardgamesByMechanicQueryHandler(IBoardgameMechanicTagsRepository boardgameMechanicTagsRepository, 
            IMapper mapper)
        {
            _boardgameMechanicTagsRepository = boardgameMechanicTagsRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<BoardgameDTO>> Handle(GetBoardgamesByMechanicQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var boardgames = await _boardgameMechanicTagsRepository.GetBoardgamesByMechanicAsync(request.MechanicId);
            return _mapper.Map<ICollection<BoardgameDTO>>(boardgames);
        }
    }
}
