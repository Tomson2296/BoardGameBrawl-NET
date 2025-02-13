using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related.Schedule_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerSchedule.Queries.GetAvailablePlayers
{
    public class GetAvailablePlayersQueryHandler : IRequestHandler<GetAvailablePlayersQuery, IEnumerable<NavPlayerDTO>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAvailablePlayersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<NavPlayerDTO>> Handle(GetAvailablePlayersQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var players = await unitOfWork.PlayerScheduleRepository.GetAvailablePlayersAsync(request.day, 
              request.startTime, request.endTime, cancellationToken);
            return mapper.Map<IEnumerable<NavPlayerDTO>>(players);
        }
    }
}
