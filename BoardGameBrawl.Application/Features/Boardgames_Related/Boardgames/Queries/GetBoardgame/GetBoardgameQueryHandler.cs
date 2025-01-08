using AutoMapper;
using BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.Boardgames.Queries.GetBoardgame
{
    public class GetBoardgameQueryHandler : IRequestHandler<GetBoardgameQuery, BoardgameDTO>
    {
        private readonly IBoardgameRepository _boardgameRepository;
        private readonly IMapper _mapper;

        public GetBoardgameQueryHandler(IBoardgameRepository boardgameRepository, IMapper mapper)
        {
            _boardgameRepository = boardgameRepository;
            _mapper = mapper;
        }

        public async Task<BoardgameDTO> Handle(GetBoardgameQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var boardgame = await _boardgameRepository.GetEntity(request.Id);
            return _mapper.Map<BoardgameDTO>(boardgame);
        }
    }
}
