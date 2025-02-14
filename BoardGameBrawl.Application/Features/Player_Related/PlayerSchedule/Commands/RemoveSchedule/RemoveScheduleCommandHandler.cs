using BoardGameBrawl.Application.Contracts.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerSchedule.Commands.RemoveSchedule
{
    public class RemoveScheduleCommandHandler : IRequestHandler<RemoveScheduleCommand, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public RemoveScheduleCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(RemoveScheduleCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            
            var targetedSchedule = await unitOfWork.PlayerScheduleRepository.GetPlayerScheduleByPlayerId(request.PlayerId, cancellationToken);
            
            if (targetedSchedule != null)
            {
                await unitOfWork.PlayerScheduleRepository.DeleteEntity(targetedSchedule, cancellationToken);
                await unitOfWork.CommitChangesAsync();
                return Unit.Value;
            }

            return Unit.Value;
        }
    }
}
