using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related.Preference_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerPreferences.Queries.GetCompositePlayerBoardgamePreferences
{
    public class GetCompositePlayerPreferencesQueryHandler : IRequestHandler<GetCompositePlayerPreferencesQuery, IList<CompositePlayerBoardgamePreferencesDTO>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetCompositePlayerPreferencesQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IList<CompositePlayerBoardgamePreferencesDTO>> Handle(GetCompositePlayerPreferencesQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await unitOfWork.PlayerPreferenceRepository.GetCompositePlayerBoardgamePreferences(request.PlayerId, cancellationToken);
        }
    }
}
