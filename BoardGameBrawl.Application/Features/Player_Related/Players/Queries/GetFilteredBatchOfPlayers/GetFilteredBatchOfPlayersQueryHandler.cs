using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.Players.Queries.GetFilteredBatchOfPlayers
{
    public class GetFilteredBatchOfPlayersQueryHandler : IRequestHandler<GetFilteredBatchOfPlayersQuery, IList<NavPlayerDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetFilteredBatchOfPlayersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<NavPlayerDTO>> Handle(GetFilteredBatchOfPlayersQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var filteredPlayers = await _unitOfWork.PlayerRepository.GetFilteredBatchOfPlayersAsync(request.Filter,
                request.Size, request.Skip, cancellationToken);
            return _mapper.Map<IList<NavPlayerDTO>>(filteredPlayers);
        }
    }
}
