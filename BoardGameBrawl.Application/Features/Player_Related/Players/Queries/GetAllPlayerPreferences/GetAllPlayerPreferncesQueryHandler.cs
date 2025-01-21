using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using MediatR;

namespace BoardGameBrawl.Application.Features.Player_Related.Players.Queries.GetAllPlayerPreferences
{
    public class GetAllPlayerPreferncesQueryHandler : IRequestHandler<GetAllPlayerPreferncesQuery, IDictionary<Guid, byte>>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;

        public GetAllPlayerPreferncesQueryHandler(IUnitOfWork unitofwork, IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }

        public async Task<IDictionary<Guid, byte>> Handle(GetAllPlayerPreferncesQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var playerPreferences = await _unitofwork.PlayerPreferenceRepository.GetAllPlayerPreferencesAsync(request.PlayerId);
            return _mapper.Map<IDictionary<Guid, byte>>(playerPreferences);
        }
    }
}
