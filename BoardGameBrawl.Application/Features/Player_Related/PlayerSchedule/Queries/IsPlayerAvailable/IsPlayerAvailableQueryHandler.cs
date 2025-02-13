using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related.Schedule_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerSchedule.Queries.IsPlayerAvailable
{
    public class IsPlayerAvailableQueryHandler : IRequestHandler<IsPlayerAvailableQuery, bool>
    {
        private readonly IUnitOfWork unitOfWork;

        public IsPlayerAvailableQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(IsPlayerAvailableQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await unitOfWork.PlayerScheduleRepository.IsAvailableAsync(request.PlayerId, request.day,
                request.startTime, request.endTime, cancellationToken);
        }
    }
}
