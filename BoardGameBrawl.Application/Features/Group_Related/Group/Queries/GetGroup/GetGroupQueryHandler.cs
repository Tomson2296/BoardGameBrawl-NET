using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Group_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Group_Related.Group.Queries.GetGroup
{
    public class GetGroupQueryHandler : IRequestHandler<GetGroupQuery, GroupDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetGroupQueryHandler(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GroupDTO> Handle(GetGroupQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await _unitOfWork.GroupRepository.GetGroupByGroupName(request.GroupName);
        }
    }
}
