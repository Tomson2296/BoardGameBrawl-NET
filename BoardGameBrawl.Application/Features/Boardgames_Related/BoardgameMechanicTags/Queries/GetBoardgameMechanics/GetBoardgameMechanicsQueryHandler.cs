using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameMechanicTags.Queries.GetBoardgameMechanics
{
    public class GetBoardgameMechanicsQueryHandler : IRequestHandler<GetBoardgameMechanicsQuery, IList<BoardgameMechanicDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBoardgameMechanicsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<BoardgameMechanicDTO>> Handle(GetBoardgameMechanicsQuery request,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await _unitOfWork.BoardgameMechanicsTagsRepository.GetBoardgameMechanicsByGameAsync(request.BoardgameId, cancellationToken);
        }
    }
}
