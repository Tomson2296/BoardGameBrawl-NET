using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Responses;
using BoardGameBrawl.Application.Validators.Boardgames_Related.Boardgames;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.Boardgames.Commands.AddBoardgame
{
    public class AddBoardgameCommandHandler : IRequestHandler<AddBoardgameCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddBoardgameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(AddBoardgameCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var response = new BaseCommandResponse();
            var validator = new AddBoardgameValidator(_unitOfWork.BoardgameRepository);
            var validationResult = await validator.ValidateAsync(request.BoardgameDTO, cancellationToken);

            if (!validationResult.IsValid)
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
                var boardgame = _mapper.Map<Boardgame>(request.BoardgameDTO);

                await _unitOfWork.BoardgameRepository.AddEntity(boardgame, cancellationToken);
                await _unitOfWork.CommitChangesAsync();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = boardgame.Id;
            }

            return response;
        }
    }
}
