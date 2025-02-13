using BoardGameBrawl.Application.Contracts.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Group_Related.GroupParticipants.Queries.CheckIfUserIsParticipant
{
    public class CheckIfUserIsParticipantQueryHandler : IRequestHandler<CheckIfUserIsParticipantQuery, bool>
    {
        private readonly IUnitOfWork unitOfWork;

        public CheckIfUserIsParticipantQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CheckIfUserIsParticipantQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await unitOfWork.GroupParticipantRepository.CheckIfUserIsGroupParticipant(request.GroupId, request.PlayerId, cancellationToken);
        }
    }
}
