using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameDomainTags.Queries.GetBoardgameeByDomain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameDomainTags.Queries.GetBoardgameByDomain
{
    public class GetBoardgamesByDomainQueryHandler : IRequestHandler<GetBoardgamesByDomainQuery, IList<NavBoardgameDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBoardgamesByDomainQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<NavBoardgameDTO>> Handle(GetBoardgamesByDomainQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await _unitOfWork.BoardgameDomainTagsRepository.GetBoardgamesByDomainAsync(request.DomainId, cancellationToken);
        }
    }
}
