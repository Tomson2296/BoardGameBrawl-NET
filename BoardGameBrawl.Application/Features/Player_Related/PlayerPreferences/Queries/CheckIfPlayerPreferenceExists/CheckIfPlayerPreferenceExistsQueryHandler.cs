using BoardGameBrawl.Application.Contracts.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerPreferences.Queries.CheckIfPlayerPreferenceExists
{
    public class CheckIfPlayerPreferenceExistsQueryHandler : IRequestHandler<CheckIfPlayerPreferenceExistsQuery, bool>
    {
        private readonly IUnitOfWork unitOfWork;

        public CheckIfPlayerPreferenceExistsQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CheckIfPlayerPreferenceExistsQuery request, CancellationToken cancellationToken)
        {
            return await unitOfWork.PlayerPreferenceRepository.Exists(request.PlayerId, request.BoardgameId, cancellationToken);
        }
    }
}
