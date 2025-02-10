using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameModerators.Queries.GetBoardgameModerator
{
    public class GetBoardgameModeratorQueryHandler : IRequestHandler<GetBoardgameModeratorQuery, BoardgameModeratorDTO>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetBoardgameModeratorQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<BoardgameModeratorDTO> Handle(GetBoardgameModeratorQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var boardgameModerator = await unitOfWork.BoardgameModeratorsRepository.GetBoardgameModeratorAsync(
                request.ModeratorId, request.BoardgameId, cancellationToken);
            return mapper.Map<BoardgameModeratorDTO>(boardgameModerator);
        }
    }
}
