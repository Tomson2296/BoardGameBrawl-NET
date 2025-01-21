using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.Boardgames.Queries.GetBoardgamesByMechanic
{
    public class GetBoardgamesByMechanicQueryHandler : IRequestHandler<GetBoardgamesByMechanicQuery, ICollection<BoardgameDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBoardgamesByMechanicQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ICollection<BoardgameDTO>> Handle(GetBoardgamesByMechanicQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var boardgames = await _unitOfWork.BoardgameMechanicsTagsRepository.GetBoardgamesByMechanicAsync(request.MechanicId);
            return _mapper.Map<ICollection<BoardgameDTO>>(boardgames);
        }
    }
}
