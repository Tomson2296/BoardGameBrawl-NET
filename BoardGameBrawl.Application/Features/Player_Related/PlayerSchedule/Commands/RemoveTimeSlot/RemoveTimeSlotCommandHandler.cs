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
    public class RemoveTimeSlotCommandHandler : IRequestHandler<RemoveTimeSlotCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork unitOfWork;

        public RemoveTimeSlotCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse> Handle(RemoveTimeSlotCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            
            var response = new BaseCommandResponse();

            var timeSlot = await unitOfWork.PlayerScheduleRepository.GetTimeSlotAsync(request.TimeSlotId, cancellationToken);

            if (timeSlot == null)
            {
                response.Success = false;
                response.Message = "Removing Process Unsuccessful - Time slot not found";
                response.Id = Guid.NewGuid();
                return response;
            }
            else
            {
                await unitOfWork.PlayerScheduleRepository.RemoveTimeSlotAsync(request.TimeSlotId, cancellationToken);
                await unitOfWork.CommitChangesAsync();

                response.Success = true;
                response.Message = "Removing Process Successful";
                response.Id = Guid.NewGuid();
            }

            return response;
        }
    }
}
