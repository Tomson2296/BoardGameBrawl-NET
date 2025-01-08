using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Exceptions;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.Boardgames.Commands.RemoveBoardgame
{
    public class RemoveBoardgameCommandHandler : IRequestHandler<RemoveBoardgameCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RemoveBoardgameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(RemoveBoardgameCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var boardgame = _mapper.Map<Boardgame>(request.Id);

            var boardgameInDB = await _unitOfWork.BoardgameRepository.GetEntity(boardgame.Id);

            if (boardgameInDB == null)
            {
                throw new NotFoundException(nameof(boardgameInDB), boardgame.Id);
            }
            else
            {
                await _unitOfWork.BoardgameRepository.DeleteEntity(boardgame);
                await _unitOfWork.CommitChangesAsync();
                return Unit.Value;
            }
        }
    }
}
