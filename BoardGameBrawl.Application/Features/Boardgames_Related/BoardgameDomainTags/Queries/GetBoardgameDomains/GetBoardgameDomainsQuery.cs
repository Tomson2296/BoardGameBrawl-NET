﻿using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameDomainTags.Queries.GetBoardgameDomains
{
    public class GetBoardgameDomainsQuery : IRequest<IList<BoardgameDomainDTO>>
    {
        public Guid BoardgameId { get; set; }
    }
}
