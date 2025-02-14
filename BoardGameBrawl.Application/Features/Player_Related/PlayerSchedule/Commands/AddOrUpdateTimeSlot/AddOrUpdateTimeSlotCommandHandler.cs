using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Responses;
using BoardGameBrawl.Application.Validators.Player_Related.Players;
using BoardGameBrawl.Application.Validators.Player_Related.Schedule_Related.TimeSlotValidators;
using BoardGameBrawl.Domain.Entities.Player_Related;
using BoardGameBrawl.Domain.Entities.Player_Related.Schedule_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerSchedule.Commands.AddOrUpdateTimeSlot
{
    public class AddOrUpdateTimeSlotCommandHandler : IRequestHandler<AddOrUpdateTimeSlotCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AddOrUpdateTimeSlotCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(AddOrUpdateTimeSlotCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var response = new BaseCommandResponse();
            var validator = new TimeSlotValidator();
            var validationResult = await validator.ValidateAsync(request.timeSlot);

            if (validationResult.IsValid == false)
            {
                return new BaseCommandResponse
                {
                    Success = false,
                    Message = "Creation Failed",
                    Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList()
                };
            }
            else
            {
                // map TimeSlotDTO -> TimeSlot
                var timeSlot = mapper.Map<TimeSlot>(request.timeSlot);

                await unitOfWork.PlayerScheduleRepository.AddOrUpdateTimeSlotAsync(request.playerId, request.day, timeSlot);
                await unitOfWork.CommitChangesAsync();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = Guid.NewGuid();
            }

            return response;
        }
    }
}
