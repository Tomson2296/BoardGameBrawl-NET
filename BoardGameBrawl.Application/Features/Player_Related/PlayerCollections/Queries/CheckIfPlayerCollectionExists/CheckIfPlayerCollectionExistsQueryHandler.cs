#nullable disable
using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerCollections.Queries.CheckIfPlayerCollectionExists
{
    public class CheckIfPlayerCollectionExistsQueryHandler : IRequestHandler<CheckIfPlayerCollectionExistsQuery, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CheckIfPlayerCollectionExistsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CheckIfPlayerCollectionExistsQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var player = await _unitOfWork.PlayerRepository.GetPlayerByApplicationUserIdAsync(request.ApplicationUserId, cancellationToken);
            return await _unitOfWork.PlayerCollectionRepository.CheckIfExistsByPlayerId(player.Id, cancellationToken);  
        }
    }
}
