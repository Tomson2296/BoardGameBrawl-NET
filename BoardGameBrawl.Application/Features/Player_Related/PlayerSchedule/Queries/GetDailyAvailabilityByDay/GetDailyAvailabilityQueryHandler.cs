using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related.Schedule_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerSchedule.Queries.GetDailyAvailabilityByDay
{
    public class GetDailyAvailabilityQueryHandler : IRequestHandler<GetDailyAvailabilityQuery, DailyAvailabilityDTO>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetDailyAvailabilityQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<DailyAvailabilityDTO> Handle(GetDailyAvailabilityQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var daily = await unitOfWork.PlayerScheduleRepository.GetDailyAvailabilityAsync(request.PlayerId,
                request.DayOfWeek, cancellationToken);
            return mapper.Map<DailyAvailabilityDTO>(daily);
        }
    }
}
