using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerSchedule.Commands.RemoveSchedule
{
    public class RemoveScheduleCommandHandler : IRequestHandler<RemoveScheduleCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork unitOfWork;

        public RemoveScheduleCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse> Handle(RemoveScheduleCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var targetedSchedule = await unitOfWork.PlayerScheduleRepository.GetPlayerScheduleByPlayerId(request.PlayerId, cancellationToken);
            var response = new BaseCommandResponse();

            if (targetedSchedule != null)
            {
                await unitOfWork.PlayerScheduleRepository.DeleteEntity(targetedSchedule, cancellationToken);
                await unitOfWork.CommitChangesAsync();

                response.Success = true;
                response.Message = "Removing Process Successful";
                response.Id = request.PlayerId;
            }
            else
            {
                response.Success = false;
                response.Message = "Removing Process Unsuccessful - Player Schedule not found";
                response.Id = request.PlayerId;
                return response;
            }

            return response;
        }
    }
}
