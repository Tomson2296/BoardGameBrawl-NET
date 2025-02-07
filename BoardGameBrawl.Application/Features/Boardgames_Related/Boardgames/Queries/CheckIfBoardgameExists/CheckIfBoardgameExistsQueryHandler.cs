using BoardGameBrawl.Application.Contracts.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.Boardgames.Queries.CheckIfBoardgameExists
{
    public class CheckIfBoardgameExistsQueryHandler : IRequestHandler<CheckIfBoardgameExistsQuery, bool>
    {
        private IUnitOfWork _unitOfWork;

        public CheckIfBoardgameExistsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CheckIfBoardgameExistsQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await _unitOfWork.BoardgameRepository.Exists(request.Id);
        }
    }
}
