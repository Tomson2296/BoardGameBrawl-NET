using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Group_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Group_Related.Group.Queries.GetBatchOfGroups
{
    public class GetBatchOfGroupsQueryHandler : IRequestHandler<GetBatchOfGroupsQuery, ICollection<GroupDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBatchOfGroupsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ICollection<GroupDTO>> Handle(GetBatchOfGroupsQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var groups = await _unitOfWork.GroupRepository.GetBatchOfEntities(request.Size, request.Skip);
            return _mapper.Map<ICollection<GroupDTO>>(groups);
        }
    }
}
