using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameDomains.Queries.CheckIfBoardgameDomainExists
{
    public class CheckIfBoardgameDomainExistsQueryHandler : IRequestHandler<CheckIfBoardgameDomainExistsQuery, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CheckIfBoardgameDomainExistsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CheckIfBoardgameDomainExistsQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var domain = _mapper.Map<BoardgameDomain>(request.BoardgameDomainDTO);
            return await _unitOfWork.BoardgameDomainsRepository.Exists(domain, cancellationToken);
        }
    }
}
