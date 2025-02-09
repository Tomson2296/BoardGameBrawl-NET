using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameMechanicTags.Queries.GetBoardgamesByMechanic
{
    public class GetBoardgamesByMechanicQueryHandler : IRequestHandler<GetBoardgamesByMechanicQuery, IList<NavBoardgameDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBoardgamesByMechanicQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<NavBoardgameDTO>> Handle(GetBoardgamesByMechanicQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await _unitOfWork.BoardgameMechanicsTagsRepository.GetBoardgamesByMechanicAsync(request.MechanicId, cancellationToken);
        }
    }
}
