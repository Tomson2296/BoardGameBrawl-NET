using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related.Preference_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerPreferences.Queries.GetPlayerPreferenceByBoardgame
{
    public class GetPlayerPreferenceQueryHandler : IRequestHandler<GetPlayerPreferenceQuery, PlayerPreferenceDTO>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPlayerPreferenceQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PlayerPreferenceDTO> Handle(GetPlayerPreferenceQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await _unitOfWork.PlayerPreferenceRepository.GetPlayerPreferenceAsync(request.PlayerId, 
                request.BoardgameId, cancellationToken);
        }
    }
}
