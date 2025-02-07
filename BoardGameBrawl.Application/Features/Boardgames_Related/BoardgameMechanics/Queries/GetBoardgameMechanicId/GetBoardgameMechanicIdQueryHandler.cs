using BoardGameBrawl.Application.Contracts.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameMechanics.Queries.GetBoardgameMechanicId
{
    public class GetBoardgameMechanicIdQueryHandler : IRequestHandler<GetBoardgameMechanicIdQuery, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBoardgameMechanicIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(GetBoardgameMechanicIdQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await _unitOfWork.BoardgameMechanicsRepository.GetBoardgameMechanicIdAsync(request.MechanicName, cancellationToken);
        }
    }
}
