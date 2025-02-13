using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related.Schedule_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerSchedule.Queries.GetPlayerScheduleByPlayerId
{
    public class GetPlayerScheduleByPlayerIdQueryHandler : IRequestHandler<GetPlayerScheduleByPlayerIdQuery, PlayerScheduleDTO>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetPlayerScheduleByPlayerIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<PlayerScheduleDTO> Handle(GetPlayerScheduleByPlayerIdQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var playerSchedule = await unitOfWork.PlayerScheduleRepository.GetPlayerScheduleByPlayerId(request.PlayerId, cancellationToken);
            return mapper.Map<PlayerScheduleDTO>(playerSchedule);
        }
    }
}
