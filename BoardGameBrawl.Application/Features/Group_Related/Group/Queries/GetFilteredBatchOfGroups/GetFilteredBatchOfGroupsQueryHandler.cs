﻿using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using BoardGameBrawl.Application.DTOs.Entities.Group_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Group_Related.Group.Queries.GetFilteredBatchOfGroups
{
    public class GetFilteredBatchOfGroupsQueryHandler : IRequestHandler<GetFilteredBatchOfGroupsQuery, IList<NavGroupDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetFilteredBatchOfGroupsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<NavGroupDTO>> Handle(GetFilteredBatchOfGroupsQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var filteredGroups = await _unitOfWork.GroupRepository.GetFilteredBatchOfGroupsAsync(request.Filter,
                request.Size, request.Skip, cancellationToken);
            return _mapper.Map<IList<NavGroupDTO>>(filteredGroups);
        }
    }
}
