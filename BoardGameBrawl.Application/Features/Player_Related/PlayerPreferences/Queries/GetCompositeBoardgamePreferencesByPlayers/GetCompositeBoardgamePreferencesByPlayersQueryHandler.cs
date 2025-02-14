using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related.Preference_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerPreferences.Queries.GetCompositeBoardgamePreferencesByPlayers
{
    public class GetCompositeBoardgamePreferencesByPlayersQueryHandler : IRequestHandler<GetCompositeBoardgamePreferencesByPlayersQuery,
        IList<CompositeBoardgamePreferencesByPlayersDTO>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetCompositeBoardgamePreferencesByPlayersQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IList<CompositeBoardgamePreferencesByPlayersDTO>> Handle(GetCompositeBoardgamePreferencesByPlayersQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await unitOfWork.PlayerPreferenceRepository.GetBoardgamePreferencesByPlayers(request.BoardgameId, cancellationToken);
        }
    }
}
