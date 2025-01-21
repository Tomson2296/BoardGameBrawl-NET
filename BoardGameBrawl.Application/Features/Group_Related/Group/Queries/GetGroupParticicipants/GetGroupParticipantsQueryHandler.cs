using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Group_Related.Group.Queries.GetGroupParticicipants
{
    public class GetGroupParticipantsQueryHandler : IRequestHandler<GetGroupParticipantsQuery, ICollection<PlayerDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetGroupParticipantsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ICollection<PlayerDTO>> Handle(GetGroupParticipantsQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var players = await _unitOfWork.GroupParticipantRepository.GetAllUserParticipantsInGroupByIdAsync(request.GroupId);
            return _mapper.Map<ICollection<PlayerDTO>>(players);
        }
    }
}
