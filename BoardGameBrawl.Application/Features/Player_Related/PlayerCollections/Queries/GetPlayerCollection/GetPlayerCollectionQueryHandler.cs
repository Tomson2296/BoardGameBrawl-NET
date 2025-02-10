using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerCollections.Queries.GetPlayerCollection
{
    public class GetPlayerCollectionQueryHandler : IRequestHandler<GetPlayerCollectionQuery, PlayerCollectionDTO?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPlayerCollectionQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PlayerCollectionDTO?> Handle(GetPlayerCollectionQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await _unitOfWork.PlayerCollectionRepository.GetPlayerCollectionByIdAsync(request.Id, cancellationToken);
        }
    }
}
