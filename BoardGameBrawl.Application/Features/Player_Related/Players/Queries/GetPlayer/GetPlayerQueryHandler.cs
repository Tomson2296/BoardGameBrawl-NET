using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Contracts.Entities.Player_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.Players.Queries.GetPlayer
{
    public class GetPlayerQueryHandler : IRequestHandler<GetPlayerQuery, PlayerDTO>
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;

        public GetPlayerQueryHandler(IPlayerRepository playerRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        }

        public async Task<PlayerDTO> Handle(GetPlayerQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var player = await _playerRepository.GetEntity(request.Id);
            return _mapper.Map<PlayerDTO>(player);
        }
    }
}
