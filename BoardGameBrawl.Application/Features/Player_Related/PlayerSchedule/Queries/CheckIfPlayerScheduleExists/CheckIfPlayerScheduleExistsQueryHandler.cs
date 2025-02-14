using BoardGameBrawl.Application.Contracts.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerSchedule.Queries.CheckIfPlayerScheduleExists
{
    public class CheckIfPlayerScheduleExistsQueryHandler : IRequestHandler<CheckIfPlayerScheduleExistsQuery, bool>
    {
        private readonly IUnitOfWork unitOfWork;

        public CheckIfPlayerScheduleExistsQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CheckIfPlayerScheduleExistsQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await unitOfWork.PlayerScheduleRepository.CheckIfPlayerScheduleExists(request.PlayerId, cancellationToken);
        }
    }
}
