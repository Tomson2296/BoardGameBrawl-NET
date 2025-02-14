using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related.Preference_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerPreferences.Queries.GetAllPlayerPreferences
{
    public class GetAllPlayerPreferencesQueryHandler : IRequestHandler<GetAllPlayerPreferencesQuery, IList<PlayerPreferenceDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllPlayerPreferencesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<PlayerPreferenceDTO>> Handle(GetAllPlayerPreferencesQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await _unitOfWork.PlayerPreferenceRepository.GetAllPlayerPreferencesAsync(request.PlayerId, cancellationToken);
        }
    }
}
