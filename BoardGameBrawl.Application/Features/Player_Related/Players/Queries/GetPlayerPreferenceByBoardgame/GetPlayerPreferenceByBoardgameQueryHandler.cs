using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Player_Related.Players.Queries.GetPlayerPreferenceByBoardgame
{
    public class GetPlayerPreferenceByBoardgameQueryHandler : IRequestHandler<GetPlayerPreferenceByBoardgameQuery, PlayerPreferenceDTO>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;

        public GetPlayerPreferenceByBoardgameQueryHandler(IUnitOfWork unitofwork, IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }

        public async Task<PlayerPreferenceDTO> Handle(GetPlayerPreferenceByBoardgameQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var boardgamePlayerPreference = await _unitofwork.PlayerPreferenceRepository.GetPlayerPreferenceByBoardgameIdAsync(request.PlayerId, request.BoardgameId);
            return _mapper.Map<PlayerPreferenceDTO>(boardgamePlayerPreference);
        }
    }
}
