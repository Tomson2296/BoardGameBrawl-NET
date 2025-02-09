using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameMechanicTags.Queries.GetBatchOfBoardgamesByMechanic
{
    public class GetBatchOfBoardgamesByMechanicQueryHandler : IRequestHandler<GetBatchOfBoardgamesByMechanicQuery, IList<NavBoardgameDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBatchOfBoardgamesByMechanicQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<NavBoardgameDTO>> Handle(GetBatchOfBoardgamesByMechanicQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await _unitOfWork.BoardgameMechanicsTagsRepository.GetBatchOfBoardgamesByMechanicAsync(request.MechanicId,
                request.Size, request.Skip, cancellationToken);
        }
    }
}
