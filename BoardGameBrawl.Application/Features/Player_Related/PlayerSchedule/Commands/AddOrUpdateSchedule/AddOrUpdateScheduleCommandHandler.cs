using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Responses;
using BoardGameBrawl.Domain.Entities.Player_Related.Schedule_Related;
using BoardGameBrawl.Application.Validators.Player_Related.Schedule_Related.PlayerScheduleValidators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerSchedule.Commands.AddOrUpdateSchedule
{
    public class AddOrUpdateScheduleCommandHandler : IRequestHandler<AddOrUpdateScheduleCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AddOrUpdateScheduleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(AddOrUpdateScheduleCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var response = new BaseCommandResponse();
            var validator = new PlayerScheduleValidator();
            var validationResult = await validator.ValidateAsync(request.PlayerScheduleDTO, options => options.IncludeRuleSets("Creation"));

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
                var schedule = mapper.Map<BoardGameBrawl.Domain.Entities.Player_Related.Schedule_Related.PlayerSchedule>(request.PlayerScheduleDTO);

                await unitOfWork.PlayerScheduleRepository.AddOrUpdateAsync(schedule, cancellationToken);
                await unitOfWork.CommitChangesAsync();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = schedule.Id;
            }

            return response;
        }
    }
}
