using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameModerators.Queries.GetAllPlayerModerations
{
    public class GetAllPlayerModerationsQueryHandler : IRequestHandler<GetAllPlayerModerationsQuery, IList<NavBoardgameDTO>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllPlayerModerationsQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IList<NavBoardgameDTO>> Handle(GetAllPlayerModerationsQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await unitOfWork.BoardgameModeratorsRepository.GetAllPlayerModerationsAsync(request.ModeratorId, cancellationToken);
        }
    }
}
