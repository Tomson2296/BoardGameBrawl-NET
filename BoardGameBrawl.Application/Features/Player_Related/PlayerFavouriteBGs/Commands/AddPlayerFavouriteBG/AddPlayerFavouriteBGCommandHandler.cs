using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Responses;
using BoardGameBrawl.Application.Validators.Player_Related.PlayerFavouriteBGs;
using BoardGameBrawl.Domain.Entities.Player_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerFavouriteBGs.Commands.AddPlayerFavouriteBG
{
    public class AddPlayerFavouriteBGCommandHandler : IRequestHandler<AddPlayerFavouriteBGCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddPlayerFavouriteBGCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(AddPlayerFavouriteBGCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var response = new BaseCommandResponse();
            var validator = new AddPlayerFavouriteBGValidator();
            var validationResult = await validator.ValidateAsync(request.PlayerFavouriteBGDTO);

            if (validationResult.IsValid == false)
            {
                return new BaseCommandResponse
                {
                    Success = false,
                    Message = "Creation Failed",
                    Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList()
                };
            }
            else
            {
                var playerFavouriteBG = _mapper.Map<PlayerFavouriteBG>(request.PlayerFavouriteBGDTO);

                await _unitOfWork.PlayerFavouriteBGRepository.AddEntity(playerFavouriteBG, cancellationToken);
                await _unitOfWork.CommitChangesAsync();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = Guid.NewGuid();
            }

            return response;
        }
    }
}
