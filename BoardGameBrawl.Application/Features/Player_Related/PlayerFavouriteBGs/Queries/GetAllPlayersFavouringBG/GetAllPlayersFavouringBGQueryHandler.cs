using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerFavouriteBGs.Queries.GetAllPlayersFavouringBG
{
    public class GetAllPlayersFavouringBGQueryHandler : IRequestHandler<GetAllPlayersFavouringBGQuery, IList<PlayerFavouriteBGDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllPlayersFavouringBGQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<PlayerFavouriteBGDTO>> Handle(GetAllPlayersFavouringBGQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await _unitOfWork.PlayerFavouriteBGRepository.GetAllPlayersFavouringBGAsync(request.BoardgameId, cancellationToken);
        }
    }
}
