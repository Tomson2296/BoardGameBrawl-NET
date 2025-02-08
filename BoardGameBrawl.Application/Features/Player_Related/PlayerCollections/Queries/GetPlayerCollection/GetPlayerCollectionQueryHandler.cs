using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerCollections.Queries.GetPlayerCollection
{
    public class GetPlayerCollectionQueryHandler : IRequestHandler<GetPlayerCollectionQuery, PlayerCollectionDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPlayerCollectionQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PlayerCollectionDTO> Handle(GetPlayerCollectionQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var playerCollection = await _unitOfWork.PlayerCollectionRepository.GetPlayerCollectionByIdAsync(request.Id, cancellationToken);
            return _mapper.Map<PlayerCollectionDTO>(playerCollection);
        }
    }
}
