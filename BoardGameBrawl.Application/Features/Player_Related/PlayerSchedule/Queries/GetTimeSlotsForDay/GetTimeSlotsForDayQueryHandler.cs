using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related.Schedule_Related;
using BoardGameBrawl.Domain.Entities.Player_Related.Schedule_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerSchedule.Queries.GetTimeSlotsForDay
{
    public class GetTimeSlotsForDayQueryHandler : IRequestHandler<GetTimeSlotsForDayQuery, IEnumerable<TimeSlotDTO>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetTimeSlotsForDayQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<TimeSlotDTO>> Handle(GetTimeSlotsForDayQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var timeSlots = await unitOfWork.PlayerScheduleRepository.GetTimeSlotsForDayAsync(request.PlayerId, 
                request.DayOfWeek, cancellationToken);
            return mapper.Map<IEnumerable<TimeSlotDTO>>(timeSlots);
        }
    }
}
