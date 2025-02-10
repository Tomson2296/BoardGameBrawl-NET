﻿using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerPreferences.Queries.GetAllBGPreferencesChosenByPlayers
{
    public class GetAllBGPreferencesChosenByPlayersQueryHandler : IRequestHandler<GetAllBGPreferencesChosenByPlayersQuery, IList<PlayerPreferenceDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllBGPreferencesChosenByPlayersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<PlayerPreferenceDTO>> Handle(GetAllBGPreferencesChosenByPlayersQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await _unitOfWork.PlayerPreferenceRepository.GetAllBoardgamePrefencesChosenByPlayersAsync(request.BoardgameId, cancellationToken);
        }
    }
}
