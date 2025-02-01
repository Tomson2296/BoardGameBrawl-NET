using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Exceptions;
using BoardGameBrawl.Application.Validators.Player_Related;
using BoardGameBrawl.Domain.Entities.Player_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Player_Related.Players.Commands.UpdateUser
{
    public class UpdatePlayerCommandHandler : IRequestHandler<UpdatePlayerCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePlayerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePlayerCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var validator = new UpdatePlayerValidator(_unitOfWork.PlayerRepository);
            var validationResult = await validator.ValidateAsync(request.PlayerDTO);

            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }
            else
            {
                var playerInDB = await _unitOfWork.PlayerRepository.GetEntity(request.PlayerDTO.Id, cancellationToken);

                if (playerInDB == null)
                {
                    throw new NotFoundException(nameof(playerInDB), request.PlayerDTO.Id);
                }
                else
                {
                    var player = _mapper.Map<Player>(request.PlayerDTO);
                    await _unitOfWork.PlayerRepository.UpdateEntity(player, cancellationToken);
                    await _unitOfWork.CommitChangesAsync();
                    return Unit.Value;
                }
            }
        }
    }
}
