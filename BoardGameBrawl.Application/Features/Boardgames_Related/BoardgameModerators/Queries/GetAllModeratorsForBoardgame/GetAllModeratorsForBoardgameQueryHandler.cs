using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameModerators.Queries.GetAllModeratorsForBoardgame
{
    public class GetAllModeratorsForBoardgameQueryHandler : IRequestHandler<GetAllModeratorsForBoardgameQuery, IList<NavPlayerDTO>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllModeratorsForBoardgameQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IList<NavPlayerDTO>> Handle(GetAllModeratorsForBoardgameQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await unitOfWork.BoardgameModeratorsRepository.GetAllModeratorsForBoardgameAsync(request.BoardgameId, cancellationToken);
        }
    }
}
