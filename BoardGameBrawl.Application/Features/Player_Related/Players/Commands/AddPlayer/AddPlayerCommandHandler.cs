﻿#nullable disable
using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Responses;
using BoardGameBrawl.Application.Validators.Player_Related;
using BoardGameBrawl.Domain.Entities.Player_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Player_Related.Players.Commands.AddPlayer
{
    public class AddPlayerCommandHandler : IRequestHandler<AddPlayerCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddPlayerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(AddPlayerCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var response = new BaseCommandResponse();
            var validator = new AddPlayerValidator(_unitOfWork.PlayerRepository);
            var validationResult = await validator.ValidateAsync(request.PlayerDTO);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var player = _mapper.Map<Player>(request.PlayerDTO);

                await _unitOfWork.PlayerRepository.AddEntity(player);
                await _unitOfWork.CommitChangesAsync();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = player.Id;
            }

            return response;
        }
    }
}
