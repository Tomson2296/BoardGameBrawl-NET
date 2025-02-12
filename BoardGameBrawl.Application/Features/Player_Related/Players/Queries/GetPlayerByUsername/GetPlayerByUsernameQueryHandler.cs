#nullable disable
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.Players.Queries.GetPlayerByUsername
{
    public class GetPlayerByUsernameQueryHandler : IRequestHandler<GetPlayerByUsernameQuery, PlayerDTO>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetPlayerByUsernameQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<PlayerDTO> Handle(GetPlayerByUsernameQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await unitOfWork.PlayerRepository.GetPlayerByUserNameAsync(request.Username, cancellationToken);
        }
    }
}
