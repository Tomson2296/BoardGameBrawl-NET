using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerFavouriteBGs.Queries.GetPlayerFavouriteBG
{
    public class GetPlayerFavouriteBGQueryHandler : IRequestHandler<GetPlayerFavouriteBGQuery, PlayerFavouriteBGDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPlayerFavouriteBGQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PlayerFavouriteBGDTO> Handle(GetPlayerFavouriteBGQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var playerFavourite = await _unitOfWork.PlayerFavouriteBGRepository.GetPlayerFavouriteBGAsync(request.PlayerId,
                request.BoardgameId, cancellationToken);
            return _mapper.Map<PlayerFavouriteBGDTO>(playerFavourite);
        }
    }
}
