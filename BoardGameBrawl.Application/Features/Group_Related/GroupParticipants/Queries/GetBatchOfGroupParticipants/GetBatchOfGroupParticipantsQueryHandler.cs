using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Group_Related.GroupParticipants.Queries.GetBatchOfGroupParticipants
{
    public class GetBatchOfGroupParticipantsQueryHandler : IRequestHandler<GetBatchOfGroupParticipantsQuery, IList<NavPlayerDTO>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetBatchOfGroupParticipantsQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IList<NavPlayerDTO>> Handle(GetBatchOfGroupParticipantsQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await unitOfWork.GroupParticipantRepository.GetBatchOfUserParticipantsInGroupByIdAsync(request.GroupId,
                request.Size, request.Skip, cancellationToken);
        }
    }
}
