using BoardGameBrawl.Application.Contracts.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameCategories.Queries.GetBoardgameCategoryId
{
    public class GetBoardgameCategoryIdQueryHandler : IRequestHandler<GetBoardgameCategoryIdQuery, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBoardgameCategoryIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(GetBoardgameCategoryIdQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await _unitOfWork.BoardgameCategoryRepository.GetBoardgameCategoryIdAsync(request.CategoryName, cancellationToken);
        }
    }
}
