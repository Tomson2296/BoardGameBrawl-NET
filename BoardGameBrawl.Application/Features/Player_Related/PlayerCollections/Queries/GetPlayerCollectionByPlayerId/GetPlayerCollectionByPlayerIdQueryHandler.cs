using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Application.Features.Player_Related.PlayerCollections.Queries.GetPlayerCollection;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerCollections.Queries.GetPlayerCollectionByPlayerId
{
    public class GetPlayerCollectionByPlayerIdQueryHandler : IRequestHandler<GetPlayerCollectionQuery, PlayerCollectionDTO?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPlayerCollectionByPlayerIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PlayerCollectionDTO?> Handle(GetPlayerCollectionQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var player = await _unitOfWork.PlayerRepository.GetEntity(request.Id, cancellationToken);
            return await _unitOfWork.PlayerCollectionRepository.GetPlayerCollectionByPlayerIdAsync(player.Id, cancellationToken);
        }
    }
}
