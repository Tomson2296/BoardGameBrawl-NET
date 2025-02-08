using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerPreferences.Queries.GetAllPlayerPreferences
{
    public class GetAllPlayerPreferencesQueryHandler : IRequestHandler<GetAllPlayerPreferencesQuery, IDictionary<Guid, byte>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllPlayerPreferencesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDictionary<Guid, byte>> Handle(GetAllPlayerPreferencesQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await _unitOfWork.PlayerPreferenceRepository.GetAllPlayerPreferencesAsync(request.PlayerId, cancellationToken);
        }
    }
}
