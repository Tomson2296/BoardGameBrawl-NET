using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerFavouriteBGs.Commands.DeletePlayerFavouriteBG
{
    public class DeletePlayerFavouriteBGCommandHandler : IRequestHandler<DeletePlayerFavouriteBGCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeletePlayerFavouriteBGCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse> Handle(DeletePlayerFavouriteBGCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var response = new BaseCommandResponse();
            var playerFavouriteInDB = await unitOfWork.PlayerFavouriteBGRepository.GetPlayerFavouriteBGAsync(request.PlayerId,
                request.BoardgameId, cancellationToken);

            if (playerFavouriteInDB == null)
            {
                response.Success = false;
                response.Message = "Removing Process Unsuccessful - Player not found";
                response.Id = Guid.NewGuid();
                return response;
            }
            else
            {
                await unitOfWork.PlayerFavouriteBGRepository.DeleteEntity(playerFavouriteInDB, cancellationToken);
                await unitOfWork.CommitChangesAsync();

                response.Success = true;
                response.Message = "Removing Process Successful";
                response.Id = Guid.NewGuid();
            }
            return response;
        }
    }
}
