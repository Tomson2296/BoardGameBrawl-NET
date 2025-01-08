
using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Exceptions;
using BoardGameBrawl.Domain.Entities.Player_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Player_Related.Players.Commands.RemoveUser
{
    public class RemovePlayerCommandHandler : IRequestHandler<RemovePlayerCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RemovePlayerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(RemovePlayerCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var player = _mapper.Map<Player>(request.Id);

            var playerInDB = await _unitOfWork.PlayerRepository.GetEntity(player.Id);

            if (playerInDB == null)
            {
                throw new NotFoundException(nameof(playerInDB), player.Id);
            }
            else
            {
                await _unitOfWork.PlayerRepository.DeleteEntity(player);
                await _unitOfWork.CommitChangesAsync();
                return Unit.Value;
            }
        }
    }
}
