using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerSchedule.Commands.RemoveTimeSlot
{
    public class RemoveTimeSlotCommandHandler : IRequestHandler<RemoveTimeSlotCommand, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public RemoveTimeSlotCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(RemoveTimeSlotCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var response = new BaseCommandResponse();
            await unitOfWork.PlayerScheduleRepository.RemoveTimeSlotAsync(request.TimeSlotId, cancellationToken);
            await unitOfWork.CommitChangesAsync();
            return Unit.Value;
        }
    }
}
