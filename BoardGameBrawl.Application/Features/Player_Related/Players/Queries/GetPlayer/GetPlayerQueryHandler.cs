using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Player_Related.Players.Queries.GetPlayer
{
    public class GetPlayerQueryHandler : IRequestHandler<GetPlayerQuery, PlayerDTO>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;

        public GetPlayerQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitofwork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PlayerDTO> Handle(GetPlayerQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var player = await _unitofwork.PlayerRepository.GetEntity(request.Id);
            return _mapper.Map<PlayerDTO>(player);
        }
    }
}
