using BoardGameBrawl.Application.Contracts.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerFavouriteBGs.Queries.CheckIfPlayerFavouriteBGExists
{
    public class CheckIfPlayerFavouriteBGExistsQueryHandler : IRequestHandler<CheckIfPlayerFavouriteBGExistsQuery, bool>
    {
        private readonly IUnitOfWork unitOfWork;

        public CheckIfPlayerFavouriteBGExistsQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CheckIfPlayerFavouriteBGExistsQuery request, CancellationToken cancellationToken)
        {
            return await unitOfWork.PlayerFavouriteBGRepository.Exists(request.PlayerId, request.BoardgameId, cancellationToken);
        }
    }
}
