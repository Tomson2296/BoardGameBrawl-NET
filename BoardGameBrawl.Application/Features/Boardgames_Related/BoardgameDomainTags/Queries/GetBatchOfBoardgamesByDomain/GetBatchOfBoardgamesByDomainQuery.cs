﻿using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameDomainTags.Queries.GetBatchOfBoardgamesByDomain
{
    public class GetBatchOfBoardgamesByDomainQuery : IRequest<IList<NavBoardgameDTO>>
    {
        public Guid DomainId { get; set; }

        public int Size { get; set; }

        public int Skip { get; set; }
    }
}
