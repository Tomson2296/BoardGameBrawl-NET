using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Player_Related.Players.Queries.GetPlayerByAppUserId
{
    public class GetPlayerByAppUserIdQueryHandler : IRequestHandler<GetPlayerByAppUserIdQuery, PlayerDTO>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;

        public GetPlayerByAppUserIdQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }

        public async Task<PlayerDTO> Handle(GetPlayerByAppUserIdQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var player = await _unitofwork.PlayerRepository.GetPlayerByApplicationUserIdAsync(request.ApplicationId, cancellationToken);
            
            return _mapper.Map<PlayerDTO>(player);
        }
    }
}
