using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerFavouriteBGs.Queries.GetAllPlayerfavouriteBGs
{
    public class GetAllPlayerFavouriteBGsQueryHandler : IRequestHandler<GetAllPlayerFavouriteBGsQuery, IList<PlayerFavouriteBGDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllPlayerFavouriteBGsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<PlayerFavouriteBGDTO>> Handle(GetAllPlayerFavouriteBGsQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await _unitOfWork.PlayerFavouriteBGRepository.GetAllPlayerFavouriteBGsAsync(request.PlayerId, cancellationToken);
        }
    }
}
