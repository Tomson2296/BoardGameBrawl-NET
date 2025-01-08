using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using MediatR;

namespace BoardGameBrawl.Application.Features.Player_Related.Players.Commands.AddPlayer
{
    public class AddPlayerCommandHandler : IRequestHandler<AddPlayerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddPlayerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(AddPlayerCommand request, CancellationToken cancellationToken)
        {

        }
    }
}
