using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Group_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Group_Related.Group.Queries.GetAllGroupsByPlayer
{
    public class GetAllGroupsByPlayerQueryHandler : IRequestHandler<GetAllGroupsByPlayerQuery, ICollection<GroupDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllGroupsByPlayerQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ICollection<GroupDTO>> Handle(GetAllGroupsByPlayerQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var groups = await _unitOfWork.GroupParticipantRepository.GetAllPlayerGroupsByIdAsync(request.PlayerId);
            return _mapper.Map<ICollection<GroupDTO>>(groups);
        }
    }
}
