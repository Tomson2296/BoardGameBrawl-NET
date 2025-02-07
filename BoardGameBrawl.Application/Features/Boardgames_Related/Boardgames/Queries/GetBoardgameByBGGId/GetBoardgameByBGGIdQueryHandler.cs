using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.Boardgames.Queries.GetBoardgameByBGGId
{
    public class GetBoardgameByBGGIdQueryHandler : IRequestHandler<GetBoardgameByBGGIdQuery, BoardgameDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBoardgameByBGGIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        async Task<BoardgameDTO> IRequestHandler<GetBoardgameByBGGIdQuery, BoardgameDTO>.Handle(GetBoardgameByBGGIdQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var boardgame = await _unitOfWork.BoardgameRepository.GetEntityByBGGId(request.BGGId, cancellationToken);
            return _mapper.Map<BoardgameDTO>(boardgame);
        }
    }
}
