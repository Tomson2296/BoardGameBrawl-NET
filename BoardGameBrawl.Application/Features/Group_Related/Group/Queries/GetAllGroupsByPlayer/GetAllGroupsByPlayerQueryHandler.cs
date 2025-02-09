using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Group_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Group_Related.Group.Queries.GetAllGroupsByPlayer
{
    public class GetAllGroupsByPlayerQueryHandler : IRequestHandler<GetAllGroupsByPlayerQuery, ICollection<GroupDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllGroupsByPlayerQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ICollection<GroupDTO>> Handle(GetAllGroupsByPlayerQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await _unitOfWork.GroupParticipantRepository.GetAllPlayerGroupsByIdAsync(request.PlayerId);
        }
    }
}
