
using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Responses;
using MediatR;

namespace BoardGameBrawl.Application.Features.Player_Related.Players.Commands.RemoveUser
{
    public class RemovePlayerCommandHandler : IRequestHandler<RemovePlayerCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemovePlayerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse> Handle(RemovePlayerCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var response = new BaseCommandResponse();
            var playerInDB = await _unitOfWork.PlayerRepository.GetEntity(request.Id, cancellationToken);
            
            if (playerInDB == null)
            {
                response.Success = false;
                response.Message = "Removing Process Unsuccessful - Player not found";
                response.Id = request.Id; 
                return response;
            }
            else
            {
                await _unitOfWork.PlayerRepository.DeleteEntity(playerInDB, cancellationToken);
                await _unitOfWork.CommitChangesAsync();

                response.Success = true;
                response.Message = "Removing Process Successful";
                response.Id = request.Id;
            }
            return response;
        }
    }
}
