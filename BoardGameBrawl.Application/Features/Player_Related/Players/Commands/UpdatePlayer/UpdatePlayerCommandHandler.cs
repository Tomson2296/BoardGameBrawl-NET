using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Exceptions;
using BoardGameBrawl.Application.Responses;
using BoardGameBrawl.Application.Validators.Player_Related.Players;
using BoardGameBrawl.Domain.Entities.Player_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Player_Related.Players.Commands.UpdateUser
{
    public class UpdatePlayerCommandHandler : IRequestHandler<UpdatePlayerCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePlayerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdatePlayerCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var response = new BaseCommandResponse();
            var validator = new UpdatePlayerValidator(_unitOfWork.PlayerRepository);
            var validationResult = await validator.ValidateAsync(request.PlayerDTO);

            if (validationResult.IsValid == false)
            {
                return new BaseCommandResponse
                {
                    Success = false,
                    Message = "Update Process Failed",
                    Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList()
                };
            }
            else
            {
                var playerInDB = await _unitOfWork.PlayerRepository.GetPlayerByApplicationUserIdAsync(request.PlayerDTO.ApplicationUserId, cancellationToken);

                if (playerInDB == null)
                {
                    throw new NotFoundException(nameof(playerInDB), request.PlayerDTO.Id);
                }
                else
                {
                    var player = _mapper.Map<Player>(request.PlayerDTO);
                    
                    _unitOfWork.PlayerRepository.AttachEntity(playerInDB);

                    playerInDB.FirstName = player.FirstName;
                    playerInDB.LastName = player.LastName;
                    playerInDB.BGGUsername = player.BGGUsername;
                    playerInDB.UserDescription = player.UserDescription;
                    
                    // reattach object 
                    await _unitOfWork.PlayerRepository.UpdateEntity(playerInDB, cancellationToken);
                    await _unitOfWork.CommitChangesAsync();

                    response.Success = true;
                    response.Message = "Update Process Successful";
                    response.Id = player.Id;
                }

                return response;
            }
        }
    }
}
