using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameDomainTags.Queries.GetBatchOfBoardgamesByDomain
{
    public class GetBatchOfBoardgamesByDomainQueryHandler : IRequestHandler<GetBatchOfBoardgamesByDomainQuery, IList<NavBoardgameDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBatchOfBoardgamesByDomainQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<NavBoardgameDTO>> Handle(GetBatchOfBoardgamesByDomainQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await _unitOfWork.BoardgameDomainTagsRepository.GetBatchOfBoardgamesByDomainAsync(request.DomainId,
                request.Size, request.Skip, cancellationToken);
        }
    }
}
