using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Player_Related.Players.Queries.GetBatchOfNavPlayers
{
    public class GetBatchOfNavPlayersQueryHandler : IRequestHandler<GetBatchOfNavPlayersQuery, IList<NavPlayerDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBatchOfNavPlayersQueryHandler(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<NavPlayerDTO>> Handle(GetBatchOfNavPlayersQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var players = await _unitOfWork.PlayerRepository.GetBatchOfEntities(request.Size, request.Skip);
            return _mapper.Map<IList<NavPlayerDTO>>(players);
        }
    }
}
