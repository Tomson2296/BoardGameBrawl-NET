using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameModerators.Queries.CheckIfBoardgameModeratorExists
{
    public class CheckIfBoardgameModeratorExistsQueryHandler : IRequestHandler<CheckIfBoardgameModeratorExistsQuery, bool>
    {
        private readonly IUnitOfWork unitOfWork;

        public CheckIfBoardgameModeratorExistsQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CheckIfBoardgameModeratorExistsQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await unitOfWork.BoardgameModeratorsRepository.Exists(request.ModeratorId,
                request.BoardgameId, cancellationToken);
        }
    }
}
