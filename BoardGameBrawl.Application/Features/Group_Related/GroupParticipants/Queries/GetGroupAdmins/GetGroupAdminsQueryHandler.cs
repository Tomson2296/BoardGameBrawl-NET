using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Group_Related.GroupParticipants.Queries.GetGroupAdmins
{
    public class GetGroupAdminsQueryHandler : IRequestHandler<GetGroupAdminsQuery, IList<NavPlayerDTO>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetGroupAdminsQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IList<NavPlayerDTO>> Handle(GetGroupAdminsQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await unitOfWork.GroupParticipantRepository.GetAllGroupAdminsAsync(request.GroupId, cancellationToken);
        }
    }
}
