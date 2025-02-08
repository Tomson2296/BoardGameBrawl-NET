using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerPreferences.Queries.GetPlayerPreferenceByBoardgame
{
    public class GetPlayerPreferenceByBoardgameQueryHandler : IRequestHandler<GetPlayerPreferenceByBoardgameQuery, PlayerPreferenceDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPlayerPreferenceByBoardgameQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PlayerPreferenceDTO> Handle(GetPlayerPreferenceByBoardgameQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var playerPreference = await _unitOfWork.PlayerPreferenceRepository.GetPlayerPreferenceByBoardgameIdAsync(request.PlayerId, 
                request.BoardgameId, cancellationToken);
            return _mapper.Map<PlayerPreferenceDTO>(playerPreference);
        }
    }
}
