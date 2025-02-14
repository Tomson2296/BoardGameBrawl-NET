using BoardGameBrawl.Application.Contracts.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerSchedule.Commands.ClearDay
{
    public class ClearDayCommandHandler : IRequestHandler<ClearDayCommand, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public ClearDayCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(ClearDayCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await unitOfWork.PlayerScheduleRepository.ClearDayAsync(request.playerId, request.day, cancellationToken);
            await unitOfWork.CommitChangesAsync();
            return Unit.Value;
        }
    }
}
