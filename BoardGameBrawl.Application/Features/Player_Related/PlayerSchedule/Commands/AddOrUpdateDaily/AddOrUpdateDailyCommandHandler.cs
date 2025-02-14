using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Responses;
using BoardGameBrawl.Application.Validators.Player_Related.Schedule_Related.DailyAvailabilityValidators;
using BoardGameBrawl.Application.Validators.Player_Related.Schedule_Related.TimeSlotValidators;
using BoardGameBrawl.Domain.Entities.Player_Related.Schedule_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerSchedule.Commands.AddOrUpdateDaily
{
    public class AddOrUpdateDailyCommandHandler : IRequestHandler<AddOrUpdateDailyCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AddOrUpdateDailyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(AddOrUpdateDailyCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var response = new BaseCommandResponse();
            var validator = new DailyAvailabilityValidator();
            var validationResult = await validator.ValidateAsync(request.DailyAvailabilityDTO);

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
                // map DailyAvailabilityDTO -> DailyAvailability
                var daily = mapper.Map<DailyAvailability>(request.DailyAvailabilityDTO);

                await unitOfWork.PlayerScheduleRepository.AddOrUpdateDailyAvailabilityAsync(request.playerId, daily, cancellationToken);
                await unitOfWork.CommitChangesAsync();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = Guid.NewGuid();
            }

            return response;
        }
    }
}
