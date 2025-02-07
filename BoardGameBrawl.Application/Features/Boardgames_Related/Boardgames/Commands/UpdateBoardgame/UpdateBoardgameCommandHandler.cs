using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Exceptions;
using BoardGameBrawl.Application.Validators.Boardgames_Related.Boardgames;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.Boardgames.Commands.UpdateBoardgame
{
    public class UpdateBoardgameCommandHandler : IRequestHandler<UpdateBoardgameCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBoardgameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBoardgameCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var validator = new UpdateBoardgameValidator(_unitOfWork.BoardgameRepository);
            var validationResult = await validator.ValidateAsync(request.BoardgameDTO);

            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }
            else
            {
                var boardgameInDB = await _unitOfWork.BoardgameRepository.GetEntity(request.BoardgameDTO.Id, cancellationToken);

                if (boardgameInDB == null)
                {
                    throw new NotFoundException(nameof(boardgameInDB), request.BoardgameDTO.Id);
                }
                else
                {
                    var boardgame = _mapper.Map<Boardgame>(request.BoardgameDTO);
                    await _unitOfWork.BoardgameRepository.UpdateEntity(boardgame, cancellationToken);
                    await _unitOfWork.CommitChangesAsync();
                    return Unit.Value;
                }
            }
        }
    }
}
