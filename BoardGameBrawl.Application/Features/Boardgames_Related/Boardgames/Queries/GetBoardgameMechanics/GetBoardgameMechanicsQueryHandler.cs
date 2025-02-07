using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.Boardgames.Queries.GetBoardgameMechanics
{
    public class GetBoardgameMechanicsQueryHandler : IRequestHandler<GetBoardgameMechanicsQuery, ICollection<BoardgameMechanicDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBoardgameMechanicsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ICollection<BoardgameMechanicDTO>> Handle(GetBoardgameMechanicsQuery request, 
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var entities = await _unitOfWork.BoardgameMechanicsTagsRepository.GetBoardgameMechanicsByGameAsync(request.BoardgameId, cancellationToken);
            return _mapper.Map<ICollection<BoardgameMechanicDTO>>(entities);
        }
    }
}
