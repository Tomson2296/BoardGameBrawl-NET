using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Responses;
using BoardGameBrawl.Application.Validators.Player_Related.PlayerCollections;
using BoardGameBrawl.Domain.Entities.Player_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerCollections.Commands.AddPlayerCollection
{
    public class AddPlayerCollectionCommandHandler : IRequestHandler<AddPlayerCollectionCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddPlayerCollectionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(AddPlayerCollectionCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var response = new BaseCommandResponse();
            var validator = new AddPlayerCollectionValidator();
            var validationResult = await validator.ValidateAsync(request.PlayerCollectionDTO);

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
                var playerCollection = _mapper.Map<PlayerCollection>(request.PlayerCollectionDTO);

                await _unitOfWork.PlayerCollectionRepository.AddEntity(playerCollection, cancellationToken);
                await _unitOfWork.PlayerCollectionRepository.SetIsCollectionCreatedAsync(playerCollection, true, cancellationToken);
                await _unitOfWork.CommitChangesAsync();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = playerCollection.Id;
            }

            return response;
        }
    }
}
