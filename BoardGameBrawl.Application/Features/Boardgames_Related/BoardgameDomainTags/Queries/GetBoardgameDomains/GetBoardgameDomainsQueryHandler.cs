using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameDomainTags.Queries.GetBoardgameDomains
{
    public class GetBoardgameDomainsQueryHandler : IRequestHandler<GetBoardgameDomainsQuery, IList<BoardgameDomainDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBoardgameDomainsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<BoardgameDomainDTO>> Handle(GetBoardgameDomainsQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await _unitOfWork.BoardgameDomainTagsRepository.GetBoardgameDomainsByBoardgameIdAsync(request.BoardgameId, cancellationToken);
        }
    }
}
