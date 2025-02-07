using BoardGameBrawl.Application.Contracts.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameDomains.Queries.GetBoardgameDomainId
{
    public class GetBoardgameDomainIdQueryHandler : IRequestHandler<GetBoardgameDomainIdQuery, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBoardgameDomainIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(GetBoardgameDomainIdQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await _unitOfWork.BoardgameDomainsRepository.GetBoardgameDomainIdAsync(request.DomainName, cancellationToken);
        }
    }
}
