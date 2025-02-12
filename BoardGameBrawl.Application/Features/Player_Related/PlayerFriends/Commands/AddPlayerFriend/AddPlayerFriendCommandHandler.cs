using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Application.Responses;
using BoardGameBrawl.Application.Validators.Player_Related.PlayerFavouriteBGs;
using BoardGameBrawl.Application.Validators.Player_Related.PlayerFriend;
using BoardGameBrawl.Domain.Entities.Player_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerFriends.Commands.AddPlayerFriend
{
    public class AddPlayerFriendCommandHandler : IRequestHandler<AddPlayerFriendCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddPlayerFriendCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(AddPlayerFriendCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var response = new BaseCommandResponse();
            var validator = new AddPlayerFriendValidator();
            var validationResult = await validator.ValidateAsync(request.PlayerFriendDTO);

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
                var playerFriend = _mapper.Map<PlayerFriend>(request.PlayerFriendDTO);

                await _unitOfWork.PlayerFriendRepository.AddEntity(playerFriend, cancellationToken);
                await _unitOfWork.CommitChangesAsync();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = Guid.NewGuid();
            }

            return response;
        }
    }
}
