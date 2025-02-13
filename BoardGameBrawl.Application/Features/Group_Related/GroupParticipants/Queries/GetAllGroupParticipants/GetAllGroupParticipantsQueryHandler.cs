using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Group_Related.GroupParticipants.Queries.GetAllGroupParticipants
{
    internal class GetAllGroupParticipantsQueryHandler : IRequestHandler<GetAllGroupParticipantsQuery, IList<NavPlayerDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllGroupParticipantsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<NavPlayerDTO>> Handle(GetAllGroupParticipantsQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await _unitOfWork.GroupParticipantRepository.GetAllUserParticipantsInGroupByIdAsync(request.GroupId, cancellationToken);
        }
    }
}
