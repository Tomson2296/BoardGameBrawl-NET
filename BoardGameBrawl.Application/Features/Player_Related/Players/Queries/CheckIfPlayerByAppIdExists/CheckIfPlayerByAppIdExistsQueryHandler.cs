using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Domain.Entities.Player_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.Players.Queries.CheckIfPlayerByAppIdExists
{
    public class CheckIfPlayerByAppIdExistsQueryHandler : IRequestHandler<CheckIfPlayerByAppIdExistsQuery, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CheckIfPlayerByAppIdExistsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(CheckIfPlayerByAppIdExistsQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var player = mapper.Map<Player>(request.PlayerDTO);
            return await unitOfWork.PlayerRepository.CheckIfPlayerExistsByAppId(player.ApplicationUserId, cancellationToken);
        }
    }
}
