﻿using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Player_Related.Players.Queries.GetPlayer.GetBatchOfPlayers
{
    public class GetBatchOfPlayersQueryHandler : IRequestHandler<GetBatchOfPlayersQuery, IList<PlayerDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBatchOfPlayersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<PlayerDTO>> Handle(GetBatchOfPlayersQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var players = await _unitOfWork.PlayerRepository.GetBatchOfEntities(request.Size, request.Skip);
            return _mapper.Map<IList<PlayerDTO>>(players);
        }
    }
}
