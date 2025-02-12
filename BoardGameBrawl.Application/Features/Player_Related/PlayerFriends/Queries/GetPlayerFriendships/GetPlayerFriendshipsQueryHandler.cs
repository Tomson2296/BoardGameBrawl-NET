using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerFriends.Queries.GetPlayerFriendships
{
    public class GetPlayerFriendshipsQueryHandler : IRequestHandler<GetPlayerFriendshipsQuery, IList<NavPlayerDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPlayerFriendshipsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<NavPlayerDTO>> Handle(GetPlayerFriendshipsQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await _unitOfWork.PlayerFriendRepository.GetPlayerFriendshipsAsync(request.PlayerId, cancellationToken);
        }
    }
}
