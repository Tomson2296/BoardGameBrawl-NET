using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Group_Related.Group.Queries.GetGroupParticicipants
{
    public class GetGroupParticipantsQueryHandler : IRequestHandler<GetGroupParticipantsQuery, ICollection<NavPlayerDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetGroupParticipantsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ICollection<NavPlayerDTO>> Handle(GetGroupParticipantsQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await _unitOfWork.GroupParticipantRepository.GetAllUserParticipantsInGroupByIdAsync(request.GroupId);
        }
    }
}
