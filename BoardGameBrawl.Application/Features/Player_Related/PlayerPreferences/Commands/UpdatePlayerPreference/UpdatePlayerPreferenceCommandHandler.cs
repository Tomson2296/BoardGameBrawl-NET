using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Exceptions;
using BoardGameBrawl.Application.Responses;
using BoardGameBrawl.Application.Validators.Player_Related.PlayerPreferences;
using BoardGameBrawl.Domain.Entities.Player_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerPreferences.Commands.UpdatePlayerPreference
{
    public class UpdatePlayerPreferenceCommandHandler : IRequestHandler<UpdatePlayerPreferenceCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdatePlayerPreferenceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdatePlayerPreferenceCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var response = new BaseCommandResponse();
            var validator = new UpdatePlayerPreferenceValidator(unitOfWork.PlayerPreferenceRepository);
            var validationResult = await validator.ValidateAsync(request.PlayerPreferenceDTO);

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
                var playerPreferenceInDB = await unitOfWork.PlayerPreferenceRepository.GetPlayerPreferenceAsync(request.PlayerPreferenceDTO.PlayerId,
                    request.PlayerPreferenceDTO.BoardgameId, cancellationToken);

                if (playerPreferenceInDB == null)
                {
                    throw new NotFoundException(nameof(playerPreferenceInDB), request.PlayerPreferenceDTO.PlayerId);
                }
                else
                {
                    var playerPrefence = mapper.Map<PlayerPreference>(playerPreferenceInDB);
                    unitOfWork.PlayerPreferenceRepository.AttachEntity(playerPrefence);

                    playerPrefence.Rating = request.PlayerPreferenceDTO.Rating;

                    // reattach object 
                    await unitOfWork.PlayerPreferenceRepository.UpdateEntity(playerPrefence, cancellationToken);
                    await unitOfWork.CommitChangesAsync();

                    response.Success = true;
                    response.Message = "Update Process Successful";
                    response.Id = Guid.NewGuid();
                }

                return response;
            }
        }
    }
}
