using BoardGameBrawl.Application.Contracts.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Group_Related.GroupParticipants.Queries.GetGroupAdminStatus
{
    public class GetGroupAdminStatusQueryHandler : IRequestHandler<GetGroupAdminStatusQuery, bool>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetGroupAdminStatusQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(GetGroupAdminStatusQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await unitOfWork.GroupParticipantRepository.GetAdminStatusAsync(request.GroupId, request.PlayerId, cancellationToken);
        }
    }
}
